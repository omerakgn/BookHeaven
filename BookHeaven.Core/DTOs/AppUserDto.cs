using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.DTOs
{
    public class AppUserDto : BaseDto
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
      
    }
}
