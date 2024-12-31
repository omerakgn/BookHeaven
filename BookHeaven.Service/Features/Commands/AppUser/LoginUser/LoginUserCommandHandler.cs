using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.AppUser.LoginUser;
using BookHeaven.Core.Services;
using BookHeaven.Core.Services.Token;
using BookHeaven.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Service.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {   
        private readonly UserManager<Core.Models.Identity.AppUser> _userManager;
        private readonly SignInManager<Core.Models.Identity.AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(
            UserManager<Core.Models.Identity.AppUser> userManager,
            SignInManager<Core.Models.Identity.AppUser> signInManager, 
            ITokenHandler tokenHandler, 
            IUserService userService,
            IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password, 9);
            return new LoginUserSuccessCommandResponse()
            {
                tokendto = token
            };
        }
    }
}
