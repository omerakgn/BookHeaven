using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using BookHeaven.Core.Features.Commands.AddProduct;
using BookHeaven.Core.Features.Commands.DeleteProduct;
using BookHeaven.Core.Services;
using BookHeaven.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookHeaven.Service.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IBookService bookService, IMapper mapper) 
        {
            _mapper = mapper;

            _bookService = bookService;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetByIdAsync(request.Id);

            if (book == null)
            {               
                var Response = new DeleteProductCommandResponse
               {
                    Books = null,
                    Message="Book is not found",
                    Success=false,
                };
                return Response;
            }


            await _bookService.RemoveAsync(book);

            var response = new DeleteProductCommandResponse
            {
                Books = book,
                Message = "Book deleted successfully.",
                Success = true
            };

            return response;

        }
    }
}
