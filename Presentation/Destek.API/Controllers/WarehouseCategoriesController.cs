using Destek.Application.Features.Commands.WarehouseCategory.Create;
using Destek.Application.Features.Commands.WarehouseCategory.Update;
using Destek.Application.Features.Queries.Brand.GetAllBrandDropDown;
using Destek.Application.Features.Queries.WarehouseCategory.GetAllByDepartmentId;
using Destek.Application.Features.Queries.WarehouseCategory.GetAllWarehouseCategoryDropDown;
using Destek.Application.Features.Queries.WarehouseCategory.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseCategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByDepartmentId([FromQuery] GetAllWarehouseCategoryByDepartmentIdQueryRequest request)
        {
            GetAllWarehouseCategoryByDepartmentIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetWarehouseCategoryIdQueryRequest request)
        {
            GetWarehouseCategoryIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateWarehouseCategoryCommandRequest request)
        {
            CreateWarehouseCategoryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put(UpdateWarehouseCategoryCommandRequest request)
        {
            UpdateWarehouseCategoryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllWarehouseCategoryDropDownQueryRequest request)
        {
            GetAllWarehouseCategoryDropDownQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
