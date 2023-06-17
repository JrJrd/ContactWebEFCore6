using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    internal class Contact
    {
        [Key]  
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(ContactManagerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Lasr Name is required.")]
        [StringLength(ContactManagerConstants.MAX_LAST_NAME_LENGTH)]

        public string LastName { get; set; }
        [Display(Name = "EMAIL Address")]
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(ContactManagerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage = "wrong format")]
        public string Email { get; set; }
        [Display(Name = "PHONE number")]
        [Required(ErrorMessage = "PHONE is required.")]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "wrong format")]
        public string PhonePrimary { get; set; }
        [Display(Name = "Home/Office number")]
        [Required(ErrorMessage = "PHONE is required.")]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "wrong format")]
        public string PhoneSecondary { get; set; }

        [Display(Name = "St Address Line 1")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "St Address Line 2")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public virtual State State { get; set; }
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is Required")]

        [StringLength(ContactManagerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }


        [Required(ErrorMessage = "Zip is required")]
        [Display(Name = "Zip Code")]
        [StringLength(ContactManagerConstants.MAX_CITY_LENGTH, MinimumLength = ContactManagerConstants.MIN_ZIP_CODE_LENGTH)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")]
        public string Zip { get; set; }
 // US or Canada

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = " User ID is required")]
        [DataType(DataType.Date)]
        public string UserId { get; set; }
      

        public string FriendlyName => $"{FirstName} {LastName}";
        [Display(Name = "FullName")]
        public DateTime Birthday { get; set; }

        

        /* public string FriendlyAddress
           {
               get
               {
                   if (State is null)
                   {
                       return "";
                   }
                   else
                   {
                       if (string.IsNullOrWhiteSpace(StreetAddress1))
                       {
                           return $"{City}, {State.Abberviation}, {Zip}";
                       }
                       else
                       {
                           if (string.IsNullOrWhiteSpace(StreetAddress2))
                           {
                               return $"{StreetAddress1}, {City}, {State.Abberviation}, {Zip}";
                           }
                           else
                           {
                               return $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abberviation}, {Zip}";
                           }
                       }
                   }
               }
           }*/
        [Display(Name = "Address")]
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abberviation}, {Zip}" :
                                                                string.IsNullOrWhiteSpace(StreetAddress2)
                                                                       ? $"{StreetAddress1}, {City},{State.Abberviation}, {Zip}"
                                                                       : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abberviation}, {Zip}";
        

    }
}
