using Destek.Application.Abstractions.Services;
using Destek.Application.Abstractions.Token;
using Destek.Application.DTOs;
using Destek.Application.Helpers;
using Destek.Domain.Entities.Identity;
using ET.Application.Exceptions;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using d = Destek.Domain.Entities.Identity;

namespace Destek.Persistence.Services
{
    internal class AuthService(UserManager<d.AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<d.AppUser> signInManager, IUserService userService,IMailService mailService) : IAuthService
    {
        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { configuration["ExternalLoginSettings:Google:Client_ID"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            d.AppUser user = await userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            bool result = user != null;
            if (user == null)
            {
                user = await userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        FirstName = payload.Name,
                        LastName= payload.Name,
                        TCKN=Guid.NewGuid().ToString()
                    };
                    var IdentityResult = await userManager.CreateAsync(user);
                    result = IdentityResult.Succeeded;

                }
            }
            if (result)
                await userManager.AddLoginAsync(user, info);//AspNetUserLogin Tablosune veri ekle
            else
                throw new Exception("Invalid Googşe External authentication");

            Token token = tokenHandler.CreateAccessToken(user, accessTokenLifeTime);
            int refreshTime = accessTokenLifeTime * 20 / 100;
            if (refreshTime <= 5)
                refreshTime = 5;
            await userService.UpdateRefreshToken(user, token.RefreshToken, token.Expiration, refreshTime);
            return token;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            d.AppUser user = await userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await userManager.FindByEmailAsync(password);
            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                // Yetkileri Belirlememiz lazım.
                Token token = tokenHandler.CreateAccessToken(user,accessTokenLifeTime);
                int refreshTime = accessTokenLifeTime * 20 / 100;
                if (refreshTime <= 5)
                    refreshTime = 5;
                await userService.UpdateRefreshToken(user, token.RefreshToken, token.Expiration, refreshTime);
                return token;
            }
            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Kullanıcı Adı veya Şifre Hatalı.";
            //}
            // return new();
            throw new AuthenticatonErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                Token token = tokenHandler.CreateAccessToken(user);
                await userService.UpdateRefreshToken(user, token.RefreshToken, token.Expiration, 15);
                return token;
            }
            else
                throw new NotFoundUserException();
        }

        public async Task PasswordResetAsnyc(string email)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

                //byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                //resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
                resetToken = resetToken.UrlEncode();

                await mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
            }
        }
        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                //resetToken = Encoding.UTF8.GetString(tokenBytes);
                resetToken = resetToken.UrlDecode();

                return await userManager.VerifyUserTokenAsync(user, userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }
    }
}
