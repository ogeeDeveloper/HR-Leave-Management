using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Models.Email;
using HRLeaveManagement.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddAPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}