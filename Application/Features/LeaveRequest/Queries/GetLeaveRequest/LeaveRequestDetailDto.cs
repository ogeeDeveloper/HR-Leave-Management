using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;

public class LeaveRequestDetailDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RequestingEmployeeId { get; set; } = String.Empty;
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestedComments { get; set; } = String.Empty;
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}