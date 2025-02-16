using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookHeaven.Core.Features.Commands.AppUser.DeleteUser;
using BookHeaven.Core.Services;
using MediatR;

namespace BookHeaven.Service.Features.Commands.AppUser.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(request.Id);
            if (user == null)
            {

                var _response = new DeleteUserCommandResponse
                {
                    Message = "Kullanıcı bulunamadı!",
                    Success = false
                };
                return _response;
            }
            await _userService.RemoveAsync(user);
            var response = new DeleteUserCommandResponse
            {
                Message = "Kullanıcı başarıyla silindi!",
                Success = true
            };
            return response;
        }
    }
}
