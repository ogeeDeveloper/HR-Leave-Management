using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    // Get one record with its details
    Task<LeaveAllocation> GetAllLeaveAllocationWithDetails(int Id);
    // Get all leave allocations list
    Task<List<LeaveAllocation>> GetAllLeaveAllocationWithDetails();
    // Get leave allocation list for a specific user
    Task<List<LeaveAllocation>> GetAllLeaveAllocationWithDetails(string userId);
    Task<bool> AllocatonExists(string userId, int leaveTypeId, int period);
    Task AddAllocation(List<LeaveAllocation> allocations);
    // Get all the leave allocations based on the a leave type for the specific user
    Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
}
