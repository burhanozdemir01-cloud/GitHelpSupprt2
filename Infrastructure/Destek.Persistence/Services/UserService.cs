using Destek.Application.Abstractions.Services;
using Destek.Application.DTOs.User;
using Destek.Application.Exceptions;
using Destek.Application.Helpers;
using Destek.Domain.Entities.Identity;
using ET.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using d = Destek.Domain.Entities.Identity;
namespace Destek.Persistence.Services
{
    public class UserService(UserManager<d.AppUser> userManager, IHttpContextAccessor httpContextAccessor) : IUserService
    {
        public async Task<CreateUserResponse> CreateUser(CreateUser model)
        {
            IdentityResult result = await userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                TCKN = model.TCKN,

            }, model.Password);
            CreateUserResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
            {
                response.Message = "Kullanıcı eklendi.";
            }
            else
            {
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code}-{error.Description}\n";
            }

            return response;
        }

        public async Task UpdateRefreshToken(AppUser user, string refreshToken, DateTime accessTokenDate, int addOnAccessTokenDate)
        {

            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
                await userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();

        }
        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                //resetToken = Encoding.UTF8.GetString(tokenBytes);
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }

        public async Task<AppUser> GetCurrentUser()
        {
            var userName = httpContextAccessor.HttpContext.User.Identity.Name;
            if (userName == null)
                throw new NotFoundUserException();
            AppUser appUser = await userManager.FindByNameAsync(userName);
            return appUser;
        }

        public async Task<List<UserListDropDown>> GetAllUsers()
        {
            List<UserListDropDown> users =userManager.Users.Select(x => new UserListDropDown() { Id = x.Id, Name = x.FirstName + " " + x.LastName+" "+(!string.IsNullOrEmpty(x.TCKN)?x.TCKN.Substring(0,5):"") }).ToList();
           
            return users;

        }
        public async Task<bool> IsExistUserEmail(string email)
        {
            var user=userManager.FindByEmailAsync(email);
            if(user==null)
                return false;
            return true;
        }

       public async Task<AppUser> GetUserInfo(string userId)
        {
            AppUser appUser =await userManager.FindByIdAsync(userId);
            return appUser;
        }
    }
}
