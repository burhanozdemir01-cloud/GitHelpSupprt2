using Destek.Application.Features.Commands.Warehouse.Create;
using Destek.Application.Features.Commands.Warehouse.Update;
using Destek.Application.Features.Queries.Department.GetByIdDepartment;
using Destek.Application.Features.Queries.Product.GetAllProductDropDown;
using Destek.Application.Features.Queries.Warehouse.GetAllByDepartmentId;
using Destek.Application.Features.Queries.Warehouse.GetAllWarehouseDropDown;
using Destek.Application.Features.Queries.Warehouse.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController(IMediator mediator) : ControllerBase
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByDepartmentId([FromQuery] GetAllWarehouseByDepartmentIdQueryRequest request)
        {
            GetAllWarehouseByDepartmentIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetWarehouseIdQueryRequest request)
        {
            GetWarehouseIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateWarehouseCommandRequest request)
        {
            CreateWarehouseCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put(UpdateWarehouseCommandRequest request)
        {
            UpdateWarehouseCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllWarehouseDropDownQueryRequest request)
        {
            GetAllWarehouseDropDownQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
