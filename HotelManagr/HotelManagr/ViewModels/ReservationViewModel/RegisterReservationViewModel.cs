using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelManagr.Data.Models_Entitys_;

namespace HotelManagr.ViewModels.ReservationViewModel
{
    public class RegisterReservationViewModel
    {
        public virtual Room ReservedRoom { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }
    }
}
