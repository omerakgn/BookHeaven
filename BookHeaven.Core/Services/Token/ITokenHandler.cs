using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models.Identity;

namespace BookHeaven.Core.Services.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute, AppUser user);
        string CreateRefreshToken();
    }
}
