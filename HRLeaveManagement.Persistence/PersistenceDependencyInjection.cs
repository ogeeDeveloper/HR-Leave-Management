﻿using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persistence.DatabaseContext;
using HRLeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddAPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext
            services.AddDbContext<HRDatabaseContext>(options =>
                options.UseSqlServer(config.GetConnectionString("HrDatabaseConnectionString")));


            //services.AddSqlServer<HRDatabaseContext>((config.GetConnectionString("HrDatabaseConnectionString")));

            // Register a scope of the Generic Respostory
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
