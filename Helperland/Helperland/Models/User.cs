using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Helperland.Models
{
    [Table("User")]
    [Index(nameof(Email), Name = "UQ_User_Email", IsUnique = true)]
    [Index(nameof(Mobile), Name = "UQ_User_Mobile", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            FavoriteAndBlockedTargetUsers = new HashSet<FavoriteAndBlocked>();
            FavoriteAndBlockedUsers = new HashSet<FavoriteAndBlocked>();
            RatingRatingFromNavigations = new HashSet<Rating>();
            RatingRatingToNavigations = new HashSet<Rating>();
            ServiceRequestServiceProviders = new HashSet<ServiceRequest>();
            ServiceRequestUsers = new HashSet<ServiceRequest>();
            UserAddresses = new HashSet<UserAddress>();
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name", Prompt = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name", Prompt = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        [Remote(action: "IsEmailInUse", controller:"Home")]
        [Display(Name = "Email Address", Prompt = "Email Address")]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        [StringLength(100)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#$^+-=!*()@%&]).{6,14}$",ErrorMessage = "Password must contain at least 1 capital letter, 1 small letter, 1 number and one special character. Password length must be in between 6 to 14 characters.")]
        [Display(Name = "Password", Prompt = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password", Prompt = "Confirm Password")]
        [NotMapped] // Does not effect with your database
        [Required, DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(20)]
        [Remote(action: "IsMobileInUse", controller: "Home")]
        [RegularExpression("^[0-9]{10}",ErrorMessage ="Enter Valid Mobile number.")]
        [Display(Name = "Mobile number", Prompt = "Mobile number")]
        public string Mobile { get; set; }
        public int UserTypeId { get; set; }
        public int? Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(200)]
        public string UserProfilePicture { get; set; }
        public bool IsRegisteredUser { get; set; }
        [StringLength(200)]
        public string PaymentGatewayUserRef { get; set; }
        [StringLength(20)]
        public string ZipCode { get; set; }
        public bool WorksWithPets { get; set; }
        public int? LanguageId { get; set; }
        public int? NationalityId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? Status { get; set; }
        [StringLength(100)]
        public string BankTokenId { get; set; }
        [StringLength(50)]
        public string TaxNo { get; set; }

        [InverseProperty(nameof(FavoriteAndBlocked.TargetUser))]
        public virtual ICollection<FavoriteAndBlocked> FavoriteAndBlockedTargetUsers { get; set; }
        [InverseProperty(nameof(FavoriteAndBlocked.User))]
        public virtual ICollection<FavoriteAndBlocked> FavoriteAndBlockedUsers { get; set; }
        [InverseProperty(nameof(Rating.RatingFromNavigation))]
        public virtual ICollection<Rating> RatingRatingFromNavigations { get; set; }
        [InverseProperty(nameof(Rating.RatingToNavigation))]
        public virtual ICollection<Rating> RatingRatingToNavigations { get; set; }
        [InverseProperty(nameof(ServiceRequest.ServiceProvider))]
        public virtual ICollection<ServiceRequest> ServiceRequestServiceProviders { get; set; }
        [InverseProperty(nameof(ServiceRequest.User))]
        public virtual ICollection<ServiceRequest> ServiceRequestUsers { get; set; }
        [InverseProperty(nameof(UserAddress.User))]
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
