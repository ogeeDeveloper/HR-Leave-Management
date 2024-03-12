using HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveTypeCommand;
using HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveTypeCommand;
using HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveTypeCommand;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailQuery;
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
    
    // Get leave type detail
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDetailDto>> GetLeaveTypeDetail(int id)
    {
        var leaveTypeDetail = await _mediator.Send(new GetLeaveTypeDetailQuery(id));
        return leaveTypeDetail;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateLeaveType(CreateLeaveTypeCommand leaveType)
    {
        var response = await _mediator.Send(leaveType);
        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateLeaveType(UpdateLeaveTypeCommand leaveType)
    {
        await _mediator.Send(leaveType);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteLeaveType(int id)
    {
        var command = new DeleteLeaveTypeCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}