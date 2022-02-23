using Helperland.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class MyDetailsViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name", Prompt = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name", Prompt = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Enter Valid Mobile number.")]
        [Display(Name = "Mobile number", Prompt = "Mobile number")]
        public string Mobile { get; set; }

        public int Day { get; set; }
        public Months Months { get; set; }
        public int Year { get; set; }
    }
}
