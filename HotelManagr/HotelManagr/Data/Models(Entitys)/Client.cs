using HotelManagr.Data.Models_Entitys_.BaseEtity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class Client : BaseEntity
    {
        //public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool AdultOrNot { get; set; }

        //spisuk s rezervacii
       // public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
