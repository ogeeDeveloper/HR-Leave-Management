using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.UpdadeLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrLeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult> Get(GetLeaveRequestQuery leaveRequestQuery)
        {
            var leaveRequestDetail = await _mediator.Send(leaveRequestQuery);
            return Ok(leaveRequestDetail);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        // PUT api/<LeaveRequestController>/5
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }
        
        // PUT api/<LeaveRequestController>/CancelRequest/
        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequest)
        {
            await _mediator.Send(cancelLeaveRequest);
            return NoContent();
        }
        
        // PUT api/<LeaveRequestController>/UpdateRequest/
        [HttpPut]
        [Route("UpdateRequest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateRequest(UpdateLeaveRequestCommand updateLeaveRequest)
        {
            await _mediator.Send(updateLeaveRequest);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand
            {
                Id = id
            });

            return NoContent();
        }
    }
}
