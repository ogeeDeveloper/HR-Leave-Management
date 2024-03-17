using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;

public record GetLeaveAllocationDetailQuery(int Id) : IRequest<LeaveAllocationDetailDto>;