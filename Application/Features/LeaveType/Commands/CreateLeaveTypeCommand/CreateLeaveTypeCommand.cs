using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveTypeCommand
{
    public record CreateLeaveTypeCommand(string Name, int DefaultDays) : IRequest<int>;
}
