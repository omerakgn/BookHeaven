using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public int BookId { get; set; }
    }
}
