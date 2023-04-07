using System.ComponentModel.DataAnnotations;
using QueryHub.Application.Data_Transfer_Objects.Common;

namespace QueryHub.Application.Data_Transfer_Objects.Account;

public abstract class UserRegistrationDto : BaseDto
{
    public string? Username { get; set; }
    
    public string? Email { get; set; }
    
    public string? Mobile { get; set; }
    
    public string? Password { get; set; }
    
    public string? RePassword { get; set; }
}

public enum UserRegistrationStatus
{
    Succeed,
    InvalidData,
    UserNameHasTaken,
    EmailHasTaken,
    MobileHasTaken
}