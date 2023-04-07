using AutoMapper;
using QueryHub.Application.Data_Transfer_Objects.Account;
using QueryHub.Application.Features.Users.Requests.Commands;
using QueryHub.Domain.Entities.Account;

namespace QueryHub.Application.Profiles;

public class MappingProfile : Profile
{
    #region ===[ Constructor ]=============================================================

    public MappingProfile()
    {
        CreateMap<User, UserRegistrationDto>().ReverseMap();
        CreateMap<UserRegistrationCommandRequest, UserRegistrationDto>().ReverseMap();
    }

    #endregion
}