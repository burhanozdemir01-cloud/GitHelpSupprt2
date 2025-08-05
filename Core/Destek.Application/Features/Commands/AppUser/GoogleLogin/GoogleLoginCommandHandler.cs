using Destek.Application.Abstractions.Services;
using Destek.Application.Abstractions.Token;
using Destek.Application.DTOs;
using Destek.Application.DTOs.User;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using d = Destek.Domain.Entities.Identity;
namespace Destek.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler(IAuthService authService) : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
          var token= await authService.GoogleLoginAsync(request.IdToken, 60);

            return new()
            {
                Token = token
            };
        }
    }
}
