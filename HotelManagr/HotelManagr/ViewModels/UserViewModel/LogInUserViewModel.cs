using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.ViewModels.UserViewModel
{
    public class LogInUserViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]/*[Display(Name="Password")]*/
        public string Password { get; set; }
    }
}