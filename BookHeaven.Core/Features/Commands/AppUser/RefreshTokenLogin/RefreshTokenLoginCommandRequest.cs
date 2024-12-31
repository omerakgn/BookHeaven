using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandRequest :IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
