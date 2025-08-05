using Destek.Application.Features.Commands.TicketTransaction.Create;
using Destek.Application.Features.Queries.TicketTransaction.GetAllTicketTransactionByTicketId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTransactionsController(IMediator mediator) : ControllerBase
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] GetAllTicketTransactionByTicketIdQueryRequest request)
        {
            GetAllTicketTransactionByTicketIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Post(CreateTicketTransactionCommandRequest request)
        //{

        //    CreateTicketTransactionCommandResponse response = await mediator.Send(request);
        //    return Ok(response);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateTicketTransactionCommandRequest request)
        {

            CreateTicketTransactionCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
