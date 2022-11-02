using Microsoft.EntityFrameworkCore;
using EmployeeApi.Database.EF;

namespace Employee.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAndConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("EmployeeApiDB");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
