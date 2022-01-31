using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;

namespace Helperland.ViewModels
{
    public class ContactUsCreateViewModel
    {
        [Required, MaxLength(25), Display(Name = "First Name", Prompt = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(25),Display(Name = "Last Name", Prompt ="Last Name")]
        public string LastName { get; set; }

        [EmailAddress,Required, MaxLength(200),Display(Name ="Email Address" ,Prompt ="Email Address")]
        public string Email { get; set; }
        
        [Required]
        public string Subject { get; set; }

        [Required,RegularExpression("[0-9]{10}",ErrorMessage ="Mobile nuber should be of 10 Digit."),Display(Name ="Mobile Number",Prompt = "Mobile Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Message", Prompt = "Message")]
        public string Message { get; set; }
        public IFormFile UploadFile { get; set; }
    }
}
