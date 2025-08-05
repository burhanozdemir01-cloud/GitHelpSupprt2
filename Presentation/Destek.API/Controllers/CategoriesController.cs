using Destek.Application.Features.Commands.Category.CreateCategory;
using Destek.Application.Features.Commands.Category.UpdateCategory;
using Destek.Application.Features.Queries.Category.GetAllCategory;
using Destek.Application.Features.Queries.Category.GetAllCategoryDropDownByDepartmentId;
using Destek.Application.Features.Queries.Category.GetByDepartmentIdCategory;
using Destek.Application.Features.Queries.Category.GetByIdCategory;
using Destek.Application.Features.Queries.Department.GetAllDepartmentDropDown;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoryQueryRequest getAllProductQueryRequest) 
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryWithSubCategory([FromQuery] GetByDepartmentIdAllCategoryQueryRequest getByDepartmentIdAllCategoryQueryRequest)
        {
            GetByDepartmentIdAllCategoryQueryResponse response = await _mediator.Send(getByDepartmentIdAllCategoryQueryRequest);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest request)
        {

            CreateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Updating, Definition = "update department")]
        public async Task<IActionResult> Put([FromBody] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("[action]")]
        // [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Reading, Definition ="Get Department All")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllCategoryDropDownByDepartmentIdQueryRequest request)
        {
            GetAllCategoryDropDownByDepartmentIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
