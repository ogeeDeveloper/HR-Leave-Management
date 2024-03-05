using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveTypeCommand
{
    public record UpdateLeaveTypeCommand(int Id, string Name, int DefaultDays): IRequest<Unit>;
}
