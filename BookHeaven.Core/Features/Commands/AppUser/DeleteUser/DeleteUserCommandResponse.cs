using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Features.Commands.AppUser.DeleteUser
{
    public class DeleteUserCommandResponse
    {
        public string Message { get; set; }
        public Boolean Success { get; set; }
    }
}
