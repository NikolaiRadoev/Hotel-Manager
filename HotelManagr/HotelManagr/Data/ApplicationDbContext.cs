using System;
using System.Collections.Generic;
using System.Text;
using HotelManagr.Data.Models_Entitys_;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagr.ViewModels.UserViewModel;

namespace HotelManagr.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       // public virtual DbSet<User> Users{ get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }
        
        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //za potvurjdenie za vruzki Edin Kum Mnogo
            //builder.Entity<User>()
            //    .HasMany(u => u.Reservation)
            //    .WithOne(n => n.User)
            //    .HasForeignKey(n => n.UserId);

            builder.Entity<ClientReservation>()
                .HasKey(cr => new { cr.ClientId, cr.ReservationId });

            builder.Entity<ClientReservation>()
                .HasOne(c => c.Client)
                .WithMany(r => r.ClientReservations)
                .HasForeignKey(cr => cr.ClientId);
            
            builder.Entity<ClientReservation>()
                .HasOne(c => c.Reservation)
                .WithMany(r => r.ClientReservations)
                .HasForeignKey(cr => cr.ReservationId);                       
       
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<HotelManagr.ViewModels.UserViewModel.EditUserViewModel> EditUserViewModel { get; set; }
    }
}
