using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Core.Models.Identity
{
    public class AppUser : IdentityUser<string>
    {
        
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
   
         

    }
}
