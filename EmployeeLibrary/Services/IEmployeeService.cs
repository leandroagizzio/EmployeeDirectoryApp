using EmployeeLibrary.Models;

namespace EmployeeLibrary.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id);
        Task<ServiceResponse<EmployeeModel?>> GetEmployeeAsync(int id);
        Task<ServiceResponse<IList<EmployeeModel>>> GetEmployeesAsync();
        Task<ServiceResponse<EmployeeModel?>> ToggleEmployeeStatusAsync(int id);
        Task<ServiceResponse<EmployeeModel?>> UpsertEmployeeAsync(EmployeeModel model);
    }
}