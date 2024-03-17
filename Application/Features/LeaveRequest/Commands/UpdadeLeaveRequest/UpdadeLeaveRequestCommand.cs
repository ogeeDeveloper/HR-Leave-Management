using HRLeaveManagement.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.UpdadeLeaveRequest;

public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
{
    public int Id { get; set; }
    public string RequestComments { get; set; } = string.Empty;
    public bool Canceled { get; set; }
}