using Destek.Application.Abstractions.Services;
using MediatR;

namespace Destek.Application.Features.Commands.AppUser.PasswordReset
{
    internal class PasswordResetCommandHandler(IAuthService authService) : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
    {
        public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
        {
            await authService.PasswordResetAsnyc(request.Email);
            return new();
        }
    }
}
