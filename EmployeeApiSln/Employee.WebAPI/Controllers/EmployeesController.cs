using Employee.WebAPI.ApiModels.Employee;
using Employee.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.WebAPI.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<EmployeeApiModel>> GetAllAsync(CancellationToken ct)
            => _employeeService.GetAllEmployeesAsync(ct);

        [HttpGet("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<EmployeeApiModel> GetByIdAsync(int employeeId, CancellationToken ct)
            => _employeeService.GetEmployeeByIdAsync(employeeId, ct);

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeApiModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync(CreateEmployeeApiModel employeeApiModel, CancellationToken ct)
        {
            var data = await _employeeService.CreateEmployeeAsync(employeeApiModel, ct);
            return CreatedAtAction("GetById", new { employeeId = data.Id }, data);
        }

        [HttpPut("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<EmployeeApiModel> UpdateAsync(int employeeId, 
            EmployeeApiModel employeeApiModel, 
            CancellationToken ct)
            => _employeeService.UpdateEmployeeAsync(employeeId, employeeApiModel, ct);

        [HttpDelete("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<EmployeeApiModel> DeleteAsync(int employeeId, CancellationToken ct)
            => _employeeService.DeleteEmployeeByIdAsync(employeeId, ct);
    }
}
