using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.ClientViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Services
{

    public class ClientServices : IClientServices
    {
        private readonly ApplicationDbContext context;
        public ClientServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateNewClient(RegisterClientViewModel newClient)
        {
            //throw new NotImplementedException();
            if (newClient.FirstName==null ||
                newClient.LastName==null ||
                newClient.PhoneNumber==null ||
                newClient.Email==null)
            {
                return false;
            }

            var client = new Client
            {
                FirstName = newClient.FirstName,
                LastName = newClient.LastName,
                PhoneNumber = newClient.PhoneNumber,
                Email = newClient.Email,
                IsAdult = newClient.IsAdult
            };
            await this.context.AddAsync(client);
            context.SaveChanges();
            return true;
        }

        public Task<bool> DeleteClient(DeleteClientViewModel deleteClient)
        {
            throw new NotImplementedException();
            /*var clientn = new Client()
            { Id = deleteClient.Id };
            context.Clients.Remove(clientn);
            context.SaveChanges();
            return true;*/

        }

        public async Task<bool> EditClient(EditClientViewModel editClient)
        {
            //throw new NotImplementedException();
            if (editClient.FirstName==null ||
                editClient.LastName==null ||
                editClient.PhoneNumber==null ||
                editClient.Email==null)
            {
                return false;
            }
            var client = new Client()
            {
                FirstName = editClient.FirstName,
                LastName = editClient.LastName,
                PhoneNumber = editClient.PhoneNumber,
                Email = editClient.Email,
                IsAdult = editClient.IsAdult
            };
            this.context.Update(client);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Client> GetAll()
        {
            //throw new NotImplementedException();
            return this.context.Clients.AsEnumerable<Client>();
        }

        public Task<Client> GetClient(string clientName)
        {
            throw new NotImplementedException();
            //var client = this.context.Find(clientName);
        }
    }
}
