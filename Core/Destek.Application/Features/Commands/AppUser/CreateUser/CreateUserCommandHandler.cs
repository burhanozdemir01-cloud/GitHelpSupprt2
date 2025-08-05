using Destek.Application.Abstractions.Services;
using Destek.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using d = Destek.Domain.Entities.Identity;
namespace Destek.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = await userService.IsExistUserEmail(request.Email);
            if(isExist)
            {
                return new()
                {
                    Message = "Email daha önce kullanılmış.",
                    Succeeded = false,
                };

            }
            CreateUserResponse response = await userService.CreateUser(new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                TCKN = request.TCKN,
                UserName = request.UserName,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
            //throw new UserCreateFailedException();
        }
    }
}
