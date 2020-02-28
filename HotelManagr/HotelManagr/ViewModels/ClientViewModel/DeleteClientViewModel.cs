using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.ViewModels.ClientViewModel
{
    public class DeleteClientViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
