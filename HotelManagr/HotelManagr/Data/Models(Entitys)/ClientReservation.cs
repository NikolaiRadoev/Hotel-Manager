using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class ClientReservation
    {
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
