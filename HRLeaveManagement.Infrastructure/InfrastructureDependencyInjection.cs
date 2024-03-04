using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddAPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        return services;
    }
}