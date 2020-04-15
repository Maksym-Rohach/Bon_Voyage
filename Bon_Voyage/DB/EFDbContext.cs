using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB
{
    public class EFDbContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
    DbUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
        
        public DbSet<BaseProfile> BaseProfiles { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<BlockedProfile> BlockedProfiles { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }
        public DbSet<ManagerProfile> ManagerProfiles { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<PhotosToHotel> PhotosToHotels { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Comfort> Comforts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);           

            #region ClientProfile
            builder.Entity<ClientProfile>()
                .HasMany(x => x.Tickets)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId);
            builder.Entity<ClientProfile>()
                .HasOne(x => x.BaseProfile)
                .WithOne(x => x.ClientProfile)
                .HasForeignKey<ClientProfile>(x => x.Id);
            #endregion

            #region AdminProfile
            builder.Entity<AdminProfile>()
                .HasOne(x => x.BaseProfile)
                .WithOne(x => x.AdminProfile)
                .HasForeignKey<AdminProfile>(x => x.Id);
            #endregion

            #region ManagerProfile
            builder.Entity<ManagerProfile>()
                .HasOne(x => x.BaseProfile)
                .WithOne(x => x.ManagerProfile)
                .HasForeignKey<ManagerProfile>(x => x.Id);
            #endregion

            #region BlockedProfile
            builder.Entity<BlockedProfile>()
                .HasOne(x => x.BaseProfile)
                .WithOne(x => x.BlockedProfile)
                .HasForeignKey<BlockedProfile>(x => x.Id);
            #endregion

            #region City
            builder.Entity<City>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId);
            #endregion

            #region Hotel
            builder.Entity<Hotel>()
                .HasOne(x => x.City)
                .WithMany(x => x.Hotels);
            builder.Entity<Hotel>()
                .HasMany(x => x.PhotosToHotels)
                .WithOne(x => x.Hotel)
                .HasForeignKey(x => x.HotelId);
            #endregion

            #region Airport
            builder.Entity<Airport>()
                .HasOne(x => x.City)
                .WithMany(x=>x.Airports)
                .HasForeignKey(x=>x.CityId);
            #endregion
            #region Ticket
            builder.Entity<Ticket>()
                .HasOne(x => x.Airport)
                .WithOne(x => x.Ticket);
            builder.Entity<Ticket>()
                .HasOne(x => x.Hotel)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x=>x.HotelId);
            builder.Entity<Ticket>()
                .HasOne(x => x.RoomType)
                .WithOne(x => x.Ticket);
            #endregion

            #region TicketsToComforts
            builder.Entity<TicketsToComforts>()
                .HasOne(x => x.Ticket)
                .WithMany(x => x.TicketToComforts)
                .HasForeignKey(x => x.TicketId);
            builder.Entity<TicketsToComforts>()
                .HasOne(x => x.Comfort)
                .WithMany(x => x.TicketToComforts)
                .HasForeignKey(x => x.ComfortId);
            #endregion

        }

    }
}
