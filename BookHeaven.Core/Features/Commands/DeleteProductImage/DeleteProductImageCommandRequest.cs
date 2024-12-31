using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandRequest : IRequest<DeleteProductImageCommandResponse>
    {
        public int ProductId { get; set; }
        public int ImageId { get; set; }
    }
}
