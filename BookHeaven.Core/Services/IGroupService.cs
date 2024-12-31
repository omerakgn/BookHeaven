using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Services
{
    public interface IGroupService : IService<Group>
    {
        public Task<CustomResponseDto<GroupDto>> GetGroupNamebyGroupId( int groupid );
    }
}
