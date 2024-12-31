using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Queries.GetByIdProduct;
using BookHeaven.Core.Features.Queries.GetProductImages;
using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Service.Features.Queries.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, GetProductImagesQueryResponse>
    {
        private readonly IGenericRepository<Book> _fileRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public GetProductImagesQueryHandler(IGenericRepository<Book> fileRepo,IBookService bookService)
        {
            _fileRepository = fileRepo;
            _bookService = bookService;


        }
        public async Task<GetProductImagesQueryResponse> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Book product = await _fileRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == request.productId);

            if (product == null)
            {
                return null;
            }

             var images= product.ProductImages?.Select(p => new ProductImageDto
            {
                 
                 FileName = p.FileName,
                 id = p.Id,
                 Path = p.Path

             }).ToList();
            
            var response = new GetProductImagesQueryResponse
            {
                
                ProductImage = images,
                Message = "images retrieved successfully",
                Success = true

            };

            return response;
        }
    }
}
