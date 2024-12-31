using BookHeaven.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        DbSet<T> Table { get; }
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();  
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T Entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
       
    }
}
