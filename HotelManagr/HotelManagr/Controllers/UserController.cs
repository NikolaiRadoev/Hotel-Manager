using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userServices;
        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet]
        public IActionResult CreateNewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewUser(RegisterUserViewModel newUser)
        {
            bool result = userServices.CreateNewUser(newUser).Result;
            if (!result)
            {
                return this.View(newUser);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
