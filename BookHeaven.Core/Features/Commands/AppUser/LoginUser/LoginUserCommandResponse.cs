using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;

namespace BookHeaven.Core.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        
    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse 
    {
        public TokenDto tokendto { get; set; }
    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}
