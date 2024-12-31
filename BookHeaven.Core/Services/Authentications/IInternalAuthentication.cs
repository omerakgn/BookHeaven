using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<DTOs.TokenDto> LoginAsync(string email, string password, int accessTokenLifeTime);
        Task<DTOs.TokenDto> RefreshTokenLoginAsync(string refreshToken);
    }
}
