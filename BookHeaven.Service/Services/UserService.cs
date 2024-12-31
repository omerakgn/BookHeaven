using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Core.Services;
using BookHeaven.Service.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Core.Models.Identity.AppUser> _userManager;
        public UserService(UserManager<Core.Models.Identity.AppUser> userManager) 
        {
            _userManager = userManager;
        }
        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTime)
        {
            
            if (user != null) 
                {
                    user.RefreshToken = refreshToken;
                    user.RefreshTokenEndDate = accessTokenDate.AddMinutes(refreshTokenLifeTime);
                    await _userManager.UpdateAsync(user);
                
                }
            else 
                 throw new NotFoundException("Kullanıcı bulunamadı");
                
        }
    }
}
