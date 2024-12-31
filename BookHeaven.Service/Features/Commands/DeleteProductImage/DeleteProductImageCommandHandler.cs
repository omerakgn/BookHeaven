using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.Features.Commands.DeleteProductImage;
using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BookHeaven.Service.Features.Commands.DeleteProductImage
{

    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
    {
        private readonly IBookService _bookService;
        private readonly IGenericRepository<Book> _fileRepository;
        private readonly IFileService _fileService;
        public DeleteProductImageCommandHandler(IBookService bookService, IGenericRepository<Book> fileRepo, IFileService fileService)
        {
            _bookService = bookService;
            _fileRepository = fileRepo;
            _fileService = fileService;
        }


        public async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            Book? product = await _fileRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(request.ProductId));

            Core.Models.ProductImage? productImage = product.ProductImages.FirstOrDefault(p => p.Id == request.ImageId);

            await _fileService.RemoveAsync(productImage);
            
            var response = new DeleteProductImageCommandResponse
            {
                Message= "Image deleted successfully",
                Success= true,
            };
            return response;
        }
    }
}


