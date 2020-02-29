using HotelManagr.Data;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.ClientViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IClientServices clientServices;
        public ClientController(ApplicationDbContext context,IClientServices clientServices)
        {
            this.context = context;
            this.clientServices = clientServices;
        }

        [HttpGet]
        public IActionResult Register()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Register(RegisterClientViewModel newClient)
        {
            bool result = clientServices.CreateNewClient(newClient).Result;
            if (!result)
            {
                return View(newClient);
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
        public IActionResult Edit(EditClientViewModel editClient)
        {
            bool result = clientServices.EditClient(editClient).Result;
            if (!result)
            {
                return View(editClient);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
