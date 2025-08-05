using Destek.Application.Features.Commands.Brand.Update;
using Destek.Application.Features.Commands.TicketAssign.DeleteTicketAssign;
using Destek.Application.Features.Commands.WarehouseTransaction.Cancel;
using Destek.Application.Features.Commands.WarehouseTransaction.Create;
using Destek.Application.Features.Commands.WarehouseTransaction.Remove;
using Destek.Application.Features.Commands.WarehouseTransaction.RemoveForTicket;
using Destek.Application.Features.Queries.WarehouseTransaction.GelAllByWarehouseId;
using Destek.Application.Features.Queries.WarehouseTransaction.GetAllByDepartmentId;
using Destek.Application.Features.Queries.WarehouseTransaction.GetAllByTicketId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseTransactionsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByWarehouseId([FromQuery] GetAllWarehouseTransactionByWarehouseIdQueryRequest request)
        {
            GetAllWarehouseTransactionByWarehouseIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByDepartmentId([FromQuery] GetAllWarehouseTransactionByDepartmentIdQueryRequest request)
        {
            GetAllWarehouseTransactionByDepartmentIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByTicketId([FromQuery] GetAllWarehouseTransactionByTicketIdQueryRequest request)
        {
            GetAllWarehouseTransactionByTicketIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        //[HttpGet("[action]/{Id}")]
        //public async Task<ActionResult> GetById([FromRoute] GetProductIdQueryRequest request)
        //{
        //    GetProductIdQueryResponse response = await mediator.Send(request);
        //    return Ok(response);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateWarehouseTransactionCommandRequest request)
        {
            CreateWarehouseTransactionCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Export(RemoveWarehouseTransactionCommandRequest request)
        {
            RemoveWarehouseTransactionCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ExportWithTicket(RemoveForTicketWarehouseTransactionCommandRequest request)
        {
            RemoveForTicketWarehouseTransactionCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
  
       
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] CancelWarehouseTransactionCommandRequest request)
        {
            CancelWarehouseTransactionCommandResponse response = await mediator.Send(request);
            return Ok();
        }

    }
}
