using HotelManagr.Data.Models_Entitys_.BaseEtity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Data.Models_Entitys_
{
    public class User : IdentityUser
    {
        public User(): base()
        {
            this.Reservation = new HashSet<Reservation>();
        }
        //public int UserId { get; set; }
        //public string UserName { get; set; }

        public string Password { get; set; }//pisheshe se na drugo mqsto

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        //public string PhoneNumber { get; set; }

        //public string Email { get; set; }

        public DateTime StartUpData { get; set; }

        public bool ActiveOrNotActiveAccount { get; set; }

        public DateTime FreeFromWorkUser { get; set; }
        //admin


        //public int ReservationId { get; set; }

        public virtual ICollection<Reservation>Reservation {get;set;}
    }
}
