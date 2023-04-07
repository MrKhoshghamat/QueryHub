using System.ComponentModel.DataAnnotations;
using QueryHub.Domain.Entities.Common;

namespace QueryHub.Domain.Entities.Account;

public class User : BaseEntity
{
    #region ===[ Properties ]=============================================================

    [Display(Name = "نام کاربری")]
    [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    public string? Username { get; set; }

    [Display(Name = "نام")]
    [MaxLength(25, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    public string? FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    public string? LastName { get; set; }

    [Display(Name = "تاریخ تولد")] public DateTime? BirthDate { get; set; }

    [Display(Name = "ایمیل")]
    [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد.")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
    public string? Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
    public string? Password { get; set; }

    [Display(Name = "شماره تماس")]
    [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
    public string? Mobile { get; set; }

    [Display(Name = "آدرس")] public string? Address { get; set; }

    [Display(Name = "بیوگرافی")] public string? Biography { get; set; }

    [Display(Name = "بیوگرافی")] public string? SocialMedia { get; set; }

    public string? EmailConfirmationCode { get; set; }

    public string? SmsconfirmationCode { get; set; }

    public bool? IsEmailConfirmed { get; set; }

    public bool? IsSmsconfirmed { get; set; }

    #endregion

    #region ===[ Relations ]=============================================================

    

    #endregion
}