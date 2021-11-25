using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.ReservationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagr.Services
{
    public class ReservationServices : IReservationServices
    {   
        private readonly ApplicationDbContext context;
        public ReservationServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateReservation(RegisterReservationViewModel createReservation)
        {
        //throw new NotImplementedException();
        Reservation reservation = new Reservation
            {
                ReservedRoom = createReservation.ReservedRoom,
                ClientReservations = createReservation.ClientReservations,
                CheckIn = createReservation.CheckIn,
                CheckOut = createReservation.CheckOut,
                IncludeBreakfast = createReservation.IncludeBreakfast,
                AllInclusive = createReservation.AllInclusive

            };
            this.context.Reservations.Add(reservation);
            this.context.SaveChanges();
            reservation = GetReservation(reservation.Id);
            if (reservation is null)
            {
                return false;
            }
            return true;
        }

        public bool DeleteReservation(DeleteReservationViewModel deleteReservation)
        {
            //throw new NotImplementedException();
            Reservation reservation = context.Reservations.Find(deleteReservation.Id);
            this.context.Reservations.Remove(reservation);
            this.context.SaveChanges();
            return true;
        }

        public bool EditReservation(EditReservationViewModel editReservation)
        {
            //throw new NotImplementedException();
            /*Room room = new Room
            {
                Capacity = editRoom.Capacity,
                RoomType = editRoom.RoomType,
                FreeRoom = editRoom.FreeRoom,
                PricePerAdult = editRoom.PricePerAdult,
                PricePerKid = editRoom.PricePerKid,
                RoomNumber = editRoom.RoomNumber
            };
            this.context.Rooms.Update(room);
            this.context.SaveChanges();
            return true;*/
            /*if (editRoom.Capacity<0 ||
                editRoom.RoomType==null ||
               // editRoom.FreeRoom==null ||
                editRoom.PricePerAdult<0 ||
                editRoom.PricePerKid<0)
            {
                return false;
            }*/

            Reservation reservation = this.context.Reservations.Find(editReservation.Id);

            reservation.ReservedRoom = editReservation.ReservedRoom;
            reservation.ClientReservations = editReservation.ClientReservations;
            reservation.CheckIn = editReservation.CheckIn;
            reservation.CheckOut = editReservation.CheckOut;
            reservation.IncludeBreakfast = editReservation.IncludeBreakfast;
            reservation.AllInclusive = editReservation.AllInclusive;

            this.context.Reservations.Update(reservation);
            this.context.SaveChanges();
            return true;
        }

        public IEnumerable<Reservation> GetAll()
        {
            //throw new NotImplementedException();
            return this.context.Reservations.AsEnumerable();
        }

        public IEnumerable<Reservation> GetAll(Expression<Func<Reservation, bool>> predicate)
        {
            //throw new NotImplementedException();
            return this.context.Reservations.Where(predicate).AsEnumerable();
        }

        public Reservation GetReservation(int id)
        {
            //throw new NotImplementedException();
            return this.context.Reservations.Find(id);
        }

        public Reservation GetReservation(Expression<Func<Reservation, bool>> predicate)
        {
            //throw new NotImplementedException();
            return this.context.Reservations.FirstOrDefault(predicate);
        }
    }
}
