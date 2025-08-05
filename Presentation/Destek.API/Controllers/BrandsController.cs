using Destek.Application.Features.Commands.Brand.Create;
using Destek.Application.Features.Commands.Brand.Update;
using Destek.Application.Features.Queries.Brand.GetAllBrandDropDown;
using Destek.Application.Features.Queries.Brand.GetAllByDepartmentId;
using Destek.Application.Features.Queries.Brand.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByDepartmentId([FromQuery] GetAllBrandByDepartmentIdQueryRequest request)
        {
            GetAllBrandByDepartmentIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetBrandIdQueryRequest request)
        {
            GetBrandIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateBrandCommandRequest request)
        {
            CreateBrandCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put(UpdateBrandCommandRequest request)
        {
            UpdateBrandCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllBrandDropDownQueryRequest request)
        {
            GetAllBrandDropDownQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
