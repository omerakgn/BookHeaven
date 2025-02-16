using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.AddProduct;
using BookHeaven.Core.Features.Commands.DeleteProduct;
using BookHeaven.Core.Features.Commands.DeleteProductImage;
using BookHeaven.Core.Features.Commands.ProductImage.ChangeShowCaseImage;
using BookHeaven.Core.Features.Commands.UpdateProduct;
using BookHeaven.Core.Features.Commands.UploadFile;
using BookHeaven.Core.Features.Queries.GetAllProduct;
using BookHeaven.Core.Features.Queries.GetByIdProduct;
using BookHeaven.Core.Features.Queries.GetProductImages;
using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using BookHeaven.Core.Services.Storage;
using BookHeaven.Service.Features.Commands.DeleteProductImage;
using BookHeaven.Service.Features.Queries.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class BookController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IStorageManager _storageManager;
        private readonly IGenericRepository<Book> _fileRepository;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public BookController(
            IGenericRepository<Book> fileRepo,
            IStorageManager storageManager,
            IMapper mapper, 
            IBookService bookService, 
            IWebHostEnvironment webHostEnvironment, 
            IFileService fileService, 
            IConfiguration configuration,
            IMediator mediator
            )
        {
            _mapper = mapper;
            _bookService = bookService;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _storageManager = storageManager;
            _fileRepository = fileRepo;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductQueryResponse response = await _mediator.Send(new GetAllProductQueryRequest());
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
            
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdProductQueryRequest() {BookId = id });
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();

        }

        [HttpPost]
        [Authorize]
        [Authorize(Policy = "isAdmin")]
        public async Task<IActionResult> Add(BookDto bookDto)
        {

            var response = await _mediator.Send(new AddProductCommandRequest
            {
                bookDto = bookDto,  
            });
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        [Authorize(Policy = "isAdmin")]
        public async Task<IActionResult> Update(BookDto bookdto)
        {
            var response = await _mediator.Send(new UpdateProductCommandRequest { bookDto = bookdto });

            if (response.Success)
            {
                return Ok(response);
            }
            
            return BadRequest();


        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [Authorize(Policy ="isAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteProductCommandRequest() { Id = id });

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();


        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload([FromForm] int id)
        {

            var files = Request.Form.Files;

            // UploadFilesCommand komutunu tetikle
            var command = new UploadFileCommandRequest(id, files);
            var response = await _mediator.Send(command);

            // Sonuç döndür
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);


        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductImages(int id)
        {

             var response = await _mediator.Send(new GetProductImagesQueryRequest() { productId = id });

              if (response.Success)
              {
                  return Ok(response);
              }


              return BadRequest(response.Message);

        }



        [HttpDelete("[action]/{id}/{imageId}")]
        [Authorize]
        [Authorize(Policy = "isAdmin")]
        public async Task<IActionResult> DeleteProductImage(int id,int imageId)
        {

            var response = await _mediator.Send(new DeleteProductImageCommandRequest() { ProductId = id, ImageId= imageId });

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();

        }

        [HttpGet("[action]")]
        [Authorize]
        [Authorize(Policy = "isAdmin")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowCaseImageCommandRequest changeShowCaseImageCommandRequest)
        {
            ChangeShowCaseImageCommandResponse response = await _mediator.Send(changeShowCaseImageCommandRequest);
            return Ok(response);
        }



    }
}
