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
            
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);
            
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> {new (ClaimTypes.Name, user.UserName)}

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
