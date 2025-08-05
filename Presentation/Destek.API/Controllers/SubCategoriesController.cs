using Destek.Application.Features.Commands.Category.CreateCategory;
using Destek.Application.Features.Commands.Category.UpdateCategory;
using Destek.Application.Features.Commands.SubCategory.CreateSubCategory;
using Destek.Application.Features.Commands.SubCategory.UpdateSubCategory;
using Destek.Application.Features.Queries.Category.GetAllCategory;
using Destek.Application.Features.Queries.Category.GetAllCategoryDropDownByDepartmentId;
using Destek.Application.Features.Queries.Category.GetByDepartmentIdCategory;
using Destek.Application.Features.Queries.Category.GetByIdCategory;
using Destek.Application.Features.Queries.SubCategory.GetAllSubCategoryDropDownByCategoryId;
using Destek.Application.Features.Queries.SubCategory.GetByIdSubCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] Get getAllProductQueryRequest)
        //{
        //    GetAllCategoryQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
        //    return Ok(response);
        //}

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdSubCategoryQueryRequest getByIdSubCategoryQueryRequest)
        {
            GetByIdSubCategoryQueryResponse response = await _mediator.Send(getByIdSubCategoryQueryRequest);
            return Ok(response);
        }
        //[HttpGet("[action]/{Id}")]
        //public async Task<ActionResult> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        //{
        //    GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest);
        //    return Ok(response);
        //}
        [HttpPost("[action]")]
        public async Task<IActionResult> Post(CreateSubCategoryCommandRequest request)
        {

            CreateSubCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Updating, Definition = "update department")]
        public async Task<IActionResult> Put([FromBody] UpdateSubCategoryCommandRequest request)
        {
            UpdateSubCategoryCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("[action]")]
        // [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Reading, Definition ="Get Department All")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllSubCategoryDropDownBySubCategoryIdQueryRequest request)
        {
            GetAllSubCategoryDropDownBySubCategoryIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
