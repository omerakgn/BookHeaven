using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;

namespace BookHeaven.Core.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public List<BookDto> Books { get; set; }
        public string Message { get; set; } 
        public bool Success { get; set; }
        public int TotalProductCount { get; set; }
    }
}
