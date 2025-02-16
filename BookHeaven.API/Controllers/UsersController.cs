using BookHeaven.Core.Features.Commands.AppUser.CreateUser;
using BookHeaven.Core.Features.Commands.AppUser.DeleteUser;
using BookHeaven.Core.Features.Commands.AppUser.LoginUser;
using BookHeaven.Core.Features.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("[action]")]
        [Authorize]
        [Authorize(Policy = "isAdmin")]
        public async Task<IActionResult> GetAllUsers() 
        {
            GetAllUsersQueryResponse response = await _mediator.Send(new GetAllUsersQueryRequest());
            return Ok(response);
        }


        [HttpDelete("[action]/{id}")]
        [Authorize]
        [Authorize(Policy = "isAdmin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            DeleteUserCommandResponse response = await _mediator.Send(new DeleteUserCommandRequest { Id= id});
            return Ok(response);
        }

        
    }
} 
