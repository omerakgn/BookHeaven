using BookHeaven.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.DTOs
{
    public class PersonDto : BaseDto
    {
        public string Name { get; set; }
       
        public ICollection<Group> Groups { get; set; }
    }
}
