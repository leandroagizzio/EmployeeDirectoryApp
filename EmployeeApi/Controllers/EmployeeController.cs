using EmployeeLibrary.Models;
using EmployeeLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeService;
        private readonly IShiftService _shiftService;

        public EmployeeController(IEmployeeService employeeService, IShiftService shiftService)
        {
            _employeService = employeeService;
            _shiftService = shiftService;
        }

        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<IList<EmployeeModel>>))]
        public async Task<IActionResult> GetEmployees() {
            var service = await _employeService.GetEmployeesAsync();
            return Ok(service);
        }
        
        [HttpGet("GetEmployee/{id}")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<EmployeeModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmployee(int id) {
            var service = await _employeService.GetEmployeeAsync(id);
            return service != null ? Ok(service) : NotFound(service);
        }

        [HttpPut("ToggleSituation/{id}")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<EmployeeModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ToggleSituation(int id) {
            var service = await _employeService.ToggleEmployeeStatusAsync(id);
            return service != null ? Ok(service) : NotFound(service);
        }

        [HttpPost("UpsertEmployee")]
        [ProducesResponseType(201, Type = typeof(ServiceResponse<EmployeeModel>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpsertEmployee(EmployeeModel employeeModel) {
            if (!ModelState.IsValid || !(employeeModel.ShiftModel != null))
                return BadRequest(ModelState);

            var response = await _shiftService.GetShift(employeeModel.ShiftModel.Id);
            if (!response.IsSuccess)
                return NotFound("Shift not found");

            var service = await _employeService.UpsertEmployeeAsync(employeeModel);
            return Ok(service);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        [ProducesResponseType(200, Type = typeof(ServiceResponse<bool>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteEmployee(int id) {
            var service = await _employeService.DeleteEmployeeAsync(id);
            return Ok(service);
        }
    }
}
