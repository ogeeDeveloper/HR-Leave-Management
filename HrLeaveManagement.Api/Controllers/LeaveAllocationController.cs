using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrLeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetLeaveAllocation(bool isLoggedInUser=false)
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationQuery());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDetailDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery(id));
            
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand leaveAllocationCommand)
        {
            var response = await _mediator.Send(leaveAllocationCommand);
            return NoContent();
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateLeaveAllocationCommand leaveAllocationCommand)
        {
            await _mediator.Send(leaveAllocationCommand);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
