using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class LoginViewModel
    {
        [Required,EmailAddress(ErrorMessage ="Enter valid Email Address."), Display(Prompt = "Email")]
        public string Email { get; set; }

        [Required,DataType(DataType.Password), Display(Prompt = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        //public string ReturnUrl { get; set; }

        //[Required]
        //[StringLength(100)]
        //[Remote(action: "IsRegistredEmail", controller: "Home")]
        //[Display(Name = "Email Address", Prompt = "Email Address")]
        //public string EmailForgot { get; set; }

    }
}
