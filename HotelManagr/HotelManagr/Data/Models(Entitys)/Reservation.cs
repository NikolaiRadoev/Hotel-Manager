using HotelManagr.Data.Models_Entitys_.BaseEtity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class Reservation : BaseEntity
    {

//za vruzka sus staq
        public int RoomId { get; set; }
        public virtual Room ReservedRoom { get; set; }

 //Za vruzka s client

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }
 //spisuk s klienti koito shte se pomeshtavat v staqta
        
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool IncludeBreakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Bills { get; set; }

        //Za vruzkata mejdu Usera i Rezervaciqta
        public string UserId { get; set; }
        public virtual User User { get; set;}

       
    }
}
