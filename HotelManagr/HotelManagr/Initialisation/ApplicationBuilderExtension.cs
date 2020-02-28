using HotelManagr.Data;
using HotelManagr.Data.Models_Entitys_;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagr.Initialisation
{
    public static class ApplicationBuilderExtension
    {

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();

                if (!db.Roles.AnyAsync().Result)
                {
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                    Task.Run(async () =>
                    {
                        var adminRole = GlobalConstants.AdminRole;
                        var userRole = GlobalConstants.UserRole;

                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminRole
                        });

                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = userRole
                        });
                    }).Wait();

                    User user = new User
                    {
                        UserName = "Admin",
                        FirstName = "Admin1",
                        MiddleName = "Admin2",
                        LastName = "Admin3",
                        Email = "admin@admin.bg",
                        IsAdministrator = true,
                        ActiveOrNotActiveAccount = true,
                        PersonalNumber = "0000000000",
                        Reservation = new HashSet<Reservation>()
                    };

                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                    string pass = "Admin";
                    Task.Run(async () =>
                    {
                        await userManager.CreateAsync(user, pass);
                        await userManager.AddToRoleAsync(user, "Admin");
                    }).Wait();
                }
            }

            return app;
        }
    }
}
