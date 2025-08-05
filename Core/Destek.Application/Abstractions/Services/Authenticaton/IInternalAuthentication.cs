using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Abstractions.Services.Authenticaton
{
    public interface IInternalAuthentication
    {
        Task<DTOs.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);//, int accessTokenLifeTime
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
