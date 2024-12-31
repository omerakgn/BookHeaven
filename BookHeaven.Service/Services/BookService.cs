using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using BookHeaven.Core.Services;
using BookHeaven.Core.UnitOfWorks;
using BookHeaven.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _bookRepository = repository;
        }

        public Task<CustomResponseDto<BookDto>> GetBookAndCategoriesByBookId(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
