using Destek.Application.Abstractions.Services;
using Destek.Application.DTOs;
using MediatR;

namespace Destek.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler(IAuthService authService) : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new()
            {
                Token = token,
            };
        }
    }
}
