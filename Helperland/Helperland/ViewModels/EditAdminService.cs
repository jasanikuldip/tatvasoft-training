using System.ComponentModel.DataAnnotations;

namespace Helperland.ViewModels
{
    public class EditAdminService
    {
        public int AddressId { get; set; }

        public int ServiceRequestId { get; set; }

        public string Date { get; set; }

        [Display(Name = "Time", Prompt = "Time")]
        public string StartTime { get; set; }

        [Display(Name = "Street name", Prompt = "Street name")]
        public string AddressLine1 { get; set; }

        [Display(Name = "house number", Prompt = "House number")]
        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [StringLength(20)]
        [Display(Name = "Postal Code", Prompt = "Postal Code")]
        public string PostalCode { get; set; }
        [StringLength(200)]
        [Display(Prompt = "Why do you want to reschedule service request?", Name = "Why do you want to reschedule service request ?")]
        public string Reason { get; set; }
    }
}
