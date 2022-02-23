using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Email Address", Prompt = "Email Address")]
        [Remote(action: "IsRegistredEmail", controller:"home")]
        public string EmailForgot { get; set; }
    }
}
