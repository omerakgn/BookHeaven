using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.UpdateProduct;
using BookHeaven.Core.Models;
using BookHeaven.Core.Services;
using MediatR;

namespace BookHeaven.Service.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _bookService.UpdateAsync(_mapper.Map<Book>(request.bookDto));
            
            var response = new UpdateProductCommandResponse
            {
                Message = "Product updated successfully",
                Success= true,
            };
            return response;
        }
    }
}
