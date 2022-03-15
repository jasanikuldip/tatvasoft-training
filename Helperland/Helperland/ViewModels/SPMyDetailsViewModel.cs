using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.ViewModels
{
    public class SPMyDetailsViewModel : MyDetailsViewModel
    {
        public int? Gender { get; set; }

        [Required]
        public int? UserProfilePicture { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Street name", Prompt = "Street name")]
        public string AddressLine1 { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "House number", Prompt = "House number")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Postal Code", Prompt = "Postal Code")]
        public string PostalCode { get; set; }

        public int? AddressId { get; set; }
    }
}
