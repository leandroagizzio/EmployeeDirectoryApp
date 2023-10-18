using EmployeeLibrary.Data;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Services;

public class ShiftService : IShiftService
{
    private readonly ISqlDataAccess _db;

    public ShiftService(ISqlDataAccess db) {
        _db = db;
    }

    public async Task<ServiceResponse<IList<ShiftModel>>> GetShifts() {
        var service = new ServiceResponse<IList<ShiftModel>>();

        var output = await _db.LoadDataListAsync<ShiftModel, dynamic>("dbo.spShift_GetAll", new { });

        service.Data = output;
        service.Message = "Got all shifts";

        return service;
    }

    public async Task<ServiceResponse<ShiftModel>> GetShift(int id) {
        var service = new ServiceResponse<ShiftModel>();

        var output = await _db.LoadDataAsync<ShiftModel, dynamic>("dbo.spShift_GetOne", new { Id = id } );

        service.Data = output;

        service.IsSuccess = (output != null);
        service.Message = (output != null) ? "Shift found" : "No shift found";


        return service;
    }
}
