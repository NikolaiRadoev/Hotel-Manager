using System;
using System.Collections.Generic;
using System.Text;
using HotelManagr.Data.Models_Entitys_;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagr.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users{ get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasMany(u => u.Reservation)
                .WithOne(n => n.User)
                .HasForeignKey(f => f.UserId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
