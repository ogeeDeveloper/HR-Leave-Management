using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Models.Email;
using HRLeaveManagement.Infrastructure.EmailService;
using HRLeaveManagement.Infrastructure.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        //services.Configure<EmailSettings>(config.GetSection("EmailSettings"));

        // Explicitly bind the configuration section to EmailSettings
        services.Configure<EmailSettings>(emailSettings =>
        {
            config.GetSection("EmailSettings").Bind(emailSettings);
        });

        services.AddTransient<IEmailSender, EmailSender>();
        
        // Register ILogger
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}