using HRLeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext
            services.AddDbContext<HRDatabaseContext>(options =>
            {
                //Register entity framework as the engine
                options.UseSqlServer(config.GetConnectionString("HrDatabaseConnectionString"));
            });
            return services;
        }
    }
}
