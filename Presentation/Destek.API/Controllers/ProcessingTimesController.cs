using Destek.Application.Features.Commands.ProcessingTime.Create;
using Destek.Application.Features.Commands.TicketLocked.Locked;
using Destek.Application.Features.Queries.Category.GetByDepartmentIdCategory;
using Destek.Application.Features.Queries.ProcessingTime.GetByDepartmentId;
using Destek.Application.Features.Queries.ProcessingTime.GetBySubCategoryId;
using Destek.Application.Features.Queries.SubCategory.GetByIdSubCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessingTimesController(IMediator mediator) : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateProcessingTimeCommandRequest request)
        {
            CreateProcessingTimeCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetProcessingTimeBySubCategoryIdQueryRequest request)
        {
            GetProcessingTimeBySubCategoryIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryWithSubCategory([FromQuery] GetProcessingTimeByDepartmentIdQueryRequest request)
        {
            GetProcessingTimeByDepartmentIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
