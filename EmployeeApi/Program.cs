
using EmployeeLibrary.Data;
using EmployeeLibrary.Services;

namespace EmployeeApi;

public class Program
{
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //fromat on to PascalCase
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
        builder.Services.AddSingleton<IShiftService, ShiftService>();

        //cors to allow angular to call from the same location
        builder.Services.AddCors(options => {
            options.AddPolicy("AllowAngularOrigins", builder => {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
            });
        });

        var app = builder.Build();

        //cors to allow angular to call from the same location
        app.UseCors("AllowAngularOrigins");


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.MapGet("/employee", async (IEmployeeData db) => {
        //    var output = await db.GetEmployees();
        //    return output;
        //});

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}