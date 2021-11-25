using HotelManagr.Data.Models_Entitys_;
using HotelManagr.ViewModels.ReservationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagr.Services.Contracts
{
    public interface IReservationServices
    {
        public bool CreateReservation(RegisterReservationViewModel createReservation);
        public bool EditReservation(EditReservationViewModel editReservation);
        IEnumerable<Reservation> GetAll();
        public IEnumerable<Reservation> GetAll(Expression<Func<Reservation, bool>> predicate);
        Reservation GetReservation(int id);
        Reservation GetReservation(Expression<Func<Reservation, bool>> predicate);
        bool DeleteReservation(DeleteReservationViewModel deleteReservation);
    }
}
