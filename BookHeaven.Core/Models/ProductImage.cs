using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Models
{
    public class ProductImage : File
    {
        public bool Showcase { get; set; }
        public ICollection<Book> Books { get; set; }
       
    }
}
