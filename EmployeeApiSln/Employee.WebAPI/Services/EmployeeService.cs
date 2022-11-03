using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employee.WebAPI.ApiModels.Employee;
using Employee.WebAPI.Services.Interfaces;
using EmployeeApi.Database.EF;
using Microsoft.EntityFrameworkCore;

namespace Employee.WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EmployeeApiModel>> GetAllEmployeesAsync(CancellationToken ct)
        {
            return await _dbContext.Employees
                .ProjectTo<EmployeeApiModel>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);
        }

        public async Task<EmployeeApiModel> GetEmployeeByIdAsync(int id, CancellationToken ct)
        {
            var employee = await EmployeeByIdAsync(id, ct);

            if (employee == null)
            {
                // TODO: Throw Not Found exception.
            }

            return employee; 
        }

        public async Task<EmployeeApiModel> CreateEmployeeAsync(CreateEmployeeApiModel employeeModel, CancellationToken ct)
        {
            var dbEmployee = _mapper.Map<EmployeeApi.Database.EF.Models.Employee>(employeeModel);
            _dbContext.Add(dbEmployee);
            await _dbContext.SaveChangesAsync(ct);

            return await EmployeeByIdAsync(dbEmployee.Id, ct);
        }

        public async Task<EmployeeApiModel> UpdateEmployeeAsync(int employeeId, EmployeeApiModel employeeModel, CancellationToken ct)
        {
            if (employeeId != employeeModel.Id)
            {
                // TODO: Throw validation exception.
            }

            var dbEmployee = await _dbContext.Employees.FindAsync(employeeId, ct);
            if (dbEmployee == null)
            {
                // TODO: Throw Not Found exception.
            }

            _mapper.Map(employeeModel, dbEmployee);
            await _dbContext.SaveChangesAsync(ct);

            return await EmployeeByIdAsync(employeeId, ct);
        }

        public async Task<EmployeeApiModel> DeleteEmployeeByIdAsync(int employeeId, CancellationToken ct)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(employeeId, ct);
            if (dbEmployee == null)
            {
                // TODO: Throw Not Found exception.
            }

            var employee = _mapper.Map<EmployeeApiModel>(dbEmployee);

            _dbContext.Remove(dbEmployee);
            await _dbContext.SaveChangesAsync(ct);

            return employee;
        }

        private async Task<EmployeeApiModel> EmployeeByIdAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Employees
                .Where(x => x.Id == id)
                .ProjectTo<EmployeeApiModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);
        }
    }
}
