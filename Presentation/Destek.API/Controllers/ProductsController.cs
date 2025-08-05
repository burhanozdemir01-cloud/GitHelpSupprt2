using Destek.Application.Features.Commands.Product.Create;
using Destek.Application.Features.Commands.Product.Update;
using Destek.Application.Features.Queries.Brand.GetAllBrandDropDown;
using Destek.Application.Features.Queries.Product.GetAllByDepartmentId;
using Destek.Application.Features.Queries.Product.GetAllProductDropDown;
using Destek.Application.Features.Queries.Product.GetProductId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByDepartmentId([FromQuery] GetAllProductByDepartmentIdQueryRequest request)
        {
            GetAllProductByDepartmentIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetProductIdQueryRequest request)
        {
            GetProductIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Put(UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllProductDropDownQueryRequest request)
        {
            GetAllProductDropDownQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
