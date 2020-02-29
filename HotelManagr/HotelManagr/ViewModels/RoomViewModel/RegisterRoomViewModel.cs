using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.ViewModels.RoomViewModel
{
    public class RegisterRoomViewModel
    {
        [Required]
        [Display(Name="Capacity")]
        public int Capacity { get; set; }
        [Required]
        [Display(Name = "RoomType")]
        public string RoomType { get; set; }
        [Required]
        [Display(Name = "FreeRoom")]
        public bool FreeRoom { get; set; }
        [Required]
        [Display(Name = "PricePerAdult")]
        public double PricePerAdult { get; set; }
        [Required]
        [Display(Name = "PricePerKid")]
        public double PricePerKid { get; set; }
        [Required]
        [Display(Name = "RoomNumber")]
        public int RoomNumber { get; set; }
    }
}
