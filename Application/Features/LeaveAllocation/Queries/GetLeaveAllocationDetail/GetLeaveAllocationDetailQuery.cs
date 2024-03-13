using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;

public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationDetailDto>
{
    public int Id { get; set; }
}