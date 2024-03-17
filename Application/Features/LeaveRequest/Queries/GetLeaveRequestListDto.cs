using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries;

public class GetLeaveRequestListDto
{
    public string RequestingEmployeeId { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool? Approved { get; set; }
}