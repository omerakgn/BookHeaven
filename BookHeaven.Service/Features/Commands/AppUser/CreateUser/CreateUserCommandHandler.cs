using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.Features.Commands.AppUser.CreateUser;
using BookHeaven.Core.Models;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Service.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Service.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<Core.Models.Identity.AppUser> _userManager;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(UserManager<Core.Models.Identity.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           // var user= _mapper.Map<Core.Models.Identity.AppUser>(request);

            
            IdentityResult result = await _userManager.CreateAsync(new (){
            
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                UserName = request.Email,
            }, request.Password);

            
            CreateUserCommandResponse response = new() { Success = result.Succeeded };

            if (result.Succeeded)
            {
                return new()
                {
                    Success= true,
                    Message = "Kullanıcı başarıyla oluşturulmuştur.",
                };

            }
            else
            {
                foreach (var item in result.Errors) {

                    response.Message += $"{item.Description}"; 
                }
                return response;
            }
        }
    }
}
