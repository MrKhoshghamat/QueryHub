using System.Linq.Expressions;

namespace QueryHub.Application.Persistence.Contracts.Base;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAll();
    Task<IReadOnlyList<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter);
    Task<IQueryable<TEntity>> GetAllAsQueryable();
    Task<IQueryable<TEntity>> GetAllAsQueryable(Expression<Func<TEntity, bool>>? filter);
    Task<TEntity?> GetById(object? id);
    Task Insert(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task Delete(object id);
}