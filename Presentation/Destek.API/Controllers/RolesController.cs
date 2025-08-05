using Destek.Application.CustomAttributes;
using Destek.Application.Enums;
using Destek.Application.Features.Commands.Role.CreateRole;
using Destek.Application.Features.Queries.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest getRolesQueryRequest)
        {
            GetRolesQueryResponse response = await mediator.Send(getRolesQueryRequest);
            return Ok(response);
        }

        //[HttpGet("{Id}")]
        //[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = "Roles")]
        //public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
        //{
        //    GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
        //    return Ok(response);
        //}

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse response = await mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }

        //[HttpPut("{Id}")]
        //[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
        //public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
        //{
        //    UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
        //    return Ok(response);
        //}

        //[HttpDelete("{Id}")]
        //[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = "Roles")]
        //public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
        //{
        //    DeleteRoleCommandResponse response = await _mediator.Send(deleteRoleCommandRequest);
        //    return Ok(response);
        //}
    }
}
