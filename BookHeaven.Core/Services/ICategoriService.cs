using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Services
{
    public interface ICategoriService : IService<Categori>
    {
        public Task<CustomResponseDto<CategoriDto>> GetCategoriNamebyCategoriId(int categoriId);    
    }
}
