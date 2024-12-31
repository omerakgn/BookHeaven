using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Queries.GetProductImages
{
    public class GetProductImagesQueryRequest : IRequest<GetProductImagesQueryResponse>
    {
        public int productId { get; set; }
    }
}
