using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Application.Interfaces.Repostory;
using UniversitySystem.Domain.Entities.Base;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly UniversityDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(UniversityDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> value = expression is not null ? _dbSet.Where(expression) : _dbSet.AsQueryable();
            if (includes.Length != 0)
            {
                foreach (string include in includes)
                {
                    value = value.Include(include);
                }
            }
            return await value.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            T value = await _dbSet.FirstOrDefaultAsync(v => v.Id == id);
            if (includes.Length != 0)
            {
                foreach (string include in includes)
                {
                    value = await _dbSet.Include(include).FirstOrDefaultAsync(v => v.Id == id);
                }
            }
            return value;
        }
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(T entity, bool status = true)
        {
            if (status)
            {
                _dbSet.Attach(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Unchanged;
            }
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
