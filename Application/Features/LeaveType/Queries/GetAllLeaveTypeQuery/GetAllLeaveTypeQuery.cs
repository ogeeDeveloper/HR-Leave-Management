using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;

public record GetAllLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;
