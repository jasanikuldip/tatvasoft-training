using System.ComponentModel.DataAnnotations;

namespace Helperland.ViewModels
{
    public class LoginViewModel : ForgotPasswordViewModel
    {
        [Required,EmailAddress(ErrorMessage ="Enter valid Email Address."), Display(Prompt = "Email")]
        public string Email { get; set; }

        [Required,DataType(DataType.Password), Display(Prompt = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        //public string ReturnUrl { get; set; }
    }
}
