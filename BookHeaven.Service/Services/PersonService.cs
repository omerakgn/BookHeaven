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
    internal class PersonService : Service<Person>, IPersonService
    {
        private readonly IGenericRepository<Person> _personRepository;
        public PersonService(IGenericRepository<Person> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _personRepository = repository;
        }

        public Task<CustomResponseDto<PersonDto>> GetPersonAndGroupsbyPersonId(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
