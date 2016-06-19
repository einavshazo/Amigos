using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Lemida_Manage_V2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "הזן שם משתמש בבקשה.")]
        [DataType(DataType.Text)]
        [Display(Name = "שם משתמש")]
        public string Email { get; set; }

        [Required(ErrorMessage = "הזן סיסמה בבקשה.")]
        [StringLength(100, ErrorMessage = " ה{0} צריכה להיות לפחות {2} תווים", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמה")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אימות סיסמה")]
        [Compare("Password", ErrorMessage = " סיסמאות לא תואמות.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="הזן שם בבקשה.")]
        [Display(Name = "שם")]
        public String Name { get; set; }

        [Required(ErrorMessage = "הזן שם משפחה בבקשה.")]
        [Display(Name = "שם משפחה")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "הזן מספר פלאפון בבקשה.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "נייד")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "הזן אי-מייל בבקשה.")]
        [EmailAddress]
        [Display(Name = "מייל")]
        public String Mail { get; set; }

        [Required(ErrorMessage = "בחר מוסד בבקשה.")]
        [Display(Name = "מוסד")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

        [Required(ErrorMessage = "בחר תפקיד בבקשה.")]
        [Display(Name = "תפקיד")]
        public String IdentityRoleID { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }

        [Required(ErrorMessage = "בחר שנת לימוד בבקשה.")]
        [Display(Name = "כיתה")]
        public int YearOfStudyID { get; set; }
        public virtual YearOfStudy YearOfStudy { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
