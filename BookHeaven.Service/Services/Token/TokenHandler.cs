using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Core.Services.Token;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookHeaven.Service.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int minute , AppUser user)
        {
            TokenDto token = new();
            
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);
            
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);

            JwtSecurityToken securityToken = new(
                audience: _configuration["Jwt:Audience"],
                issuer: _configuration["Jwt:Issuer"],
                expires: token.Expiration,
                signingCredentials: signingCredentials,
                 claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role)
                    }

                );  

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
           
        }
    }
}
