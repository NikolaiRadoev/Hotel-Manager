using HotelManagr.Data.Models_Entitys_.BaseEtity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class Reservation : BaseEntity
    {
        public int ReservedRoomId { get; set; }

        public int ClientReservator { get; set; }
        //spisuk s klienti koito shte se pomeshtavat v staqta
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public decimal Bills { get; set; }

        //Za vruzkata mejdu Usera i Rezervaciqta
        public int UserId { get; set; }
        public virtual User User { get; set;
        }
    }
}
