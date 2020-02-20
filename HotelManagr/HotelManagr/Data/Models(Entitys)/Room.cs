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
        public List<string> RoomType { get; set; }
        public bool FreeRoom { get; set; }
        public decimal PricePerAdult { get; set; }
        public decimal PricePerKid { get; set; }
        public int RoomNumber { get; set; }
    }
}
