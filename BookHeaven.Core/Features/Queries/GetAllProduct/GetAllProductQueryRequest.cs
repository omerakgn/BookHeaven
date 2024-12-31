using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest: IRequest<GetAllProductQueryResponse>
    {
        public int Page {  get; set; }
        public int Size { get; set; }
    }
}
