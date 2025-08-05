
using Destek.Application.Features.Commands.TicketUnnecessary.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketUnnecessariesController(IMediator mediator) : ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetAllTicketAssignQueryRequest request)
        //{
        //    GetAllTicketAssignQueryResponse response = await mediator.Send(request);
        //    return Ok(response);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateTicketUnnecessaryCommandRequest request)
        {

            CreateTicketUnnecessaryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        //[HttpPut]
        //public async Task<IActionResult> Put(UpdateTicketAssignCommandRequest request)
        //{
        //    UpdateTicketAssignCommandResponse response = await mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] RemoveTicketAssignCommandRequest request)
        //{
        //    RemoveTicketAssignCommandResponse response = await mediator.Send(request);
        //    return Ok();
        //}
    }
}
