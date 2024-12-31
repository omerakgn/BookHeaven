using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using MediatR;

namespace BookHeaven.Core.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public BookDto bookDto { get; set; }
    }

}
