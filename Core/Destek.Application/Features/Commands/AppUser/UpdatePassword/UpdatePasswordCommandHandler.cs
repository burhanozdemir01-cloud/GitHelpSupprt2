using Destek.Application.Abstractions.Services;
using Destek.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler(IUserService userService) : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
       
        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeFailedException("Lütfen şifreyi birebir doğrulayınız.");

            await userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
            return new();
        }
    }
}
