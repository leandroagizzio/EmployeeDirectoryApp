using EmployeeLibrary.Models;
using EmployeeLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet("GetAllShifts")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<IList<ShiftModel>>))]
        public async Task<IActionResult> GetAllShifts() {
            var service = await _shiftService.GetShifts();
            return Ok(service);
        }

        [HttpGet("GetShift/{id}")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<ShiftModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetShift(int id) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = await _shiftService.GetShift(id);
            return Ok(service);
        }
    }
}
