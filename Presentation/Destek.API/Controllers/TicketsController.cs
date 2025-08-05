using Destek.Application.Features.Commands.Category.CreateCategory;
using Destek.Application.Features.Commands.Category.UpdateCategory;
using Destek.Application.Features.Commands.Ticket.CreateTicket;
using Destek.Application.Features.Queries.Category.GetAllCategory;
using Destek.Application.Features.Queries.Category.GetByDepartmentIdCategory;
using Destek.Application.Features.Queries.Category.GetByIdCategory;
using Destek.Application.Features.Queries.Department.GetByIdDepartment;
using Destek.Application.Features.Queries.Ticket.GetAllTicket;
using Destek.Application.Features.Queries.Ticket.GetAllTicketIsNew;
using Destek.Application.Features.Queries.Ticket.GetByIdTicket;
using Destek.Application.Features.Queries.Ticket.GetLockedTickets;
using Destek.Application.Features.Queries.Ticket.GetTicketFile;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTicketQueryRequest request)
        {
           GetAllTicketQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetIsNewOrIsOld([FromQuery] GetAllTicketIsNewQueryRequest request)
        {
            GetAllTicketIsNewQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLockedTickets([FromQuery] GetLockedTicketsQueryRequest request)
        {
            GetLockedTicketsQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetCategoryWithSubCategory([FromQuery] GetByDepartmentIdAllCategoryQueryRequest getByDepartmentIdAllCategoryQueryRequest)
        //{
        //    GetByDepartmentIdAllCategoryQueryResponse response = await _mediator.Send(getByDepartmentIdAllCategoryQueryRequest);
        //    return Ok(response);
        //}
        //[HttpGet("[action]/{Id}")]
        //public async Task<ActionResult> Get([FromRoute] GetByIdTicketQueryRequest request)
        //{
        //    GetByIdTicketQueryResponse response = await mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<ActionResult> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        //{
        //    GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest);
        //    return Ok(response);
        //}

        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> Get([FromRoute] GetByIdTicketQueryRequest request)
        {
            GetByIdTicketQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetFile([FromQuery] GetTicketFileQueryRequest request)
        {
            GetTicketFileQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateTicketCommandRequest request)
        {

            CreateTicketCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        //[HttpPut("[action]")]
        ////[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Updating, Definition = "update department")]
        //public async Task<IActionResult> Put([FromBody] UpdateCategoryCommandRequest request)
        //{
        //    UpdateCategoryCommandResponse response = await _mediator.Send(request);
        //    return Ok();
        //}
    }
}
