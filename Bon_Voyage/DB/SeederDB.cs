using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB
{
    public class SeederDB
    {

        public static void SeedRoles(EFDbContext context, UserManager<DbUser> userManager,
            RoleManager<DbRole> roleManager)
        {
            if (context.Roles.Count() == 0)
            {
                var roleName = "Client";
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

                roleName = "Manager";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

                roleName = "Admin";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

            }
        }

        public static void SeedUsers(EFDbContext context, UserManager<DbUser> userManager,
            RoleManager<DbRole> roleManager)
        {
            var roleName = "Client";
            
            if(context.Users.Count() == 0)
            {
                //----------------#1--------------------

                ClientProfile clientProfile = new ClientProfile
                {
                    Name = "Vlad",
                    Surname = "Montana",
                    DateOfBirth = new DateTime(2002, 7, 5)
                };

                DbUser dbUser = new DbUser
                {
                    Email = "client@gmail.com",
                    UserName = "Chuck",
                    ClientProfile = clientProfile
                };

                var res = userManager.CreateAsync(dbUser, "Qwerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;



                //----------------#2--------------------

                clientProfile = new ClientProfile
                {
                    Name = "Moe",
                    Surname = "Szyslak",
                    DateOfBirth = new DateTime(1978, 2, 13)
                };

                dbUser = new DbUser
                {
                    Email = "client2@gmail.com",
                    UserName = "Dowww",
                    ClientProfile = clientProfile
                };

                res = userManager.CreateAsync(dbUser, "Qwerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;




                //----------------#3--------------------

                roleName = "Manager";

                clientProfile = new ClientProfile
                {
                    Name = "Lena",
                    Surname = "Golovach",
                    DateOfBirth = new DateTime(1998, 11, 24)
                };

                dbUser = new DbUser
                {
                    Email = "manager@gmail.com",
                    UserName = "Dowww",
                    ClientProfile = clientProfile
                };

                res = userManager.CreateAsync(dbUser, "Qwerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;




                //----------------#4--------------------
                roleName = "Admin";

                clientProfile = new ClientProfile
                {
                    Name = "Joe",
                    Surname = "Weider",
                    DateOfBirth = new DateTime(1967, 8, 23)
                };

                dbUser = new DbUser
                {
                    Email = "admin@gmail.com",
                    UserName = "GOD",
                    ClientProfile = clientProfile
                };

                res = userManager.CreateAsync(dbUser, "Qwerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;

            }
        }

        public static void SeedCountries(EFDbContext context)
        {
            if (context.Country.Count() == 0)
            {
                var countries = new List<Country>();

                countries.Add(new Country { Name = "Egypt" });
                countries.Add(new Country { Name = "Turkey" });
                countries.Add(new Country { Name = "Greece" });
                countries.Add(new Country { Name = "Spain" });
                countries.Add(new Country { Name = "UAE" });

                countries.Add(new Country { Name = "Sri Lanka" });
                countries.Add(new Country { Name = "Italy" });
                countries.Add(new Country { Name = "France" });
                countries.Add(new Country { Name = "Georgia" });
                countries.Add(new Country { Name = "Cuba" });

                context.AddRange(countries);
                context.SaveChanges();
            }
        }

        public static void SeedCities(EFDbContext context)
        {
            if (context.Cities.Count() == 0)
            {
                var countries = context.Country.ToList();
                var cities = new List<City>();
                string id = string.Empty;

                //-------------------Egypt---------------------
                id = countries.FirstOrDefault(x => x.Name == "Egypt").Id;

                cities.Add(new City
                {
                    Name = "Hurghada",
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Sharm El-Sheikh", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Hurghada", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Safaga",
                    CountryId = id
                });


                //-------------------Turkey---------------------
                id = countries.FirstOrDefault(x => x.Name == "Turkey").Id;
                cities.Add(new City
                {
                    Name = "Hurghada",
                    CountryId = id
                });




            }
        }

        public static void SeedAirports(EFDbContext context)
        {
            if (context.Airports.Count() == 0)
            {

            }
        }

        public static void SeedHotels(EFDbContext context)
        {
            if (context.Hotels.Count() == 0)
            {

            }
        }
        

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();


                SeederDB.SeedRoles(context,manager,managerRole);
                SeederDB.SeedUsers(context,manager,managerRole);
            }

        }
    }
}
