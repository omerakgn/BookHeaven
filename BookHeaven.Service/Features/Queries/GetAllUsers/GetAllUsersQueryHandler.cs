using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Queries.GetAllUsers;
using BookHeaven.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookHeaven.Service.Features.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        public GetAllUsersQueryHandler(IUserService userService, IMapper mapper, ILogger<GetAllUsersQueryHandler> logger)
        {
            _mapper = mapper;

            _userService = userService;

            _logger = logger;
        }

        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _userService.GetAll();
           
       
            //var userdto = _mapper.Map<List<AppUserDto>>(users);

            var response = new GetAllUsersQueryResponse
            {
                Users = users,
                Message = "Users retrieved successfully.",
                Success = true,
              
            };

            return await Task.FromResult(response);
        }
    }
}
