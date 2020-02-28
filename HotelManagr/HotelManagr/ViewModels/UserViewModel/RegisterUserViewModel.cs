using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.ViewModels.UserViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name="Personal Number")]
        public string PersonalNumber { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Admin Or Not")]
        public bool IsAdministrator { get; set; }

        [Required]
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
       /* //trq da napravq da dava greshki ako ima takiva danni
        [Required]
        [DataType(DataType.Text,ErrorMessage="Error found in FirstName")]
        [MaxLength(20)]
        public string FirstLastMiddle Egn {get;set;}
        otgore
        */
    }
}
