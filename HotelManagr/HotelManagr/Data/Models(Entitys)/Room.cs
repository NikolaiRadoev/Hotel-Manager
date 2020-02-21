using HotelManagr.Data.Models_Entitys_.BaseEtity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class Room : BaseEntity
    {
        public int Capacity { get; set; }
        public string RoomType { get; set; }
        public bool FreeRoom { get; set; }
        public double PricePerAdult { get; set; }
        public double PricePerKid { get; set; }
        public int RoomNumber { get; set; }

        //za vruzka s Room-Reservation     
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
