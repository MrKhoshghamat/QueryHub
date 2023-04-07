using System.ComponentModel.DataAnnotations;
using AutoMapper;
using QueryHub.Application.Data_Transfer_Objects.Account;
using QueryHub.Application.Persistence.Contracts;
using QueryHub.Application.Persistence.Contracts.Base;
using QueryHub.Application.Services.Contracts;
using QueryHub.Application.Utilities.Security;
using QueryHub.Domain.Entities.Account;

namespace QueryHub.Application.Services.Implementations;

public class UserService : IUserService
{
    #region ===[ Private Members ]=============================================================

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    #endregion

    #region ===[ Constructor ]=============================================================

    public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    #region ===[ Public Methods ]=============================================================

    #region User Registration

    public async Task<UserRegistrationStatus> RegisterUser(UserRegistrationDto userRegistrationDto)
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(userRegistrationDto);
        if (!Validator.TryValidateObject(userRegistrationDto, context, validationResults, true))
        {
            return UserRegistrationStatus.InvalidData;
        }

        var userNameTaken = userRegistrationDto.Username != null &&
                            await _userRepository.IsExistUserByUserName(userRegistrationDto.Username);

        var emailTaken = userRegistrationDto.Email != null &&
                         await _userRepository.IsExistUserByEmail(userRegistrationDto.Email);

        var mobileTaken = userRegistrationDto.Mobile != null &&
                          await _userRepository.IsExistUserByMobile(userRegistrationDto.Mobile);

        if (userNameTaken)
        {
            return UserRegistrationStatus.UserNameHasTaken;
        }

        if (emailTaken)
        {
            return UserRegistrationStatus.EmailHasTaken;
        }

        if (mobileTaken)
        {
            return UserRegistrationStatus.MobileHasTaken;
        }

        if (userRegistrationDto is { Password: { }, RePassword: { } })
        {
            if (userRegistrationDto.Password == userRegistrationDto.RePassword)
            {
                PasswordHelper.HashPassword(userRegistrationDto.Password);
            }
        }

        var user = _mapper.Map<User>(userRegistrationDto);

        await _userRepository.Insert(user);

        await _unitOfWork.SaveChangesAsync();
        
        return UserRegistrationStatus.Succeed;
    }

    #endregion

    #endregion
}