using QueryHub.Application.Persistence.Contracts.Base;
using QueryHub.Domain.Entities.Account;

namespace QueryHub.Application.Persistence.Contracts;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsExistUserByUserName(string userName);
    Task<bool> IsExistUserByEmail(string email);
    Task<bool> IsExistUserByMobile(string mobile);
}