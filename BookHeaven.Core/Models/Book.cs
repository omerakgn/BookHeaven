using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string StockCode { get; set; }
        public string Manufacturer { get; set; }
        public ICollection<Categori> Categories { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
