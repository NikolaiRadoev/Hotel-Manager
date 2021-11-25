using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.ReservationViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IReservationServices reservationServices;
        public ReservationController(ApplicationDbContext context,IReservationServices reservationServices)
        {
            this.context = context;
            this.reservationServices = reservationServices;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterReservationViewModel registerReservation)
        {
            bool result = reservationServices.CreateReservation(registerReservation);
            if (!result)
            {
                return View(registerReservation);
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Room roomForEdit = this.context.Rooms.Find(id);
            Reservation reservation = reservationServices.GetReservation(id);
            EditReservationViewModel model = new EditReservationViewModel
            {
                Id=reservation.Id,
                ReservedRoom=reservation.ReservedRoom,
                ClientReservations=reservation.ClientReservations,
                CheckIn=reservation.CheckIn,
                CheckOut=reservation.CheckOut,
                IncludeBreakfast=reservation.IncludeBreakfast,
                AllInclusive=reservation.AllInclusive
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditReservationViewModel editReservation)
        {
            bool result = reservationServices.EditReservation(editReservation);
            if (!result)
            {
                return View(editReservation);
            }
            else
            {
                return Redirect("/");
            }
        }

        public IActionResult Delete(DeleteReservationViewModel deleteReservation)
        {
            bool result = reservationServices.DeleteReservation(deleteReservation);
            if (!result)
            {
                return View(deleteReservation);
            }
            else
            {
                return Redirect("/");
            }
        }

        public IActionResult All()
        {
            List<Reservation> Reservations = reservationServices.GetAll().ToList();
            List<EditReservationViewModel> model = Reservations.Select(n => new EditReservationViewModel
            {
                Id = n.Id,
                ReservedRoom = n.ReservedRoom,
                ClientReservations = n.ClientReservations,
                CheckIn = n.CheckIn,
                CheckOut = n.CheckOut,
                IncludeBreakfast = n.IncludeBreakfast,
                AllInclusive = n.AllInclusive
            }).ToList();
            return View(model);
        }
    }
}
