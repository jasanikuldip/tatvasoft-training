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
        [Remote(action: "IsRegistredEmail", controller: "Home")]
        [Display(Name = "Email Address", Prompt = "Email Address")]
        public string Email { get; set; }
    }
}
