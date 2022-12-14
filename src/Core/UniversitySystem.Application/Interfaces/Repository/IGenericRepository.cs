using System.Linq.Expressions;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Application.Interfaces.Repostory
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes);
        Task<T> GetByIdAsync(int id, params string[] includes);
        Task<T> GetByExpression(Expression<Func<T, bool>> expression, params string[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity, bool status = true);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}