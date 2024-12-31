using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Queries.GetAllProduct;
using BookHeaven.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace BookHeaven.Service.Features.Queries.GetAllProduct
{

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductQueryHandler> _logger;
        public GetAllProductQueryHandler(IBookService bookservice,IMapper mapper,ILogger<GetAllProductQueryHandler> logger)
        {
            _mapper = mapper;

            _bookService = bookservice;

            _logger = logger;
        }


        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
           
            var books =  _bookService.GetAll(); 
            var totalProductCount = books.Count();
            var booksDto = _mapper.Map<List<BookDto>>(books);

            var response = new GetAllProductQueryResponse
            {
                Books = booksDto,
                Message = "Books retrieved successfully.",
                Success = true,
                TotalProductCount = totalProductCount,
            };

            return response;
        }
    }
}
