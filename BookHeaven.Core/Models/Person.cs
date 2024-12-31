using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Models
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
