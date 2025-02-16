using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Models
{
    public class Comment : BaseEntity
    {
        public int BookId { get; set; } 
        public string UserName { get; set; }
        public string Content { get; set; }
        public Book Book { get; set; }
    }
}
