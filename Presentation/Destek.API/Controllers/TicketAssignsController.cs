using Destek.Application.Consts;
using Destek.Application.CustomAttributes;
using Destek.Application.Enums;
using Destek.Application.Features.Commands.Department.DeleteDepartment;
using Destek.Application.Features.Commands.TicketAssign.CreateTicketAssign;
using Destek.Application.Features.Commands.TicketAssign.DeleteTicketAssign;
using Destek.Application.Features.Commands.TicketAssign.UpdateTicketAssign;
using Destek.Application.Features.Queries.TicketAssign.GetAllTicketAssign;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketAssignsController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTicketAssignQueryRequest request)
        {
            GetAllTicketAssignQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateTicketAssignCommandRequest request)
        {

            CreateTicketAssignCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTicketAssignCommandRequest request)
        {
            UpdateTicketAssignCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveTicketAssignCommandRequest request)
        {
            RemoveTicketAssignCommandResponse response = await mediator.Send(request);
            return Ok();
        }

    }
}
