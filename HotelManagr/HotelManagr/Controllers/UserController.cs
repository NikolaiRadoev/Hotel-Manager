using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels;
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
        public IActionResult Register()
        {
            //moje bi trqqbva da se inicializira VIEWMODELA
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel newUser)
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
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(EditUserViewModel editUser)
        {
            bool result = userServices.EditUser(editUser).Result;
            if (!result)
            {
                return this.View(editUser);
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
        public IActionResult Delete(RemoveUserViewModel removeUser)
        {
            bool result = userServices.RemoveUserById(removeUser).Result;
            if (!result)
            {
                return this.View(removeUser);
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInUserViewModel userLogIn)
        {
            bool result = userServices.LogIn(userLogIn).Result;
            if (!result)
            {
                return this.View(userLogIn);
            }
            else
            {
                return Redirect("/");
            }
        }


        [HttpGet]
        public IActionResult LogOut()//za post metod ne sam siguren
        {
            return Redirect("/");//View();
        }
        
        //GetAll
        //moje bi i GetUser
    }
}
