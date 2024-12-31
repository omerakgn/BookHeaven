using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.AddProduct;
using BookHeaven.Core.Features.Queries.GetAllProduct;
using BookHeaven.Core.Models;
using BookHeaven.Core.Services;
using MediatR;

namespace BookHeaven.Service.Features.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IBookService bookservice, IMapper mapper)
        {
            _mapper = mapper;

            _bookService = bookservice;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var bookEntity = await _bookService.AddAsync(_mapper.Map<Book>(request.bookDto));
         
            var response = new AddProductCommandResponse
            {
                Books = bookEntity,
                Message = "Book added successfully.",
                Success = true
            };

            return response;
        }
    }
}
