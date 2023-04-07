using MediatR;
using QueryHub.Application.Data_Transfer_Objects.Account;
using QueryHub.Application.Features.Users.Handlers;

namespace QueryHub.Application.Features.Users.Requests.Commands;

public abstract class UserRegistrationCommandRequest : IRequest<UserRegistrationDto>,
    IRequest<HandlerResponse<UserRegistrationDto>>
{
    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Password { get; set; }

    public string? RePassword { get; set; }
}