﻿using BookHeaven.Core.Models;
using BookHeaven.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
;       }

        public async Task AddAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
         
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

       
    }
}
