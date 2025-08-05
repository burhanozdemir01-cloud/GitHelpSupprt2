using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Abstractions.Services.Authenticaton
{
    public interface IExternalAuthentication
    {

        Task<DTOs.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);//, 
    }
}
