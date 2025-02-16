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
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookHeaven.Service.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public GetByIdProductQueryHandler(IBookService bookservice, IMapper mapper, IGenericRepository<Book> repository)
        {
            _mapper = mapper;
            _bookService = bookservice;
            _repository = repository;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        { 

            Book product = await _repository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == request.BookId);

            var bookDto = _mapper.Map<BookDto>(product);

            if (product == null)
            {
                return null;
            }


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
