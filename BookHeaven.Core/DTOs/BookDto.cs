using BookHeaven.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.DTOs
{
    public class BookDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string StockCode { get; set; }
        public string Manufacturer { get; set; }
        //public ICollection<CategoriDto> Categories { get; set; }
    }
}
