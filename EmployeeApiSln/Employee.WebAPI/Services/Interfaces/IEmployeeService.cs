using Employee.WebAPI.ApiModels.Employee;

namespace Employee.WebAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeApiModel>> GetAllEmployeesAsync(CancellationToken ct);
        Task<EmployeeApiModel> GetEmployeeByIdAsync(int employeeId, CancellationToken ct);
        Task<EmployeeApiModel> CreateEmployeeAsync(CreateEmployeeApiModel employeeModel, CancellationToken ct);
        Task<EmployeeApiModel> UpdateEmployeeAsync(int employeeId, EmployeeApiModel employeeModel, CancellationToken ct);
        Task<EmployeeApiModel> DeleteEmployeeByIdAsync(int employeeId, CancellationToken ct);
    }
}
