using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;
using MediatR;

namespace BookHeaven.Core.Features.Commands.AddProduct
{
    public class AddProductCommandRequest: IRequest<AddProductCommandResponse>
    {
        public BookDto bookDto { get; set; }
    }
}
