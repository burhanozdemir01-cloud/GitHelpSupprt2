using Destek.Application.DTOs.User;
using Destek.Application.Features.Commands.AppUser.CreateUser;
using Destek.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUser(CreateUser model);

        Task UpdateRefreshToken(AppUser user,string refreshToken,DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
        Task<AppUser> GetCurrentUser();

        Task<List<UserListDropDown>> GetAllUsers();
        Task<bool> IsExistUserEmail(string email);
        Task<AppUser> GetUserInfo(string userId);

    }
}
