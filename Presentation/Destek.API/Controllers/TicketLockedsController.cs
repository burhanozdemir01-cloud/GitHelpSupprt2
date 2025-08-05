using Destek.Application.Features.Commands.TicketLocked.Locked;
using Destek.Application.Features.Commands.TicketLocked.Unlocked;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLockedsController(IMediator mediator) : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(LockedTicketLockedCommandRequest request)
        {
            LockedTicketLockedCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UnLocked(UnLockedTicketLockedCommandRequest request)
        {
            UnLockedTicketLockedCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
