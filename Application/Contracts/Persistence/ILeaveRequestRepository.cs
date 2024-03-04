using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDtails(int id);
    Task<List<LeaveRequest>> GetLeaveRequestWithDtails();
    Task<List<LeaveRequest>> GetLeaveRequestWithDtails(string userId);
}
