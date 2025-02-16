using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;

namespace BookHeaven.Core.DTOs
{
    public class ProductImageDto : BaseDto
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public bool Showcase { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
