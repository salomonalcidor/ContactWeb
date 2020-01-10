using System;
using System.ComponentModel.DataAnnotations;

namespace ContactWeb.Models
{
    public class Contact
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(ContactWebConstants.MaxFirstNameLength)] 
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(ContactWebConstants.MaxLastNameLength)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        [StringLength(ContactWebConstants.MaxEmailLength)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone number")]
        [StringLength(ContactWebConstants.MaxPhoneLength)]
        public string PhonePrimary { get; set; }

        [Phone(ErrorMessage = "Invalid Phone number")]
        [StringLength(ContactWebConstants.MaxPhoneLength)]
        public string PhoneSecondary { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [StringLength(ContactWebConstants.MaxStreetAddressLength)]
        public string StreetAddress1 { get; set; }
        
        [StringLength(ContactWebConstants.MaxStreetAddressLength)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(ContactWebConstants.MaxCityLength)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }
        
        public virtual State State { get; set; }
        
        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        [StringLength(ContactWebConstants.MaxZipCodeLength, MinimumLength = ContactWebConstants.MinZipCodeLength)] 
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada
        //https://stackoverflow.com/questions/16675176/asp-net-mvc-4-zip-code-validation
        public string Zip { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => string.IsNullOrWhiteSpace(StreetAddress2)
                ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
                : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}";
    }
}