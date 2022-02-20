using System.ComponentModel.DataAnnotations;

namespace Helperland.ViewModels
{
    public class LoginViewModel : ForgotPasswordViewModel
    {
        [Required,EmailAddress(ErrorMessage ="Enter valid Email Address."), Display(Name = "Email", Prompt = "Email")]
        public string EmailLogin { get; set; }

        [Required,DataType(DataType.Password), Display(Name = "Password", Prompt = "Password")]
        public string PasswordLogin { get; set; }
        public bool RememberMe { get; set; }
        //public string ReturnUrl { get; set; }
    }
}
