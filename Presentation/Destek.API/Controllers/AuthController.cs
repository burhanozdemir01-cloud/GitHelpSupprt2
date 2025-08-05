using Destek.Application.Features.Commands.AppUser.GoogleLogin;
using Destek.Application.Features.Commands.AppUser.LoginUser;
using Destek.Application.Features.Commands.AppUser.PasswordReset;
using Destek.Application.Features.Commands.AppUser.RefreshTokenLogin;
using Destek.Application.Features.Commands.AppUser.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("refresh-token-login")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenLoginCommandRequest request)
        {
            RefreshTokenLoginCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            GoogleLoginCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse response = await mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }

        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            VerifyResetTokenCommandResponse response = await mediator.Send(verifyResetTokenCommandRequest);
            return Ok(response);
        }
    }
}
