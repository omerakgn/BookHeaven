using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Services
{
    public interface IService<T> where T : BaseEntity
    {
       
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T Entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<CustomResponseDto<T>> RemoveAsync(T entity); 
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        void Update(T entity);
    }
}
