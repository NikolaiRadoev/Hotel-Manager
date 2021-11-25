using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.ViewModels.ReservationViewModel
{
    public class DeleteReservationViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
    }
}
