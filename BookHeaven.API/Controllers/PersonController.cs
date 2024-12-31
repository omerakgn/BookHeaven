using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;
using BookHeaven.Core.Services;
using BookHeaven.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHeaven.API.Controllers
{
    public class PersonController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;     

        public PersonController(IMapper mapper, IPersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            var personDto = _mapper.Map<PersonDto>(person);

            return CreateActionResult(CustomResponseDto<PersonDto>.Success(200,personDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonDto personDto)
        {
            var personEntity = await _personService.AddAsync(_mapper.Map<Person>(personDto));
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(201, _mapper.Map<PersonDto>(personEntity)));
        }
    }
}
