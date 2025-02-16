using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using BookHeaven.Core.UnitOfWorks;
using BookHeaven.Repository.UnitOfWorks;
using BookHeaven.Service.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Service.Services
{
    public class UserService : Service<Core.Models.Identity.AppUser>, IUserService
    {
        private readonly UserManager<Core.Models.Identity.AppUser> _userManager;
        private readonly IGenericRepository<Core.Models.Identity.AppUser> _userRepo;
        public UserService(UserManager<Core.Models.Identity.AppUser> userManager, IGenericRepository<Core.Models.Identity.AppUser> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _userManager = userManager;
            _userRepo = repository;
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
