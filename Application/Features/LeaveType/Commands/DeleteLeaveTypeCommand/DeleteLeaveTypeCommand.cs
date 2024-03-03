using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveTypeCommand
{
    public record DeleteLeaveTypeCommand(int Id): IRequest<Unit>;
}
