﻿using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation;

public class LeaveAllocationDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}