using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ForgotPasswordResetViewModel
    {
        [Required, DataType(DataType.Password)]
        [StringLength(100)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#$^+-=!*()@%&]).{6,14}$", ErrorMessage = "Password must contain at least 1 capital letter, 1 small letter, 1 number and one special character. Password length must be in between 6 to 14 characters.")]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password", Prompt = "Confirm Password")]
        [NotMapped] // Does not effect with your database
        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
