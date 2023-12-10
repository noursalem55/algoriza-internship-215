using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Enum;

namespace Vezeeta.Repo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<DoctorAppointmentTimes> DoctorAppointmentTimes { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Specialize> Specializes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            RegisterModel(builder);
            //builder.Entity<IdentityRole>().HasData(SeedRoles());
            builder.Entity<ApplicationUser>().HasData(SeedDataForAdmin());
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "1", // RoleId for Admin
            //        UserId = "2" // User Id for the default user
            //    }
            //);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        protected void RegisterModel(ModelBuilder modelBuilder)
        {
            // for handle cascade
            #region ApplicationUsers
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.DoctorBookings).WithOne(e => e.Doctor).HasForeignKey(e => e.DoctorID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.PatientBookings).WithOne(e => e.Patient).HasForeignKey(e => e.PatientID).OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Booking
            modelBuilder.Entity<Booking>()
              .HasOne(b => b.Doctor)
             .WithMany(d => d.DoctorBookings)
             .HasForeignKey(b => b.DoctorID)
             .HasPrincipalKey(d => d.ID);
            //modelBuilder.Entity<Booking>()
            //    .Property(b => b.FinalPrice)
            //    .HasColumnType("decimal(18, 2)");
            //modelBuilder.Entity<Booking>()
            //        .HasOne(b => b.Doctor)
            //        .WithMany(d => d.DoctorBookings)
            //        .HasForeignKey(b => b.DoctorID)
            //        .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Booking>()
            //    .HasOne(b => b.Patient)
            //    .WithMany(p => p.PatientBookings)
            //    .HasForeignKey(b => b.PatientID)
            //    .OnDelete(DeleteBehavior.Restrict); // Example of configuring the Patient relationship

            //modelBuilder.Entity<Booking>()
            //    .HasOne(b => b.DiscountCode)
            //    .WithMany()
            //    .HasForeignKey(b => b.DiscountCodeID)
            //    .OnDelete(DeleteBehavior.SetNull);
            #endregion
            #region DiscountCode
            modelBuilder.Entity<DiscountCode>().HasMany(e => e.Bookings).WithOne(e => e.DiscountCode).HasForeignKey(e => e.ID).OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region DoctorAppointment
            modelBuilder.Entity<DoctorAppointment>().HasMany(e => e.DoctorAppointmentTimes).WithOne(e => e.DoctorAppointment).HasForeignKey(e => e.DoctorAppointmentID).OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Specialize
            modelBuilder.Entity<Specialize>().HasMany(e => e.Doctors).WithOne(e => e.Specialize).HasForeignKey(e => e.SpecializeID).OnDelete(DeleteBehavior.Restrict);
            #endregion

        }
        //private List<IdentityRole> SeedRoles()
        //{
        //    return new List<IdentityRole>
        //    {
        //        new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
        //        new IdentityRole { Id = "2", Name = "Doctor", NormalizedName = "DOCTOR" },
        //        new IdentityRole { Id = "3", Name = "Patient", NormalizedName = "PATIENT" }
        //    };
        //}

        private ApplicationUser SeedDataForAdmin()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            return new ApplicationUser
            {
                ID= 1,
                Email = "admin@example.com",
                FirstName = "Admin",
                Image="1.png",
                Phone="011225445",
                LastName = "User",
                Password="admin",
                IsAdmin=true,
                AccountType = AccountType.Admin.ToString()

            };
        }
    }
}
