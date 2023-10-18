using EmployeeLibrary.Models;

namespace EmployeeLibrary.Services
{
    public interface IShiftService
    {
        Task<ServiceResponse<ShiftModel>> GetShift(int id);
        Task<ServiceResponse<IList<ShiftModel>>> GetShifts();
    }
}