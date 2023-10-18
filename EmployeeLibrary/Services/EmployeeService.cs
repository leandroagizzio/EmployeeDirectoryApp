using Dapper;
using EmployeeLibrary.Data;
using EmployeeLibrary.Models;
using System.Data;
using System.Reflection;

namespace EmployeeLibrary.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ISqlDataAccess _db;

    public EmployeeService(ISqlDataAccess db)
    {
        _db = db;
    }

    private Func<EmployeeModel, ShiftModel, EmployeeModel> _EmpShiftMapping = (employee, shift) =>
    {
        employee.ShiftModel = shift;
        return employee;
    };

    public async Task<ServiceResponse<IList<EmployeeModel>>> GetEmployeesAsync()
    {

        var service = new ServiceResponse<IList<EmployeeModel>>();

        var output = await _db.LoadDataMultipleListAsync<EmployeeModel, dynamic, EmployeeModel, ShiftModel>(
                "dbo.spEmployee_GetAll", new { }, _EmpShiftMapping);

        service.Data = output;
        service.Message = "Got all employees";

        return service;
    }

    public async Task<ServiceResponse<EmployeeModel?>> GetEmployeeAsync(int id)
    {

        var service = new ServiceResponse<EmployeeModel?>();

        //var output = await _db.LoadDataAsync<EmployeeModel, dynamic>("dbo.spEmployee_GetOne", new { Id = id });
        var output = await _db.LoadDataMultipleAsync<EmployeeModel, dynamic, EmployeeModel, ShiftModel>
            ("dbo.spEmployee_GetOne", new { Id = id }, _EmpShiftMapping);

        service.Data = output;
        if (output == null)
        {
            service.IsSuccess = false;
            service.Message = "Employee not found";
        }
        else
        {
            service.Message = "Employee found";
        }

        return service;
    }

    public async Task<ServiceResponse<EmployeeModel?>> UpsertEmployeeAsync(EmployeeModel model)
    {

        var service = new ServiceResponse<EmployeeModel?>();

        DynamicParameters p = new();
        p.Add("@Id", model.Id);
        p.Add("@Name", model.Name);
        p.Add("@Title", model.Title);
        p.Add("@Shift_Id", model.ShiftModel?.Id);
        p.Add("@Employee_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        var ret = await _db.SaveDataAsync("dbo.spEmployee_Upsert", p);

        int employeeId = p.Get<int>("@Employee_Id");

        var emp = await GetEmployeeAsync(employeeId);

        if (!ret || !emp.IsSuccess)
        {
            service.IsSuccess = false;
            service.Message = "Error on inserting";
            return service;
        }

        service.Message = "Employee inserted";
        service.Data = emp.Data;

        return service;
    }

    public async Task<ServiceResponse<EmployeeModel?>> ToggleEmployeeStatusAsync(int id)
    {

        var service = new ServiceResponse<EmployeeModel?>();

        DynamicParameters p = new();
        p.Add("@Id", id);

        var ret = await _db.SaveDataAsync("dbo.spEmployee_ToggleActive", p);

        if (!ret)
        {
            service.IsSuccess = false;
            service.Message = "Error on toggling active";
            return service;
        }

        service = await GetEmployeeAsync(id);
        service.Message = "Employee active toggled with success";


        return service;
    }

    public async Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id) {
        var service = new ServiceResponse<bool>();

        DynamicParameters p = new();
        p.Add("@Id", id);

        var ret = await _db.SaveDataAsync("dbo.spEmployee_Remove", p);

        service.IsSuccess = ret;
        service.Message = ret ? "Employee deleted with success" : "Error on deleting employee";

        return service;
    }

}
