using HotelManagr.Data.Models_Entitys_;
using HotelManagr.ViewModels;
using HotelManagr.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Services.Contracts
{
    public interface IUserServices
    {
        IEnumerable<User> GetAll();
        Task<bool> CreateNewUser(RegisterUserViewModel newUser);
        //string EditUser(int/*string*/ id, User userEdit);
        Task<bool> EditUser(EditUserViewModel editUser);
        Task<bool> RemoveUserById(RemoveUserViewModel userId);
        Task<User> GetUserByName(string username);
        Task<User> GetUserById(string id);
        Task<bool> LogIn(LogInUserViewModel userLog);
        void LogOut();
    }
}
