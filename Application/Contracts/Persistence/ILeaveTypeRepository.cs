using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType> { 
    Task<bool> IsLeavetypeUniqueAsync(string Name, CancellationToken cancellationToken);

}
