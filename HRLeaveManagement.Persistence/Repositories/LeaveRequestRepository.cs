using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDatabaseContext context) : base(context) { }

        public async Task<LeaveRequest> GetLeaveRequestWithDtails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest ?? throw new InvalidOperationException();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDtails()
        {
            var leaveTypeRequests = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveTypeRequests; ;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDtails(string userId)
        {
            var leaveRequest = await _dbContext.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveRequest;
        }
    }
}
