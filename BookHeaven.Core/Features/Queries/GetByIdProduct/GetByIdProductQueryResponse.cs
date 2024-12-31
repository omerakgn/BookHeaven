using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;

namespace BookHeaven.Core.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public BookDto Book { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
