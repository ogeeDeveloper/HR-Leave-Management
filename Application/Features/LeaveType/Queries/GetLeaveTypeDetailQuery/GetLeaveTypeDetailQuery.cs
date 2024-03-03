using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailQuery;

public record GetLeaveTypeDetailQuery(int Id) : IRequest<LeaveTypeDetailDto>;
