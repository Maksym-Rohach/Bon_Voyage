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

            if (context.Users.Count() == 0)
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
                    Email = "client1@gmail.com",
                    UserName = "client1@gmail.com",
                    ClientProfile = clientProfile
                };

                var res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
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
                    UserName = "client2@gmail.com",
                    ClientProfile = clientProfile
                };

                res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;



                //----------------#3--------------------

                roleName = "Manager";

                ManagerProfile managerProfile = new ManagerProfile
                {
                    Name = "Lena",
                    Surname = "Golovach",
                    DateOfRegister = DateTime.Now,
                    State = true,
                    Salary = 1480
                };

                dbUser = new DbUser
                {
                    Email = "manager@gmail.com",
                    UserName = "manager@gmail.com",
                    ManagerProfile = managerProfile
                };

                res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;



                //----------------#4--------------------

                roleName = "Admin";

                AdminProfile adminProfile = new AdminProfile
                {
                    Name = "Joe",
                    Surname = "Weider",
                };

                dbUser = new DbUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    Admin = adminProfile
                };

                res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;

            }
        }

        public static void SeedCountries(EFDbContext context)
        {
            if (context.Country.Count() == 0)
            {
                var countries = new List<Country>();

                countries.Add(new Country { Name = "Єгипт" });
                countries.Add(new Country { Name = "Туреччина" });
                countries.Add(new Country { Name = "Греція" });
                countries.Add(new Country { Name = "Іспанія" });
                countries.Add(new Country { Name = "ОАЕ" });

                countries.Add(new Country { Name = "Шрі Ланка" });
                countries.Add(new Country { Name = "Італія" });
                countries.Add(new Country { Name = "Франція" });
                countries.Add(new Country { Name = "Грузія" });
                countries.Add(new Country { Name = "Куба" });

                context.AddRange(countries);
                context.SaveChanges();
            }
        }

        public static void SeedCities(EFDbContext context)
        {
            // Count: 32

            if (context.Cities.Count() == 0)
            {
                var countries = context.Country.ToList();
                var cities = new List<City>();
                string id = string.Empty;

                //-------------------Egypt---------------------
                id = countries.FirstOrDefault(x => x.Name == "Єгипт").Id;

                cities.Add(new City
                {
                    Name = "Хургада",
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Шарм-еш-Шейх", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Хургада", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Сафага",
                    CountryId = id
                });


                //-------------------Turkey---------------------
                id = countries.FirstOrDefault(x => x.Name == "Туреччина").Id;
                cities.Add(new City
                {
                    Name = "Аланія", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Анкара", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Мармарис",
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Бодрум",
                    CountryId = id
                });


                //-------------------Grecce---------------------
                id = countries.FirstOrDefault(x => x.Name == "Греція").Id;
                cities.Add(new City
                {
                    Name = "Афіни", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Касторія",
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Наксос",
                    CountryId = id
                });


                //-------------------Spain---------------------
                id = countries.FirstOrDefault(x => x.Name == "Іспанія").Id;
                cities.Add(new City
                {
                    Name = "Барселона", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Мадрид", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Валенсія", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Севілья", // *Airport
                    CountryId = id
                });


                //-------------------ОАЕ---------------------
                id = countries.FirstOrDefault(x => x.Name == "ОАЕ").Id;
                cities.Add(new City
                {
                    Name = "Дубаї", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Абу-Дабі", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Шарджі",
                    CountryId = id
                });






                //-------------------Shri Lanka---------------------
                id = countries.FirstOrDefault(x => x.Name == "Шрі Ланка").Id;
                cities.Add(new City
                {
                    Name = "Коломбо", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Когалла",
                    CountryId = id
                });


                //-------------------Italy---------------------
                id = countries.FirstOrDefault(x => x.Name == "Італія").Id;
                cities.Add(new City
                {
                    Name = "Рим", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Венеція", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Флоренція", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Верона", // *Airport
                    CountryId = id                    
                });


                //-------------------France---------------------
                id = countries.FirstOrDefault(x => x.Name == "Франція").Id;
                cities.Add(new City
                {
                    Name = "Ліон", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Орлі", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Париж",
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Бордо",
                    CountryId = id
                });


                //-------------------George---------------------
                id = countries.FirstOrDefault(x => x.Name == "Грузія").Id;
                cities.Add(new City
                {
                    Name = "Батумі", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Тбілісі",
                    CountryId = id
                });


                //-------------------Cuba---------------------
                id = countries.FirstOrDefault(x => x.Name == "Куба").Id;
                cities.Add(new City
                {
                    Name = "Варадеро", // *Airport
                    CountryId = id
                });
                cities.Add(new City
                {
                    Name = "Гавана",
                    CountryId = id
                });


                context.AddRange(cities);
                context.SaveChanges();
            }
        }

        public static void SeedAirports(EFDbContext context)
        {
            // Count: 20

            if (context.Airports.Count() == 0)
            {
                var cities = context.Cities.ToList();
                var airoports = new List<Airport>();
                string id = string.Empty;




                //-------------------Egypt---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Шарм-еш-Шейх").Id;
                airoports.Add(new Airport
                {
                    Name = "Sharm El Sheikh International Airport",
                    ShortName = "SSH",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Хургада").Id;
                airoports.Add(new Airport
                {
                    Name = "Hurghada International Airport",
                    ShortName = "HRG",
                    CityId = id
                });


                //-------------------Turkey---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Аланія").Id;
                airoports.Add(new Airport
                {
                    Name = "Gazipasa Alanya Airport",
                    ShortName = "GZP",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Анкара").Id;
                airoports.Add(new Airport
                {
                    Name = "Ankara Esenboga Airport",
                    ShortName = "ESB",
                    CityId = id
                });


                //-------------------Grecce---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Афіни").Id;
                airoports.Add(new Airport
                {
                    Name = "Athens International Airport",
                    ShortName = "ATH",
                    CityId = id
                });


                //-------------------Spain---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Барселона").Id;
                airoports.Add(new Airport
                {
                    Name = "Josep Tarradellas Barcelona-El Prat Airport",
                    ShortName = "BCN",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Мадрид").Id;
                airoports.Add(new Airport
                {
                    Name = "Madrid-Barajas Adolfo Suárez Airport",
                    ShortName = "MAD",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Валенсія").Id;
                airoports.Add(new Airport
                {
                    Name = "Valencia Airport",
                    ShortName = "VLC",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Севілья").Id;
                airoports.Add(new Airport
                {
                    Name = "Seville Airport",
                    ShortName = "SVQ",
                    CityId = id
                });

                //-------------------OAE---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Дубаї").Id;
                airoports.Add(new Airport
                {
                    Name = "Dubai International Airport",
                    ShortName = "DXB",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Абу-Дабі").Id;
                airoports.Add(new Airport
                {
                    Name = "Abu Dhabi International Airport",
                    ShortName = "AUH",
                    CityId = id
                });





                //-------------------Shri Lanka---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Коломбо").Id;
                airoports.Add(new Airport
                {
                    Name = "Bandaranaike International Airport",
                    ShortName = "CMB",
                    CityId = id
                });


                //-------------------Italy---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Рим").Id;
                airoports.Add(new Airport
                {
                    Name = "Leonardo da Vinci International Airport",
                    ShortName = "FCO",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Венеція").Id;
                airoports.Add(new Airport
                {
                    Name = "Venice Marco Polo Airport",
                    ShortName = "VCE",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Флоренція").Id;
                airoports.Add(new Airport
                {
                    Name = "LeonardFlorence Airport, Peretola",
                    ShortName = "FLR",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Верона").Id;
                airoports.Add(new Airport
                {
                    Name = "Valerio Catullo Airport",
                    ShortName = "VRN",
                    CityId = id
                });


                //-------------------France---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Ліон").Id;
                airoports.Add(new Airport
                {
                    Name = "Lyon-Saint Exupéry Airport",
                    ShortName = "LYS",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Country.Name == "Орлі").Id;
                airoports.Add(new Airport
                {
                    Name = "Orly Airport",
                    ShortName = "ORY",
                    CityId = id
                });


                //-------------------George---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Батумі").Id;
                airoports.Add(new Airport
                {
                    Name = "Batumi International Airport",
                    ShortName = "BUS",
                    CityId = id
                });


                //-------------------Куба---------------------
                id = cities.FirstOrDefault(x => x.Country.Name == "Варадеро").Id;
                airoports.Add(new Airport
                {
                    Name = "Juan Gualberto Gómez International Airport",
                    ShortName = "VRA",
                    CityId = id
                });
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


                //SeederDB.SeedRoles(context,manager,managerRole); // --- DONE
                //SeederDB.SeedUsers(context, manager, managerRole); // --- DONE

                SeederDB.SeedCountries(context);
                SeederDB.SeedCities(context);
                SeederDB.SeedHotels(context);
                SeederDB.SeedAirports(context);
            }

        }
    }
}
