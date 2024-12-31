using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;

namespace BookHeaven.Core.Features.Queries.GetProductImages
{
    public class GetProductImagesQueryResponse
    {
        public ICollection<ProductImageDto> ProductImage { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
