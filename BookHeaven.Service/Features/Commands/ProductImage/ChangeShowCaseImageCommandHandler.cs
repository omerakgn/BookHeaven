using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.ProductImage.ChangeShowCaseImage;
using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Service.Features.Commands.ProductImage
{
    public class ChangeShowCaseImageCommandHandler : IRequestHandler<ChangeShowCaseImageCommandRequest, ChangeShowCaseImageCommandResponse>
    {
        private readonly IGenericRepository<Core.Models.ProductImage> _fileRepository;
        private readonly IFileService _fileService;
        public ChangeShowCaseImageCommandHandler(IGenericRepository<Core.Models.ProductImage> fileRepository,IFileService fileService)
        {
            _fileRepository = fileRepository;
            _fileService = fileService;
        }

        public async Task<ChangeShowCaseImageCommandResponse> Handle(ChangeShowCaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = _fileRepository.Table
                .Include(p => p.Books)
                .SelectMany(p => p.Books, (pif, p) => new
                {
                    pif,
                    p

                });
           
       
            var showCasedImage = await query.FirstOrDefaultAsync(p => p.p.Id.ToString() == request.productId && p.pif.Showcase);

            if (showCasedImage != null) {
                showCasedImage.pif.Showcase = false;
                _fileRepository.Update(showCasedImage.pif);
            }

            var image = await query.FirstOrDefaultAsync(p => p.pif.Id.ToString() == request.imageId);

            if (image != null) { 
                image.pif.Showcase = true;
                _fileRepository.Update(image.pif);
            }



            return new();

        }
    }
}
