using Destek.Domain.Entities.Identity;

namespace Destek.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(AppUser appUser,int minute=60);
        string CreateRefreshToken();
    }
}
