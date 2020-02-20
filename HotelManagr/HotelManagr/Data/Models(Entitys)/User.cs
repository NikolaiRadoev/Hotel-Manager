using HotelManagr.Data.Models_Entitys_.BaseEtity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Reservation = new HashSet<Reservation>();
        }
        //public int UserId { get; set; }
        public string Usename { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime StartUpData { get; set; }

        public bool ActiveOrNotActiveAccount { get; set; }

        public DateTime FreeFromWorkUser { get; set; }

        //public int ReservationId { get; set; }

        public virtual ICollection<Reservation>Reservation {get;set;}
    }
}
