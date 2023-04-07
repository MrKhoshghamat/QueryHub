using QueryHub.Application.Services.Contracts;

namespace QueryHub.Application.Persistence.Contracts.Base;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    Task<IUserService> GetUserService();
    Task SaveChangesAsync();
}