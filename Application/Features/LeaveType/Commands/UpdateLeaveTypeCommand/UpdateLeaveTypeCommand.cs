using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveTypeCommand
{
    public record UpdateLeaveTypeCommand(int Id): IRequest<Unit>;
}
