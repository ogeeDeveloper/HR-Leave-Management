using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrLeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // Get all leavetype
    [HttpGet]
    public async Task<List<LeaveTypeDto>> GetLeaveTypes()
    {
        // get leave types using the mediatr to send the request
        var leaveTypes = await _mediator.Send(new GetAllLeaveTypeQuery());
        return leaveTypes;
    }
}