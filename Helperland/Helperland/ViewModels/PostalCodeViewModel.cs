using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class PostalCodeViewModel
    {
        [Required]
        [RegularExpression("^[0-9]{6}", ErrorMessage = "Enter Valid Pincode.")]
        [Display(Prompt = "Postal Code", Name = "Postal Code")]
        public string PincodeCheck { get; set; }
    }
}
