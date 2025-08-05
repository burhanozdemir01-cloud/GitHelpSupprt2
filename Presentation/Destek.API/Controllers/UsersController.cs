using Destek.Application.Features.Commands.AppUser.CreateUser;
using Destek.Application.Features.Commands.AppUser.UpdatePassword;
using Destek.Application.Features.Queries.AppUser.GetAllUserDropDown;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        // [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Reading, Definition ="Get Department All")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllUserDropDownQueryRequest getAllUserDropDownQueryRequest)
        {
            GetAllUserDropDownQueryResponse response = await mediator.Send(getAllUserDropDownQueryRequest);
            return Ok(response);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

    }
}
