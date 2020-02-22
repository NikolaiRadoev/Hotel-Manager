using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Services
{
    public class UserServices : IUserServices
    {
        /*private readonly ApplicationDbContext dbContext;

        public UserServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }*/
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserServices(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> CreateNewUser(RegisterUserViewModel newUser)
        {
            if (newUser.UserName==null ||
                newUser.Password==null ||
                newUser.FirstName == null ||
                newUser.MiddleName == null ||
                newUser.LastName == null ||
                newUser.PersonalNumber == null ||
                newUser.PhoneNumber == null ||
                newUser.Email == null)
            {
                return false;
            }
            //проверка за коректност на полетата от модела(ready)

            var user = new User
            {
                //poletata ot modela => user(ready)
                UserName = newUser.UserName,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                MiddleName = newUser.MiddleName,
                LastName = newUser.LastName,
                PersonalNumber = newUser.PersonalNumber,
                PhoneNumber = newUser.PhoneNumber,
                Email = newUser.Email
            };

            var userCreateResult = await this.userManager.CreateAsync(user, newUser.Password);

            if (!userCreateResult.Succeeded)
            {
                return false;
            }
            return true;
        }

        public string EditUser(int/*string*/ id, User userEdit)
        {
            throw new NotImplementedException();
            
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
            /*dbContext.Users.ToList();
            dbContext.SaveChanges();*/
            /*var users = await this.userManager.Users.ToList();
            return users;*/

        }

        public string RemoveUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
