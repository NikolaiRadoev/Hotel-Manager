using HotelManagr.Data.Models_Entitys_;
using HotelManagr.ViewModels.ClientViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagr.Services.Contracts
{
    public interface IClientServices
    {
        public bool CreateNewClient(RegisterClientViewModel newClient);
        public bool EditClient(EditClientViewModel editClient);
        IEnumerable<Client> GetAll();
        public IEnumerable<Client> GetAll(Expression<Func<Client, bool>> predicate);
        Client GetClient(int id);
        Client GetClient(Expression<Func<Client, bool>> predicate);
        bool DeleteClient(DeleteClientViewModel deleteClient);
    }
}
