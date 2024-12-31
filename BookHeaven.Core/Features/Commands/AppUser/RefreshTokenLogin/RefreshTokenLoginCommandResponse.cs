using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;

namespace BookHeaven.Core.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public TokenDto tokendto { get; set; }
    }
}
