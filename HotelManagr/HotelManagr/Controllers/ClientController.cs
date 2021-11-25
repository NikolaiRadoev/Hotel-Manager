using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
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
            bool result = clientServices.CreateNewClient(newClient);
            if (!result)
            {
                return View(newClient);
            }
            else
            {
                return Redirect("/Client/All/");
            }
        }
        [HttpGet]
        public IActionResult Edit( int id)
        {
            Client clientForEdit = this.context.Clients.Find(id);
            EditClientViewModel model = new EditClientViewModel
            {
                Id = clientForEdit.Id,
                FirstName = clientForEdit.FirstName,
                LastName = clientForEdit.LastName,
                PhoneNumber = clientForEdit.PhoneNumber,
                Email = clientForEdit.Email,
                IsAdult = clientForEdit.IsAdult,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditClientViewModel editClient)
        {
            bool result = clientServices.EditClient(editClient);
            if (!result)
            {
                return View(editClient);
            }
            else
            {
                return Redirect("/Client/All/");
            }
        }
        public IActionResult Delete(DeleteClientViewModel deleteClient)
        {
            bool result = clientServices.DeleteClient(deleteClient);
            if (!result)
            {
                return View(deleteClient);
            }
            else
            {
                return Redirect("/Client/All/");
            }
        }
        [HttpGet]
        public IActionResult DetailsForClient(int id)
        {
            Client client = this.clientServices.GetClient(id);

            // client => view model
            return View();
        }
        [HttpGet]
        public IActionResult DetailsForAllClients()
        {
            var client = this.clientServices.GetAll();//ne sam siguren
            return View();
        }

        public IActionResult All()
        {
            List<Client> Clients = clientServices.GetAll().ToList();
            List<EditClientViewModel> model = Clients.Select(q => new EditClientViewModel
            {
                Id = q.Id,
                FirstName = q.FirstName,
                LastName = q.LastName,
                PhoneNumber = q.PhoneNumber,
                Email = q.Email,
                IsAdult = q.IsAdult
            }).ToList();
            return View(model);
        }
    }
}
