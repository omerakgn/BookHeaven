using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest :IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
