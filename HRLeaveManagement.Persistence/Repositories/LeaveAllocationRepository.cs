using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDatabaseContext context) : base(context) { }

        public async Task AddAllocation(List<LeaveAllocation> allocations)
        {
            await _dbContext.AddRangeAsync(allocations);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AllocatonExists(string userId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                && q.LeaveTypeId == leaveTypeId &&
                q.Period == period);
        }

        public async Task<LeaveAllocation> GetAllLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations.Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == Id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetAllLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetAllLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _dbContext.LeaveAllocations.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _dbContext.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
            && q.LeaveTypeId == leaveTypeId);
        }
    }
}
