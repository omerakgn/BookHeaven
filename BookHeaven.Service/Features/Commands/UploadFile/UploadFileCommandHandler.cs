using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BookHeaven.Core.Features.Commands.UploadFile;
using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services.Storage;
using BookHeaven.Core.Services;
using BookHeaven.Service.Services.Storage;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookHeaven.Service.Features.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommandRequest, UploadFileCommandResponse>
    {
        private readonly IFileService _fileService;
        private readonly IStorageManager _storageManager;
        private readonly IBookService _bookService;
        
        public UploadFileCommandHandler(IFileService fileService, IStorageManager storageManager, IBookService bookService)
        {
            _fileService = fileService;
            _storageManager = storageManager;
            _bookService = bookService;
        }

        public async Task<UploadFileCommandResponse> Handle(UploadFileCommandRequest request, CancellationToken cancellationToken)
        {

            var datas = await _storageManager.GetStorage().UploadAsync("resource/book-images", request.Files);

            //var datas = await _storageManager.GetStorage("azure").UploadAsync("files", Request.Form.Files);

            Book book = await _bookService.GetByIdAsync(request.id);

            await _fileService.AddRangeAsync(datas.Select(d => new Core.Models.ProductImage()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Books = new List<Core.Models.Book>() { book }

            }).ToList());

            var response = new UploadFileCommandResponse
            {
                Success = true,
                Message = "File uploaded successfully"
            };

            return response;
        }
    }
}
