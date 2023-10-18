using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeLibrary.Data;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config) {
        _config = config;
    }

    public async Task<IList<T>> LoadDataMultipleListAsync<T, U, F, S>
            (string sql, U parameters, Func<F, S, T> map, string connectionStringName = "Default") {

        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName));

        var rows = await connection.QueryAsync<F, S, T>(sql, map, parameters, commandType: CommandType.StoredProcedure);

        return rows.ToList();
    }

    public async Task<IList<T>> LoadDataListAsync<T, U>(string sql, U parameters, string connectionStringName = "Default") {

        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName));

        var rows = await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
                
         
        return rows.ToList();
    }

    public async Task<T?> LoadDataMultipleAsync<T, U, F, S>
            (string sql, U parameters, Func<F, S, T> map, string connectionStringName = "Default") {

        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName));

        var rows = await connection.QueryAsync<F, S, T>(sql, map, parameters, commandType: CommandType.StoredProcedure);

        return rows.FirstOrDefault<T>();
    }


    public async Task<T?> LoadDataAsync<T, U>(string sql, U parameters, string connectionStringName = "Default") {

        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName));

        var row = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
         
        return row;
    }

    public async Task<bool> SaveDataAsync(string storedProcedure, DynamicParameters parameters, string connectionStringName = "Default") {

        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName));
        
        var rowCount = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        return rowCount > 0;
    }
}
