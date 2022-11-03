using AutoMapper;
using Employee.WebAPI.ApiModels.Employee;

namespace Employee.WebAPI.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Assuming that we add a new employee on their day 1.
            var utcNow = DateTime.UtcNow;

            CreateMap<CreateEmployeeApiModel, EmployeeApi.Database.EF.Models.Employee>()
                .ForMember(x => x.JoinDate, x => x.MapFrom(x => utcNow));

            CreateMap<EmployeeApi.Database.EF.Models.Employee, EmployeeApiModel>();
            CreateMap<EmployeeApiModel, EmployeeApi.Database.EF.Models.Employee>();
        }
    }
}
