using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;

public class GetLeaveRequestQuery : IRequest<LeaveRequestDetailDto>
{
    public int Id { get; set; }
}