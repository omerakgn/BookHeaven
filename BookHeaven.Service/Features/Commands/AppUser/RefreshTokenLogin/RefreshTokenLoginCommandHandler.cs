using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.AppUser.RefreshTokenLogin;
using BookHeaven.Core.Services;
using MediatR;

namespace BookHeaven.Service.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        readonly IAuthService _authService;
        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDto token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            return new()
            {
                tokendto = token
            };
        }
    }
}
