﻿using Helperland.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class ServiceRequestViewModel : ServiceRequest
    {
        public int AddressId { get; set; }

        [Required]
        [RegularExpression("^[0-9]{6}", ErrorMessage = "Enter Valid Pincode.")]
        [Display(Prompt = "Postal Code",Name = "Postal Code")]
        public string PincodeCheck { get; set; }

        public bool Extra1 { get; set; }
        public bool Extra2 { get; set; }
        public bool Extra3 { get; set; }
        public bool Extra4 { get; set; }
        public bool Extra5 { get; set; }

        [Required]
        [Display(Name="Date",Prompt ="dd/mm/yyyy")]
        public string StartDate { get; set; }
        public string StartTime { get; set; }
    }
}
