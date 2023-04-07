using AutoMapper;
using MediatR;
using QueryHub.Application.Data_Transfer_Objects.Account;
using QueryHub.Application.Features.Users.Requests.Commands;
using QueryHub.Application.Persistence.Contracts.Base;

namespace QueryHub.Application.Features.Users.Handlers.Commands;

public class
    UserRegistrationCommandRequestHandler : IRequestHandler<UserRegistrationCommandRequest,
        HandlerResponse<UserRegistrationDto>>
{
    #region ===[ Private Members ]=============================================================

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    #endregion

    #region ===[ Constructor ]=============================================================

    public UserRegistrationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    #region ===[ Handler ]=============================================================

    public async Task<HandlerResponse<UserRegistrationDto>> Handle(UserRegistrationCommandRequest request,
        CancellationToken cancellationToken)
    {
        var userService = await _unitOfWork.GetUserService();

        var userRegistrationDto = _mapper.Map<UserRegistrationDto>(request);

        var userRegistrationResult = await userService.RegisterUser(userRegistrationDto);

        return userRegistrationResult switch
        {
            UserRegistrationStatus.Succeed => new HandlerResponse<UserRegistrationDto>(true, false,
                "User registration is succeed", userRegistrationDto),
            UserRegistrationStatus.InvalidData => new HandlerResponse<UserRegistrationDto>(false, true,
                "User registration has returned invalid data", userRegistrationDto),
            UserRegistrationStatus.UserNameHasTaken => new HandlerResponse<UserRegistrationDto>(false, false,
                "UserName has taken", userRegistrationDto),
            UserRegistrationStatus.EmailHasTaken => new HandlerResponse<UserRegistrationDto>(false, false,
                "Email has taken", userRegistrationDto),
            UserRegistrationStatus.MobileHasTaken => new HandlerResponse<UserRegistrationDto>(false, false,
                "Mobile has taken", userRegistrationDto),
            _ => new HandlerResponse<UserRegistrationDto>(false, false, "Unknown user registration error",
                userRegistrationDto)
        };
    }

    #endregion
}