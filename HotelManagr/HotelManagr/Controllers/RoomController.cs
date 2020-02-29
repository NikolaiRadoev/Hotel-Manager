using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.RoomViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Controllers
{

   // [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IRoomServices roomServices;
        public RoomController(ApplicationDbContext context, IRoomServices roomServices)
        {
            this.context = context;
            this.roomServices = roomServices;
        }

              
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterRoomViewModel newRoom)
        {
            bool result = roomServices.CreateNewRoom(newRoom);
            if (!result)
            {
                return View(newRoom);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(EditRoomViewModel editRoom)
        {
            bool result = roomServices.EditRoom(editRoom);
            if (!result)
            {
                return View(editRoom);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(DeleteRoomViewModel deleteRoom)
        {
            bool result = roomServices.DeleteRoom(deleteRoom);
            if (!result)
            {
                return View(deleteRoom);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpGet]
        public IActionResult DetailsForClient(int id)
        {
            Room room = this.roomServices.GetRoom(id);
            return View();
        }
        [HttpGet]
        public IActionResult DetailsForAllClients()
        {
            var client = this.roomServices.GetAll();//ne sam siguren
            return View();
        }
    }
}
