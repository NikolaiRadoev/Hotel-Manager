using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using HotelManagr.Services.Contracts;
using HotelManagr.ViewModels;
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

        public async Task<bool> LogIn(LogInUserViewModel userLog)
        {
            var user = this.GetUser(userLog.UserName).Result;
            if (user==null)
            {
                return false;
            }
            var result = await this.signInManager.PasswordSignInAsync(user, userLog.Password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
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

        public async Task<bool> EditUser(EditUserViewModel editUser)//ne sam siguren
        {
            //throw new NotImplementedException();
            if (editUser.UserName == null ||
                editUser.Password == null ||
                editUser.FirstName == null ||
                editUser.MiddleName == null ||
                editUser.LastName == null ||
                editUser.PersonalNumber == null ||
                editUser.PhoneNumber == null ||
                editUser.Email == null)
                {
                    return false;
                }
            //проверка за коректност на полетата от модела(ready)

            var user = new User
            {
                //poletata ot modela => user(ready)
                UserName = editUser.UserName,
                Password = editUser.Password,
                FirstName = editUser.FirstName,
                MiddleName = editUser.MiddleName,
                LastName = editUser.LastName,
                PersonalNumber = editUser.PersonalNumber,
                PhoneNumber = editUser.PhoneNumber,
                Email = editUser.Email
            };

            var userEditResult = await this.userManager.UpdateAsync(user);

            if (!userEditResult.Succeeded)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
            /*dbContext.Users.ToList();
            dbContext.SaveChanges();*/
            /*var users = await this.userManager.Users.ToList();
            return users;*/
        }

        public async Task<bool> RemoveUserById(RemoveUserViewModel userId)//ne sam siguren
        {
            //throw new NotImplementedException();
            if (userId.Id==null)
            {
                return false;
            }
            var user = new User
            {
                Id = userId.Id
            };
            var userRemove = await this.userManager.DeleteAsync(user);
            return userRemove.Succeeded;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            return user;
        }
// trqbva da ima metod za Rezervations
// trqbva da se opredeli admin
//user views(za rezervaciqta za proverka na  stai clienti)
// admin views(osven tiq na user,za redakciq iztriv i naznachavane na user stai i uslugi(na stai klienti))

//za toq metod na redakciq na potrebitel ne sam opredelil kak shte se otkriva koi potrebitel da se redaktira
        public async void LogOut()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
