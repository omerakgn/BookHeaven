using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Queries.GetAllProduct;
using BookHeaven.Core.Features.Queries.GetByIdProduct;
using BookHeaven.Core.Models;
using BookHeaven.Core.Services;
using MediatR;

namespace BookHeaven.Service.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public GetByIdProductQueryHandler(IBookService bookservice, IMapper mapper)
        {
            _mapper = mapper;

            _bookService = bookservice;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetByIdAsync(request.BookId);
            var bookDto = _mapper.Map<BookDto>(book);

            var response = new GetByIdProductQueryResponse
            {
                Book = bookDto,
                Message = "Book retrieved successfully.",
                Success = true
            };

            return response;
        }
    }
}
