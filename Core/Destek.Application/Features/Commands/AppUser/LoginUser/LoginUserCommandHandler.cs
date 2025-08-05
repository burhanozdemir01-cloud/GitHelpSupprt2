using Destek.Application.Abstractions.Services;
using Destek.Application.Abstractions.Token;
using Destek.Application.DTOs;
using ET.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using d = Destek.Domain.Entities.Identity;
namespace Destek.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler(IAuthService authService) : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await authService.LoginAsync(request.UserNameOrEmail, request.Password, 60);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };

        }
    }
}
