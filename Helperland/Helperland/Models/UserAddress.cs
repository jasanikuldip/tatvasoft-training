using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Helperland.Models
{
    [Table("UserAddress")]
    public partial class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Street name",Prompt = "Street name")]
        public string AddressLine1 { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "House number", Prompt = "House number")]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Postal Code", Prompt = "Postal Code")]
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Phone number", Prompt = "Phone number")]
        public string Mobile { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserAddresses")]
        public virtual User User { get; set; }
    }
}
