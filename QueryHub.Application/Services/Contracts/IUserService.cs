using QueryHub.Application.Data_Transfer_Objects.Account;

namespace QueryHub.Application.Services.Contracts;

public interface IUserService
{
    Task<UserRegistrationStatus> RegisterUser(UserRegistrationDto userRegistrationDto);
}