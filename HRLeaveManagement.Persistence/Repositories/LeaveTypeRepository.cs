﻿using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRDatabaseContext context) : base(context) { }

        public async Task<bool> IsLeavetypeUniqueAsync(string Name, CancellationToken cancellationToken)
        {
            bool exists = await _dbContext.LeaveTypes.AnyAsync(q => q.Name == Name);
            return !exists;
        }
    }
}
