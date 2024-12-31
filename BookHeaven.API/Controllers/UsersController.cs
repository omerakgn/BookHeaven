using BookHeaven.Core.Features.Commands.AppUser.CreateUser;
using BookHeaven.Core.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHeaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }


        
    }
} 
