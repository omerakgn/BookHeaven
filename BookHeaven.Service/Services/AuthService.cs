using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.AppUser.LoginUser;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Core.Services;
using BookHeaven.Core.Services.Token;
using BookHeaven.Service.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Core.Models.Identity.AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly SignInManager<Core.Models.Identity.AppUser> _signInManager;
        public AuthService(UserManager<Core.Models.Identity.AppUser> userManager, ITokenHandler tokenHandler, IUserService userService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _signInManager = signInManager;
        }

        public async Task<TokenDto> LoginAsync(string email, string password, int accessTokenLifeTime)
        {
            Core.Models.Identity.AppUser user = await _userManager.FindByEmailAsync(email);        

            if (user == null)
                throw new NotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) 
            {
                TokenDto token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new AuthenticationErrorException();
        }

        public async Task<TokenDto> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDto token = _tokenHandler.CreateAccessToken(15, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            else
                throw new NotFoundException("Kullanıcı bulunamadı");
        }
    }
}
