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
        //private UserManager<Client> clientManager;
        //public ClientServices

        //public async Task<bool> CreateNewClient(RegisterClientViewModel newClient)
        //{
        //    //throw new NotImplementedException();
        //    if (newClient.FirstName==null ||
        //        newClient.LastName==null ||
        //        newClient.PhoneNumber==null ||
        //        newClient.Email==null)
        //    {
        //        return false;
        //    }

        //    var client = new Client
        //    {
        //        FirstName = newClient.FirstName,
        //        LastName = newClient.LastName,
        //        PhoneNumber = newClient.PhoneNumber,
        //        Email = newClient.Email,
        //        IsAdult = newClient.IsAdult
        //    };
        //    var createClient=await this.
        //}

        //public Task<bool> DeleteClient(DeleteClientViewModel deleteClient)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> EditClient(EditClientViewModel editClient)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Client> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Client> GetClient(string clientName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
