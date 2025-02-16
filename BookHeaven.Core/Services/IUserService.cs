using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;
using BookHeaven.Core.Models.Identity;

namespace BookHeaven.Core.Services
{
    public interface IUserService : IService<Core.Models.Identity.AppUser>
    {
        Task UpdateRefreshToken (string refreshToken,AppUser user, DateTime accessTokenDate ,int addOnAccessTokenDate);
    }
}
