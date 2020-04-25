using Bon_Voyage.DB.Entities;
using Bon_Voyage.DB.IdentityModels;
using Bon_Voyage.MediatR.Hotel.Commands.AddHotelPhoto;
using MediatR;
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

                BaseProfile clientBase = new BaseProfile
                {
                    Name = "Vlad",
                    Surname = "Montana"
                };

                ClientProfile clientProfile = new ClientProfile
                {
                    BaseProfile = clientBase,
                    DateOfBirth = new DateTime(2002, 7, 5)
                };

                DbUser dbUser = new DbUser
                {
                    Email = "client1@gmail.com",
                    UserName = "client1@gmail.com",
                    BaseProfile = clientBase
                };

                var res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;
                context.ClientProfiles.Add(clientProfile);


                //----------------#2--------------------
                clientBase = new BaseProfile
                {
                    Name = "Moe",
                    Surname = "Szyslak"

                };

                clientProfile = new ClientProfile
                {
                    BaseProfile = clientBase,
                    DateOfBirth = new DateTime(1978, 2, 13)
                };
                
                dbUser = new DbUser
                {
                    Email = "client2@gmail.com",
                    UserName = "client2@gmail.com",
                    BaseProfile = clientBase
                };

                res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;
                context.ClientProfiles.Add(clientProfile);


                //----------------#3--------------------

                roleName = "Manager";

                BaseProfile managerBase = new BaseProfile
                {
                    Name = "Lena",
                    Surname = "Golovach"
                };

                ManagerProfile managerProfile = new ManagerProfile
                {
                    DateOfRegister = DateTime.Now,
                    State = true,
                    Salary = 1480,
                    BaseProfile = managerBase
                };

                dbUser = new DbUser
                {
                    Email = "manager@gmail.com",
                    UserName = "manager@gmail.com",
                    BaseProfile = managerBase
                };

                res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;
                context.ManagerProfiles.Add(managerProfile);


                //----------------#4--------------------

                roleName = "Admin";

                BaseProfile adminBase = new BaseProfile
                {
                    Name = "Joe",
                    Surname = "Weider"
                };

                AdminProfile adminProfile = new AdminProfile
                {
                    BaseProfile = adminBase
                };

                dbUser = new DbUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    BaseProfile = adminBase
                };

                res = userManager.CreateAsync(dbUser, "QWerty-1").Result;
                res = userManager.AddToRoleAsync(dbUser, roleName).Result;
                context.AdminProfiles.Add(adminProfile);
                context.SaveChanges();
            }
        }

        public static void SeedCountries(EFDbContext context)
        {
            if (context.Country.Count() == 0)
            {
                var countries = new List<Country>();

                countries.Add(new Country { Name = "Єгипет" });
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
                id = countries.FirstOrDefault(x => x.Name == "Єгипет").Id;

                cities.Add(new City
                {
                    Name = "Шарм-ель Шейх ", // *Airport
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
                id = cities.FirstOrDefault(x => x.Name == "Шарм-ель Шейх ").Id;
                airoports.Add(new Airport
                {
                    Name = "Sharm El Sheikh International Airport",
                    ShortName = "SSH",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Хургада").Id;
                airoports.Add(new Airport
                {
                    Name = "Hurghada International Airport",
                    ShortName = "HRG",
                    CityId = id
                });


                //-------------------Turkey---------------------
                id = cities.FirstOrDefault(x => x.Name == "Аланія").Id;
                airoports.Add(new Airport
                {
                    Name = "Gazipasa Alanya Airport",
                    ShortName = "GZP",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Анкара").Id;
                airoports.Add(new Airport
                {
                    Name = "Ankara Esenboga Airport",
                    ShortName = "ESB",
                    CityId = id
                });


                //-------------------Grecce---------------------
                id = cities.FirstOrDefault(x => x.Name == "Афіни").Id;
                airoports.Add(new Airport
                {
                    Name = "Athens International Airport",
                    ShortName = "ATH",
                    CityId = id
                });


                //-------------------Spain---------------------
                id = cities.FirstOrDefault(x => x.Name == "Барселона").Id;
                airoports.Add(new Airport
                {
                    Name = "Josep Tarradellas Barcelona-El Prat Airport",
                    ShortName = "BCN",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Мадрид").Id;
                airoports.Add(new Airport
                {
                    Name = "Madrid-Barajas Adolfo Suárez Airport",
                    ShortName = "MAD",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Валенсія").Id;
                airoports.Add(new Airport
                {
                    Name = "Valencia Airport",
                    ShortName = "VLC",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Севілья").Id;
                airoports.Add(new Airport
                {
                    Name = "Seville Airport",
                    ShortName = "SVQ",
                    CityId = id
                });

                //-------------------OAE---------------------
                id = cities.FirstOrDefault(x => x.Name == "Дубаї").Id;
                airoports.Add(new Airport
                {
                    Name = "Dubai International Airport",
                    ShortName = "DXB",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Абу-Дабі").Id;
                airoports.Add(new Airport
                {
                    Name = "Abu Dhabi International Airport",
                    ShortName = "AUH",
                    CityId = id
                });





                //-------------------Shri Lanka---------------------
                id = cities.FirstOrDefault(x => x.Name == "Коломбо").Id;
                airoports.Add(new Airport
                {
                    Name = "Bandaranaike International Airport",
                    ShortName = "CMB",
                    CityId = id
                });


                //-------------------Italy---------------------
                id = cities.FirstOrDefault(x => x.Name == "Рим").Id;
                airoports.Add(new Airport
                {
                    Name = "Leonardo da Vinci International Airport",
                    ShortName = "FCO",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Венеція").Id;
                airoports.Add(new Airport
                {
                    Name = "Venice Marco Polo Airport",
                    ShortName = "VCE",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Флоренція").Id;
                airoports.Add(new Airport
                {
                    Name = "LeonardFlorence Airport, Peretola",
                    ShortName = "FLR",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Верона").Id;
                airoports.Add(new Airport
                {
                    Name = "Valerio Catullo Airport",
                    ShortName = "VRN",
                    CityId = id
                });


                //-------------------France---------------------
                id = cities.FirstOrDefault(x => x.Name == "Ліон").Id;
                airoports.Add(new Airport
                {
                    Name = "Lyon-Saint Exupéry Airport",
                    ShortName = "LYS",
                    CityId = id
                });
                id = cities.FirstOrDefault(x => x.Name == "Орлі").Id;
                airoports.Add(new Airport
                {
                    Name = "Orly Airport",
                    ShortName = "ORY",
                    CityId = id
                });


                //-------------------George---------------------
                id = cities.FirstOrDefault(x => x.Name == "Батумі").Id;
                airoports.Add(new Airport
                {
                    Name = "Batumi International Airport",
                    ShortName = "BUS",
                    CityId = id
                });


                //-------------------Куба---------------------
                id = cities.FirstOrDefault(x => x.Name == "Варадеро").Id;
                airoports.Add(new Airport
                {
                    Name = "Juan Gualberto Gómez International Airport",
                    ShortName = "VRA",
                    CityId = id
                });



                context.AddRange(airoports);
                context.SaveChanges();
            }
        }

        public static void SeedHotels(EFDbContext context)
        {
            if (context.Hotels.Count() == 0)
            {
                var cities = context.Cities.ToList();
                var hotels = new List<Hotel>();
                string id = string.Empty;

                //-------------------Egypt---------------------
                //------ Hurgada
                id = cities.FirstOrDefault(x => x.Name == "Хургада").Id;
                hotels.Add(new Hotel
                {
                    Name = "ROYAL LAGOONS AQUA PARK RESORT & SPA",
                    Stars = 5,
                    Description = @"Royal Lagoons Aqua Park Resort \& Spa знаходиться в районі Villages Road, 9 км від Diving Center Hurghada і має в наявності обмін валют, камеру схову багажу і перукарню. Цей 5-зірковий готель був відкритий 2007 році.\n\nРозташування\nRoyal Lagoons Aqua Park Resort \& Spa надає кімнати з системою опалення, кондиціонером і вбиральнею та має центральне розташування поблизу до Hurghada Grand Aquarium. Гості можуть дійти до Нова пристань для яхт, подолавши відстань 8 км звідси. До океанаріуму, барів і ресторанів можна дійти за кілька хвилин.\nНомери\nНомери виходять вікнами на сад.\n\nХарчування\nУ готелі щодня подають сніданок шведський стіл. Ресторан має широкий вибір фірмових делікатесів італійської кухні. Кафе-бар подає місцеві напої кожен день.\n\nПослуги\nRoyal Lagoons Aqua Park Resort \& Spa Хургада надає гостям цілодобовий ресепшн, цілодобове обслуговування номерів і послуги носія.\n\nВідпочинок\nГості можуть насолодитися приватним басейном з водною гіркою, гідромасажною ванною і сауною. Для занять спортом є спортзал, заняття аеробікою і фітнес-центр.\n\nІнтернет\nWi-Fi доступний в в номерах готелю за додаткову плату.\n\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території надається безкоштовна громадська парковка.\n\nКількість номерів:   366.".Replace(@"/n", "<br />"),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "NUBIA AQUA BEACH RESORT",
                    Stars = 4,
                    Description = @"Nubia Aqua Beach Resort розташований в Хургаді та пропонує гостям аквапарк, водні гірки і власний басейн. Nubia Aqua Beach Resort був відкритий у 2013 році. У готелі ви можете знайти безкоштовну парковку, обмін валют і Інтернет-кафе.\n\nРозташування\nГотель знаходиться приблизно в 13 км від District Court of Hurghada. Поїздка машиною до TU Berlin Campus El Gouna займе 20 хвилин. Аеропорт Hurghada розташований в 25 хвилинах їзди.\nНомери\nВікна готелю виходять на море, до того ж тут пропонується номери з телевізором з супутниковими каналами, системою клімат-контролю і еркером. Гості готелю можуть насолодитися чарівним видом. У кожному номері є підлога з плитки, а також електрочайник, посудомийна машина і автомат з кубиками льоду.\n\nХарчування\nСніданок шведський стіл тут подається кожного ранку. Ви можете пообідати у цілодобовому ресторані, який пропонує делікатеси російської кухні. Лаунж-бар ідеальне місце для того, щоб розслабитися за напоєм.\n\nПослуги\nТакож доступні послуги з прокату авто.\n\nВідпочинок\nNubia Aqua Beach Resort може надати такі розваги, як розважальні програми, анімація і караоке. Nubia Aqua Beach Resort пропонує заняття з декількох видів спорту, зокрема катання на гірських велосипедах, віндсерфінг і дайвінг.\n\nІнтернет\nWi-Fi в зонах загального користування готелю, вартістьUSD 3 на день\n\nWi-Fi в зонах загального користування готелю, вартістьUSD 4 на день\n\nПарковка\nПоблизу надається безкоштовна громадська парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, російською, арабською.\n\nКількість номерів:   35.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Sharm El-Sheikh
                id = cities.FirstOrDefault(x => x.Name == "Шарм-ель Шейх ").Id;
                hotels.Add(new Hotel
                {
                    Name = "REEF OASIS BEACH RESORT",
                    Stars = 4,
                    Description = @"Reef Oasis Beach Resort - це відмінний 4-зірковий готель, що має 670 номерів, де можна зупинитися. Reef Oasis Beach Resort датується 1990 роком. Гості можуть користуватися безкоштовний WiFi та безкоштовною парковкою, камерою зберігання багажу і перукарнею.\n\nРозташування\nРозташування в мальовничій місцевості готелю надає швидкий доступ до Old Market, що знаходиться в 25 хвилинах ходьби. Відстань до Національний парк Рас-Мухаммад у Шарм-еш-Шейсі – 12 км. Поїздка машиною до аеропорту Ophira International займе 25 хвилин.\nНомери\nДеякі номери мають вид на сад і оснащені супутниковим телебаченням, сейфом для ноутбука і сервантом. Гості готелю можуть насолодитися чудесним видом. Номери мають посудомийну машину, чайник і кухонну плиту.\n\nХарчування\nУ готелі щоранку пропонується сніданок шведський стіл. Готель має ресторан на відкритому повітрі, де подають страви місцевої кухні. Маючи більярдний стіл, живу музику і терасу, бар готелю запрошує гостей насолодитися прохолодними напоями, мінеральною водою і кавою, також снеками і тортами.\n\nВідпочинок\nУ послуги готелю також входять чистка обличчя і масаж. Любителі активного відпочинку оцінять спортзал і заняття з гімнастики на території.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території надається безкоштовна громадська парковка.\n\nКількість номерів:   670.".Replace(@"\n", " "),
                    CityId = id
                });

                //------ Safaga
                id = cities.FirstOrDefault(x => x.Name == "Сафага").Id;
                hotels.Add(new Hotel
                {
                    Name = "SHAMS SAFAGA RESORT",
                    Stars = 4,
                    Description = @"Shams Safaga Resort розташований поруч з гарним піщаним пляжем і має тенісний корт, салон краси і перукарню. Розташовуючись у будинку в східному стилі, готель має 340 кімнат. У готелі є суміжні номери, а також обмін валют, камера схову багажу і ліфт.\n\nРозташування\nЦентр Хургади та Острів Гіфтун знаходяться в 90 і в 90 хвилинах їзди від готелю відповідно. Центр Сома-Бей знаходиться на відстані 3 км від готелю. Пропонується зручне розташування недалеко від човнового причалу.\nНомери\nДля вашого комфорту всі номери мають супутникове телебачення, платне телебачення і робочий стіл. В усіх номерах є вид на море. В усіх номерах є в наявності власні ванні кімнати.\n\nХарчування\nЦей готель щоранку накриває сніданок шведський стіл. У цілодобовому ресторані відвідувачам пропонують страви морської кухні. Гості можуть відпочити в лобі-барі і насолодитися місцевими напоями.\n\nВідпочинок\nУ Shams Safaga Resort Сома-Бей можна насолодитися відкритим плавальним басейном зі снек-баром біля басейну, водоспадами і парасольками. На території є спортзал і студія фітнесу.\n\nІнтернет\nWi-Fi в зонах загального користування готелю, вартістьUSD 10 на час\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nКількість номерів:   250.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "AMARINA ABU SOMA RESORT & AQUA PARK",
                    Stars = 5,
                    Description = @"Сучасний готель Готель Riviera Plaza Abu Soma є чудовим місцем проживання в районі Сома Бей Хургади та знаходиться на невеликій відстані від Hawa Safaga. Готель Riviera Plaza Abu Soma складається з 327 кімнат. Поміж інших зручностей у цьому готелі ви також зможете знайти обмін валют, камеру схову багажу і сувенірний магазин.\n\nРозташування\nГості можуть відвідати нова Гавань, що в 53 км від готелю. З готелю до Scuba World Divers можна доїхати за 20 хвилин. Аеропорт Hurghada розташований в 55 хвилинах їзди.\nНомери\nУ деяких номерах є кондиціонер, високошвидкісний Інтернет і сервант для зручності гостей. Кожен номер пропонує вид на море. У кожен номер також входять душ, фен і туалетно-косметичні засоби.\n\nХарчування\nСніданок шведський стіл тут подається кожного ранку. У готелі знаходиться пляжний ресторан. Кафе-бар ідеальне місце для того, щоб розслабитися за напоєм.\n\nВідпочинок\nГості зможуть насолодитися паровою банею, турецькою банею і масажем. Готель пропонує підводне плавання з маскою, віндсерфінг і настільний теніс, а також нічний клуб, бібліотеку і тенісний корт.\n\nІнтернет\nWi-Fi у всьому готелі, вартістьUSD 6 на час\n\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, чешською, польською, російською, арабською, українською.\n\nКількість номерів:   393.".Replace(@"\n", " "),
                    CityId = id
                });


                //-------------------Turkey---------------------
                //------ Alanie
                id = cities.FirstOrDefault(x => x.Name == "Аланія").Id;
                hotels.Add(new Hotel
                {
                    Name = "FIRST CLASS HOTEL",
                    Stars = 5,
                    Description = @"First Class Hotel пропонує чудове помешкання в Аланії.\n\nРозташування\nЦей готель знаходиться лише в 20 хвилинах їзди від Alanya Barrage та в 4.2 км від Laertes Antik Kenti. За 30 хвилин можна доїхати до аеропорту Gazipasa.\nНомери\nВсі номери готелю мають індивідуальний кондиціонер, робочий стіл і DVD програвач. У номерах гості зможуть скористатися власними ванними кімнатами з душем, сушаркою і безкоштовними туалетно-косметичними засобами.\n\nХарчування\nКожен день в їдальні сервірують хороший сніданок шведський стіл. У ресторані гостей пригощають стравами місцевої кухні. Вино, пиво і прохолодні напої подаються в англійському барі щодня.\n\nВідпочинок\nГості можуть скористатися спортзалом і фітнес-центром. Ви можете взяти участь в настільному тенісі, більярді і дартсі на території.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nWi-Fi у всьому готелі, вартістьEUR 2 на день\n\nПарковка\nНа території надається безкоштовна громадська парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, російською, турецькою.\n\nКількість номерів:   166.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "ARTEMIS PRINCESS",
                    Stars = 3,
                    Description = @"Готель Artemis Princess розташований в центрі Аланії на відстані 3.9 км від Red Tower. 146 сучасні номери обладнані сучасними зручностями. Номери розподілені між 2 головні будівлями.\n\nРозташування\nПершокласне розташування пропонує легкий доступ до чудового піщаного пляжу. Готель Artemis Princess також розміщується за 15 хвилин від Торговий центр Alanyum. Відвідайте річку і гори поруч з готелем. Аеропорт Gazipasa розташований в 40 хвилинах їзди.\nНомери\nДо послуг гостей номери з системою опалення, центральним опаленням і DVD програвачем, а також з власними ванними кімнатами, де є душ, фен і туалетно-косметичні засоби. Кімнати мають незабутній вид на море. Номери укомплектовані посудомийною машиною, кавоваркою і пральною машиною.\n\nХарчування\nНа території готелю є ресторан на верхньому поверсі, де подають страви інтернаціональної кухні. Бар на території подає пиво, вино і прохолодні напої. На території на вибір є різні ресторани, у тому числі Green Beach Restaurant і Seasons Restaurant.\n\nПослуги\nГотель надає своїм гостям послуги лікаря за викликом, хімчистку і послугу будильник.\n\nВідпочинок\nДодаткові зручності в Готель Artemis Princess включають у себе дитячі ліжечка, майданчик і дитячий басейн для гостей з дітьми. Ви можете взяти участь в більярді і настільному тенісі на території.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nWi-Fi у всьому готелі, вартістьEUR 2 на день\n\nПарковка\nПоблизу надається безкоштовна громадська парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, російською, турецькою.\n\nРік реконструкції:   2012.  Кількість поверхів:   5.  Кількість номерів:   146.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "CLUB STAR BEACH",
                    Stars = 4,
                    Description = @"4-зірковий Club Star Beach розташований за 28 км від Alanya Aquapark.\n\nРозташування\nDamlatas Caves розташований менше, ніж в 28 км. Автобусна зупинка знаходиться в двох кроках від готелю.\nНомери\nУ кожному номері є кондиціонер, телевізор з плоским екраном і балкон для затишного перебування в готелі.\n\nХарчування\nУ Club Star Beach щоранку подається сніданок шведський стіл. Гостей приймають в барі на терасі і пропонують відпочити з улюбленим напоєм.\n\nВідпочинок\nВ готелі є прямий доступ до відкритого плавального басейну з джакузі.\n\nІнтернет\nWi-Fi в зонах загального користування готелю, вартістьEUR 1 на день\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nКількість номерів:   90.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Ankara
                id = cities.FirstOrDefault(x => x.Name == "Анкара").Id;
                hotels.Add(new Hotel
                {
                    Name = "HOTEL ABRO SEZENLER",
                    Stars = 4,
                    Description = @"Abro Sezenler Hotel пропонує 4-зіркове помешкання відразу біля CerModern. У готелі є 60 номерів. До зручностей в готелі входять безкоштовна автостоянка, безкоштовні місця для паркування і ліфт.\n\nРозташування\nГотель знаходиться в центрі Анкари, в 20 хвилинах їзди від аеропорту Etimesgut. Розташування готелю — 1 км від центру Анкари. Коротка 5-хвилинна прогулянка приведе до станції метро Sıhhiye.\nНомери\nКожен номер має міні-бар, опалення і зону відпочинку, а також посудомийну машину і холодильник. Вікна багатьох номерів виходять на місто. В номерах є власні ванні кімнати з душем, сушаркою і туалетно-косметичними засобами.\n\nХарчування\nГотель пропонує ситний сніданок шведський стіл кожного дня. Ресторан на даху Terrace знаходиться на території готелю. Adana Sofrasi і hacI baba пропонують гостям повечеряти і знаходяться вони в 200 метрах від території готелю.\n\nПослуги\nДо того ж, гості можуть скористатися цілодобовим обслуговуванням номерів, доставкою преси і допомогою в підборі турів/квитків.\n\nВідпочинок\nНа території готелю працює приватний басейн.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПарковки немає.\n\nКількість номерів:   60.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Marmaris
                id = cities.FirstOrDefault(x => x.Name == "Мармарис").Id;
                hotels.Add(new Hotel
                {
                    Name = "MARMARIS PARK HOTEL",
                    Stars = 3,
                    Description = @"Marmaris Park Hotel знаходиться на відстані 3.2 км від Аквапарк Атлантіс, та має оздоровчий центр і спа-центр. Готель, відкритий у 1988 році та реконструйований у 2012 році, пропонує гостям 415 кімнат. Обмін валют, камера схову багажу і ліфт є в наявності для зручності гостей.\n\nРозташування\nЗамок Мармарис розташований менше, ніж в 4.8 км. Центр Мармариса в 7 км від готелю.\nНомери\nНомери мають кондиціонер, холодильник і окремий туалет для затишного перебування гостей. Багато номерів мають вид на море. У номерах є посудомийна машина і автомат з кубиками льоду.\n\nХарчування\nРесторан у саду, що знаходиться на території готелю, подає страви місцевої кухні. Цілодобовий бар пропонує гостям більярдний стіл і караоке. Поруч знаходяться кілька ресторанів, такі як Deniz Balik Restaurant.\n\nВідпочинок\nЩоб ваш відпочинок був ще кращим, у готелі є нічний клуб, водні гірки і бібліотеку. Різноманітні види активного відпочинку включають веслування на каное, теніс і дартс.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники у готелі розмовляють англійською, німецькою, російською, турецькою.\n\nРік реконструкції:   2012.  Кількість поверхів:   5.  Кількість номерів:   415.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "IDEAL PRIME BEACH",
                    Stars = 5,
                    Description = @"Маючи терасу для засмаги, сауну і критий басейн, 4-зірковий Готель Ideal Prime Beach пропонує проживання в 35 приємних номерах. Цей готель пропонує гостям цілодобовий ресепшн, пральню і обслуговування номерів для їхньої зручності.\n\nРозташування\nГотель знаходиться в центрі Мармариса за 15 хвилин пішки від Аквапарк Аква Дрім. Завдяки зручному розташуванню, ви зможете легко дістатися всіх визначних пам\'яток, включно з Аквапарк Атлантіс Су Паркі і Emre Beach Hotel. Аквапарк, ресторани і дельфінаріум в декількох кроках від готелю.\nНомери\nКондиціонер, багатоканальне телебачення і зона відпочинку наявні в усіх номерах готелю. В усіх номерах є вид на море. До того ж, у номерах готелю є паркетна підлога.\n\nХарчування\nУ маленькому ресторані спеціалізуються на стравах місцевої кухні. Гості можуть замовити алкогольні напої в нічному барі. The Mandarin Restaurant розташований в 5 хвилинах ходьби від готелю.\n\nВідпочинок\nВ готелі є прямий доступ до відкритого плавального басейну з шезлонгами і баром біля басейну. На території є широкий вибір спортивних занять, такі як настільний теніс і теніс.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається безкоштовна громадська парковка.\n\nКількість номерів:   35.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Bodrum
                id = cities.FirstOrDefault(x => x.Name == "Бодрум").Id;
                hotels.Add(new Hotel
                {
                    Name = "MANDARIN RESORT",
                    Stars = 5,
                    Description = @"Mandarin Resort Hotel - це привабливий 5-зірковий готель, що надає цілодобовий ресепшн, послуги лікаря за викликом і трансфер. Mandarin Resort Hotel радо приймає гостей в просторих номерах з 2005 року. У готелі ви можете знайти обмін валют, камеру схову багажу і місце для паління.\n\nРозташування\nВін знаходиться в центрі Бодрума, поруч з Морський музей в Бодрумі. Myndos Gate розміщено приблизно за 25 хвилин ходьби від готелю. Готель розташований близько торгових центрів і ринку. На машині ви зможете дістатися до аеропорту Milas за 40 хвилин.\nНомери\nУ номері є міні-бар, кондиціонер і Wi-Fi для вашої зручності. Також в деяких номерах є вид на море. Номери містять власні ванні кімнати з душем, феном і безкоштовними туалетно-косметичними засобами.\n\nХарчування\nПід час перебування у Mandarin Resort Hotel Бодрум гості зможуть насолодитися сніданком шведський стіл. Обіди в цілодобовому ресторані здебільшого складається зі страв середземноморської кухні. Кафе-бар ідеальне місце для того, щоб розслабитися за напоєм. Pizzeria Luca Bodrum, Leon Bistro \& Bar і Demeter Bar \& Restaurant пропонують різні страви і знаходяться в 50 метрах.\n\nВідпочинок\nДо зручностей відносяться нічний клуб, аквапарк і сезонний басейн просто неба. Запропоновані спортзал, заняття з гімнастики і студія фітнесу допоможуть гостям підтримати спортивну форму.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники у готелі розмовляють англійською, німецькою, нідерландською, турецькою.\n\nКількість номерів:   141.".Replace(@"\n", " "),
                    CityId = id
                });


                //-------------------Grecce---------------------
                //------ Athens
                id = cities.FirstOrDefault(x => x.Name == "Афіни").Id;
                hotels.Add(new Hotel
                {
                    Name = "BOMO CLUB PALACE HOTEL",
                    Stars = 4,
                    Description = @"У відмінному 4-зірковому готелі Bomo Club Palace доступні номери для некурців з панорамним видом на море. 6-поверхова будівля готелю була відреставрована в 2000 році. У готелі можна скористатися цілодобовим обслуговуванням номерів, безкоштовним трансфером і послугами консьєржа, а також камерою зберігання багажу, місцем для паління і безкоштовною громадською парковкою.\n\nРозташування\nЦей готель, який знаходиться в центрі Афін і близько до Гольф-клуб Афін, пропонує своїм гостям комфорт. Стадіон миру та дружби розташований в 10 км від готелю. Неподалік є залізнична станція Залізнична Монастіраки. За 25 хвилин їзди ви зможете дістатися до аеропорту Eleftherios Venizelos.\nНомери\nНомери обладнані опаленням, кабельним телебаченням з фільмами на замовлення і вітальнею. У більшості номерів є електрочайник, посудомийна машина і холодильник.\n\nХарчування\nУ ресторані готелю подається сніданок шведський стіл. Готель пропонує ресторан a la carte, де подають страви інтернаціональної кухні. Ви можете спробувати коктейлі і каву у цілодобовому барі. Підживитися можна в Enigma Cafe Bar, Delfinia і Pizza Hut, які знаходяться в 5 хвилинах пішки.\n\nВідпочинок\nДля гостей з дітьми в готелі Bomo Club Palace передбачені такі зручності, як дитячі ліжечка і догляд за дітьми.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна громадська парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, італійською, польською, грецькою, російською.\n\nКількість поверхів:   6.  Кількість номерів:   76.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "OSCAR HOTEL ATHENS",
                    Stars = 3,
                    Description = @"Маючи в розпорядженні камеру схову багажу, ліфт і газетний кіоск, Oscar Hotel знаходиться недалеко від Пагорб Лікавіт. Готель було оновлено в 2004 і складається з 6 поверхів. Зупинившись тут, ви також зможете користуватися Wi-Fi і приватний паркінг.\n\nРозташування\nПомешкання має відмінне розташування в шопінг районі поруч з портом, пропонуючи легкий доступ до Площа Синтагма, що в 25 хвилинах ходьби. Музей Тренон розташований в 1.9 км від готелю. Туристичні місця, такі як будівля парламенту, музей і церква, знаходяться неподалік готелю. Залізнична станція Athens Railway-Peloponnese знаходиться на відстані 100 метрів від готелю.\nНомери\nУ цьому готелі є номери з ванною, феном і туалетно-косметичними засобами, а також системою клімат-контролю, сейфом для ноутбука і коморою. Гарні номери мають вид на місто. В усіх номерах ви також можете користуватися власні ванними кімнатами.\n\nХарчування\nУ ресторані Dionysos представлені вишукані страви інтернаціональної кухні. У лобі-барі подають смачні страви та напої. Sablo і Garbi Restaurant пропонують величезний вибір страв у 350 метрах від готелю.\n\nПослуги\nДля усіх гостей надаються послуги лікаря за викликом, хімчистка і послуги носія.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 7 на день.\n\nПерсонал готелю розмовляє англійською, іспанською, італійською, грецькою, російською.\n\nКількість поверхів:   6.  Кількість номерів:   124.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "ATHENIAN CALLIRHOE HOTEL",
                    Stars = 4,
                    Description = @"Athenian Callirhoe Hotel має 84 стильних номерів та розташований у районі Athens City Centre. Готель був побудований у 1974 році та декорований в інноваційному стилі. В готелі панує приємна атмосфера і гостям пропонують ввічливе обслуговування.\n\nРозташування\nAthenian Callirhoe Hotel пропонує близькість до автобусної зупинки, забезпечуючи швидкий доступ до музею і храму, а також до Kaisariani΄s Shooting Range, Altar of Freedom, яка знаходиться на відстані 2.8 км. Гості можуть дійти до Art Gallery - Artiter Oil Paintings, подолавши відстань 1.5 км звідси. Поруч розташовані торгові вулиці, сувенірні крамниці і бутики. До того ж, готель розташований на відстані 5 хвилин ходьби від станції метро Станція Akropolis і в 850 метрах від залізничної станції Залізнична Монастіраки. Аеропорт Eleftherios Venizelos знаходиться на відстані 20 км від Athenian Callirhoe Hotel.\nНомери\nУ цьому готелі є кондиціонер, Wi-Fi і телефон з міжнародною лінією в кожному номері. Номери виходять вікнами на гори. Доповненням номерів служить декор в стилі модерн.\n\nХарчування\nВранці гості можуть насолодитися сніданком шведський стіл у ресторані. У цілодобовому ресторані готують авторські страви. Ви можете відпочити у кафе-барі та спробувати широкий асортимент легких напоїв. Поруч знаходяться кілька ресторанів, такі як Athenian Callirhoe Hotel Roof Garden, Smile Cafe Restaurant і Gods\' Restaurant.\n\nВідпочинок\nУ готелі є приватний басейн. Любителям активного відпочинку знадобляться спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПарковки немає.\n\nКількість поверхів:   8.  Кількість номерів:   84.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Casthoria
                id = cities.FirstOrDefault(x => x.Name == "Касторія").Id;
                hotels.Add(new Hotel
                {
                    Name = "ANASTASSIOU",
                    Stars = 2,
                    Description = @"2-зірковий Hotel Anastassiou може похизуватися зручним розташуванням в 1.9 км від Kastoria Aquarium. Інтер\'єр готелю Anastassiou виконаний в гарних кольорах, який ховається за фасадом в візантійському стилі. В готелі є 22 номери для некурців та цілодобовий ресепшн, послуги консьєржа і обслуговування номерів.\n\nРозташування\nГотель розміщений в бізнес-районі, в 3 км від центру Касторії. Byzantine Museum of Kastoria розташований в 2.3 км від цієї локації. Гості можуть відвідати музей і церкви, що знаходяться неподалік. Від Hotel Anastassiou до аеропорту Aristoteles можна дістатися на машині лише за 15 хвилин.\nНомери\nДодатково до кондиціонера, кавоварки і зони відпочинку, всі номери мають підлогу з килимовим покриттям. Вражаючий вид на гори відкривається з деяких номерів. Також у номерах є власні ванні кімнати з душем без піддону, феном і тропічним душем.\n\nХарчування\nHotel Anastassiou пропонує континентальний сніданок. У кафе-барі на території можна приємно провести час.\n\nВідпочинок\nДля маленьких гостей доступні дитячі ліжечка, ігрова кімната і настільні ігри. Для підтримання форми гості можуть спробувати веслування на каное, катання на лижах і їзду на велосипеді.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nКількість номерів:   22.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HOTEL KASTORIA",
                    Stars = 3,
                    Description = @"Маючи безкоштовну парковку і веранду для засмаги, Hotel Kastoria пропонує оселитися в одному з класичних номерів з видом на озеро. Готель був відкритий в 1968 і повністю оновлений в 2009 році. Додатково до камери схову багажу, сейфу і ліфту на території готелю є цілодобовий ресепшн, пральня і обслуговування номерів.\n\nРозташування\nPanagia Mavriotissa Monastery та Prespes знаходяться на відстані 1.9 км і 30 км відповідно. Це в 10 хвилинах пішки від центру Касторії. Гості можуть дістатися до аеропорту Aristoteles приблизно за 15 хвилин їзди.\nНомери\nСистема клімат-контролю, кондиціонер і балкон входять в усі номери. Номери повністю облаштовані власними ванними кімнатами з душем, феном і сушаркою.\n\nХарчування\nHotel Kastoria накриває сніданок шведський стіл щоранку. Готель пропонує традиційний ресторан, який подає страви італійської кухні. У самобутньому барі є широкий вибір кави і домашнього вина. Гості зможуть повечеряти в Grada і Krontiri, які знаходяться в 10 хвилинах ходьби.\n\nПослуги\nВи також можете взяти напрокат велосипеди.\n\nВідпочинок\nУ готелі є приватний басейн.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається безкоштовна громадська парковка.\n\nПерсонал у готелі розмовляє англійською, італійською, швецькою, грецькою.\n\nРік реконструкції:   2009.  Кількість номерів:   37.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Naxos 
                id = cities.FirstOrDefault(x => x.Name == "Наксос").Id;
                hotels.Add(new Hotel
                {
                    Name = "FINIKAS HOTEL",
                    Stars = 4,
                    Description = @"Finikas Hotel знаходиться поблизу пляжу та має вид на гори. Готель розміщений у будівлі в грецькому стилі. На території є басейн, а також послуги консьєржа, весільні послуги і доставка преси.\n\nРозташування\nДо Пляж Піргакі можна дійти пішки за 5 хвилин. Пляж Агіассос розташований в 2.8 км. Також можете знайти бутики і торгові центри в декількох хвилинах від готелю.\nНомери\nFinikas Hotel Naxos Island надає 23 кімнат з сейфом для ноутбука, окремим балконом і сервантом. У всіх номерах є власні ванні кімнати зі спа-ванною, безкоштовними туалетно-косметичними засобами і халатами.\n\nХарчування\nFinikas Hotel щоранку пропонує гарячий сніданок шведський стіл. Традиційний ресторан запрошує скуштувати страви місцевої кухні. Ви можете відпочити у коктейль-барі та спробувати широкий асортимент освіжаючих напоїв. Гості можуть відвідати Notos - Cafe \& Restaurant і Taverna Trapezaki, що знаходяться приблизно в 100 метрах від готелю.\n\nВідпочинок\nЦей 4-зірковий готель також має терасу для засмаги, відкритий басейн і місце для пікніка. Спортзал і фітнес-зал надані серед інших зручностей.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nРік реконструкції:   2012.  Кількість номерів:   23.".Replace(@"\n", " "),
                    CityId = id
                });



                //-------------------Spain---------------------
                //------ Barselona 
                id = cities.FirstOrDefault(x => x.Name == "Барселона").Id;
                hotels.Add(new Hotel
                {
                    Name = "EUROSTARS GRAND MARINA",
                    Stars = 5,
                    Description = @"5-зірковий Готель Eurostars Grand Marina розмістився поблизу до Santa Maria del Mar. Готель, який розташований у 8-поверховій будівлі, було побудовано в 2001 році та реконструйовано в 2002 році.\n\nРозташування\nВідстань до Gran Bodega Salto становить 15 хвилин ходьби, а залізнична станція Французький вокзал розміщена за 20 хвилин пішки. Complices розташовано на відстані 15 хвилин пішки. Christopher Columbus Monument знаходиться за декілька хвилин ходьби від цього розкішного готелю. За 15-хвилинну прогулянку ви дійдете до станції метро Paral·lel.\nНомери\nГості чудово відпочинуть в шикарних номерах, що обладнані власною терасою, холодильником і пресом для брюк. У деяких номерах є вид на узбережжя. У номерах є ортопедичний матрац і меню подушок, а також фен, окремий душ і душова кабіна у ванних кімнатах.\n\nХарчування\nДля гостей у ресторані подають ситний сніданок. Гості можуть насолодитися різноманіттям ф\'южн кухні у ресторані просто неба. На території знаходиться кафе-бар. Найближчі ресторани, в тому числі Aire de Mar Restaurant, Eat Restaurant і WTC Club Meet \& Eat, знаходяться в 5 хвилинах ходьби від готелю.\n\nЗа EUR 27.50 з людини за добу в готелі сервірується сніданок-шведський стіл. \n\nПослуги\nСамостійне паркування і нянька доступні за окрему плату.\n\nВідпочинок\nГотель Eurostars Grand Marina Барселона також пропонує сезонний басейн. Для підтримання спортивної форми в готелі Eurostars Grand Marina гостям надані спортзал і кардіотренажери.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка за EUR 30.25 на день.\n\nПерсонал готелю розмовляє англійською, німецькою, іспанською, італійською, каталанською, російською.\n\nКількість поверхів:   8.  Кількість номерів:   291.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "CATALONIA ATENAS",
                    Stars = 4,
                    Description = @"Готель Catalonia Atenas знаходиться в 30 хвилинах ходьби від центру Барселони і пропонує гостям скористатися обслуговуванням номерів, прасуванням і послугами носія. З моменту відкриття в 1980 році, в готелі поєднуються архітектура в класичному стилі і сучасні зручності. У цьому функціональному готелі Барселони панує затишна атмосфера і надається ввічливе обслуговування.\n\nРозташування\nПомешкання розташовується в 2.8 км від Палац каталонскої музики. До Arc de Triomf можна дістатися приблизно за 25 хвилин. Готель знаходиться близько до кафедрального собору, церкви і пам\'ятників. Пропонується стратегічне розташування недалеко від порту.\nНомери\nУ готелі є світлі номери з сейфом для ноутбука, власною терасою і письмовим столом. З деяких номерів готелю відкривається приголомшливий вид на сад. Вони мають власні ванні кімнати, обладнані біде, безкоштовними туалетно-косметичними засобами і махровими халатами.\n\nХарчування\nПочніть свій день зі легкого сніданку шведський стіл. У традиційному ресторані ви можете насолодитися стравами місцевої кухні. Гості можуть розслабитися і перекусити в снек-барі. Серед закладів харчування неподалік є Piratas і La Coctelera.\n\nЩоранку в їдальні готелю подається сніданок-шведський стіл за ціною EUR 13 з людини за добу. \n\nПослуги\nГостям надається прокат авто.\n\nВідпочинок\nУ готелі можна насолодитися турецькою банею і масажем. Для спортивного дозвілля в готелі є спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка за EUR 20 на день.\n\nСпівробітники у готелі розмовляють англійською, іспанською, італійською.\n\nКількість поверхів:   10.  Кількість номерів:   201.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "DIAGONAL HOUSE",
                    Stars = 5,
                    Description = @"Розташований в районі Грасіа, Хостел Diagonal House пропонує сейф, бізнес-центр і камеру схову багажу.\n\nРозташування\nБульвар Проїзд Ґрасія знаходяться в 1200 метрах від хостелу, а Храм Святого Сімейства в 1300 метрах. La Cervesera Artesana і Thailandes Thai Restaurant, що розташовуються в 5 хвилинах пішки, пропонують різноманітні страви. Хостел Diagonal House знаходиться лише в декількох кроках від Palau Robert. Від хостелу до метро можна дійти пішки.\nНомери\nЦей хостел складається з 7 номерів, оснащених індивідуальним кондиціонером, системою опалення і патіо. Ліжка з шафками, лампами для читання і пуховими подушками є у звуконепроникних номерах. Номери в хостелі обставлені регульованими ліжками, двоспальними ліжками і двоярусними ліжками. Загальні ванні кімнати оснащені феном і рушниками. У них є душові, душова кабіна і біде.\n\nХарчування\nГостям доступна загальна кухня, оснащена коморою, варильною панеллю і духовкою.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nПарковки немає.\n\nКількість номерів:   7.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Madrid 
                id = cities.FirstOrDefault(x => x.Name == "Мадрид").Id;
                hotels.Add(new Hotel
                {
                    Name = "DON LUIS",
                    Stars = 3,
                    Description = @"3-зірковий Готель Don Luis розташований приблизно в 1.8 км від Cementerio Parroquial Nuestra Senora de la Alameda. Готель датується 2003 роком.\n\nРозташування\nГотель Don Luis Мадрид розташований в районі Barajas поруч з Parroquia San Pedro Apostol. Помешкання розташоване лише в 7 км від Metro Pueblo Nuevo. Поряд з готелем розміщується My Skyhole Madrid. Відстань від станції метро Аеропорт Мадрид-Барахас до готелю становить 600 метрів.\nНомери\nУсі номери містять безкоштовний Wi-Fi, мікрохвильову піч і холодильник для зручності гостей. Готель Don Luis пропонує кімнати з видом на море. Ці номери пропонують гостям власні ванні кімнати.\n\nХарчування\nГості можуть спробувати континентальний сніданок. Кафе-бар — гарне місце, щоб розслабитися з освіжаючими напоями. Широкий асортимент страв пропонується в Kathmandu Tandoori House Nepali \& Indian Cuisine, pizzeria y heladeria Sienna і Barajas Doner Kebab, що у 5 хвилинах ходьби.\n\nГотель пропонує гостям континентальний сніданок за ціною EUR 5 з людини за добу. \n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 10 на день.\n\nКількість поверхів:   4.  Кількість номерів:   38.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "EUROSTARS CENTRAL",
                    Stars = 4,
                    Description = @"Розташований в самому серці Мадрида, відмінний Готель Eurostars Central пропонує номери для некурців. Номери в 7-поверховому готелі оформлені в традиційному стилі і мають сучасні зручності. У готелі ви можете знайти камеру схову багажу, місце для паління і приватну парковку.\n\nРозташування\nГотель розміщений в 1400 метрах від Paseo de Recoletos і в 1400 метрах від Chueca. Центр Мадрида знаходиться на відстані 1 км від готелю. Готель Eurostars Central розташований недалеко від ринку і торгових центрів. Неподалік від готелю Eurostars Central є станція метро Quevedo.\nНомери\nКожен номер готелю забезпечено системою клімат-контролю, сейфом для ноутбука і кухнею для зручності та затишку всіх відвідувачів. Готель Eurostars Central надає номери з краєвидом на річку. Ці номери оформлені в сучасному стилі та мають паркетну підлогу.\n\nХарчування\nКожного ранку у готелі подається сніданок шведський стіл. На території готелю є як ресторан готелю, так і кафе-бар. Pajama і Pizza jardin знаходяться на відстані 150 метрів.\n\nВідпочинок\nГотель має терасу на даху і корти для сквошу для вашого приємного перебування. Для любителів спорту пропонуються спортзал, заняття йогою і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 25 на день.\n\nКількість поверхів:   7.  Кількість номерів:   135.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Valencia  
                id = cities.FirstOrDefault(x => x.Name == "Валенсія").Id;
                hotels.Add(new Hotel
                {
                    Name = "EUROSTARS CENTRAL",
                    Stars = 4,
                    Description = @"Розташований в самому серці Мадрида, відмінний Готель Eurostars Central пропонує номери для некурців. Номери в 7-поверховому готелі оформлені в традиційному стилі і мають сучасні зручності. У готелі ви можете знайти камеру схову багажу, місце для паління і приватну парковку.\n\nРозташування\nГотель розміщений в 1400 метрах від Paseo de Recoletos і в 1400 метрах від Chueca. Центр Мадрида знаходиться на відстані 1 км від готелю. Готель Eurostars Central розташований недалеко від ринку і торгових центрів. Неподалік від готелю Eurostars Central є станція метро Quevedo.\nНомери\nКожен номер готелю забезпечено системою клімат-контролю, сейфом для ноутбука і кухнею для зручності та затишку всіх відвідувачів. Готель Eurostars Central надає номери з краєвидом на річку. Ці номери оформлені в сучасному стилі та мають паркетну підлогу.\n\nХарчування\nКожного ранку у готелі подається сніданок шведський стіл. На території готелю є як ресторан готелю, так і кафе-бар. Pajama і Pizza jardin знаходяться на відстані 150 метрів.\n\nВідпочинок\nГотель має терасу на даху і корти для сквошу для вашого приємного перебування. Для любителів спорту пропонуються спортзал, заняття йогою і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 25 на день.\n\nКількість поверхів:   7.  Кількість номерів:   135.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Seville 
                id = cities.FirstOrDefault(x => x.Name == "Севілья").Id;
                hotels.Add(new Hotel
                {
                    Name = "H10 CORREGIDOR BOUTIQUE HOTEL",
                    Stars = 3,
                    Description = @"H10 Corregidor Boutique Hotel пропонує світлі номери в шопінг районі Севільї. Готель H10 Corregidor Boutique оформлений у традиційному стилі і був відкритий в 1975 році. До зручностей в готелі входять обмін валют, гараж і екскурсійне бюро.\n\nРозташування\nЦей високоякісний готель знаходиться в 15 хвилинах ходьби від Тематичний парк Isla Mágica. Помешкання межує з ресторанами і барами, а також River Park, що знаходиться приблизно в 15 хвилинній прогулянці. Кафедральний собор, дзвіниця і музей також знаходяться біля готелю.\nНомери\nІндивідуальний кондиціонер, кавоварка і ноутбук наявні в усіх номерах готелю. Окремі номери мають вид на сад. Ці номери обладнані ванною, безкоштовними туалетно-косметичними засобами і халатами, а також мікрохвильовою піччю, посудомийною машиною і холодильником.\n\nХарчування\nУ кафе готелю подається сніданок шведський стіл. У H10 Corregidor Boutique Hotel є великий ресторан зі смачними стравами. Лобі-бар — це чудове місце, щоб спробувати чай і каву. Кав\'ярня Al Solito Posto розташований в 100 метрах від готелю.\n\nЗа EUR 16 з людини за добу в готелі сервірується сніданок-шведський стіл. \n\nВідпочинок\nДля дозвілля гостям пропонується внутрішній двір і патіо. Для спортивного дозвілля в готелі є спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається громадська парковка за EUR 18 на день.\n\nСпівробітники у готелі розмовляють англійською, іспанською, італійською.\n\nКількість поверхів:   4.  Кількість номерів:   76.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "GRAN MELIA COLON",
                    Stars = 5,
                    Description = @"7-поверховий готель Gran Melia Colon розташований в самому серці Севільї в 15 хвилинах ходьби від La Cartuja Island та відрізняється неперевершеним обслуговуванням. У готелі є номер для алергіків, солярій і басейн на даху. Готель Gran Melia Colon відкрився в 1929 році та пропонує затишні номери. У готелі працює приватний басейн з гідромасажною ванною, сауною і сонячною терасою.\n\nРозташування\nДо центру Севільї можна дістатися пішки за 10 хвилин. До Torre del Oro можна дійти приблизно за 15 хвилин. Цей район відомий музеєм, вежею і церквами. Найближча трамвайна зупинка в 5 хвилинах ходьби. Аеропорт San Pablo в 10 км від готелю.\nНомери\nНомери оснащені не лише власною терасою, сервантом і робочим столом, а й суміжними ванними кімнатами. Деякі номери мають краєвид на сад. У цих номерах гості також можуть знайти електрочайник, кавоварку і кухонну плиту.\n\nХарчування\nЦей готель пропонує гостям сніданок шведський стіл. Чудовий вибір зі страв сучасної кухні подається в ресторані гострих закусок. У кафе-барі є смачні напої. Al-Medina знаходиться близько до готелю.\n\nВідпочинок\nДо зручностей на території готелю входять тераса на даху, відкритий басейн і спільний лаунж. На території готелю є заняття фітнесом, спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається громадська парковка (може знадобитися попереднє замовлення) за EUR 34 на день.\n\nСпівробітники готелю розмовляють англійською, іспанською, італійською.\n\nРік реконструкції:   2012.  Кількість поверхів:   7.  Кількість номерів:   189.".Replace(@"\n", " "),
                    CityId = id
                });




                //-------------------ОАЕ---------------------
                //------ Dubai 
                id = cities.FirstOrDefault(x => x.Name == "Дубаї").Id;
                hotels.Add(new Hotel
                {
                    Name = "URJ AL ARAB JUMEIRAH",
                    Stars = 5,
                    Description = @"Готель Burj Al Arab Jumeirah знаходиться в 20 хвилинах їзди від The Island Dubai і має басейн на даху, веранду для засмаги і кімнату відпочинку. Готель, відкритий у 1999 році в 27-поверховій будівлі, має архітектуру в розкішному стилі і був оновлений в 2005 році. У готелі є звуконепроникні номери, а також безкоштовна парковка, обмін валют і газетний кіоск.\n\nРозташування\nРозташування в мальовничій місцевості пропонує легкий доступ до прекрасного білосніжного пляжу. World Trade Centre розташований в 30 хвилинах їзди від готелю. Поблизу є такі пам\'ятки як Мадінат Джумейра, Wild Wadi Park, а також поля для гольфу і ресторани. Автобусна зупинка Wild Wadi 1 знаходиться в 150 метрах від Готель Burj Al Arab Jumeirah. Поїздка машиною до аеропорту Dubai може зайняти приблизно 30 хвилин.\nНомери\nВсі номери пропонують телевізор з супутниковими каналами, центральне опалення і iPod з аудіосистемою. У деяких номерах є вид на місто. До інших зручностей входять ліжка King-size, двоспальні ліжка і два односпальні ліжка з пледами, ковдрами і вибором подушок, а також мармурова підлога.\n\nХарчування\nКожного ранку у готелі подається сніданок шведський стіл. У ресторані категорії Мішлен ви можете насолодитися стравами місцевої кухні. Снек-бар - це ідеальне місце для того, щоб розслабитися і спробувати освіжаючі напої. The Burj Al Arab і Majlis Al Bahar знаходяться на відстані 100 метрів.\n\nВідпочинок\nДля гостей обладнані оздоровчий центр, оздоровчий клуб і спа-центр. Готель також пропонує спортзал, заняття аеробікою і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, іспанською, італійською, нідерландською, китайською, російською, арабською.\n\nКількість поверхів:   27.  Кількість номерів:   202.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "RIXOS PREMIUM DUBAI",
                    Stars = 5,
                    Description = @"5-зірковий Готель Rixos Premium Dubai розташований за 4.2 км від Дубай. Готель розміщений у 35-поверховій будівлі та оформлений у міському стилі. Готель складається з 414 номерів і має на своїй території обмін валют, салон краси і перукарню.\n\nРозташування\nЗатишне розташування у Дубаї, недалеко від станції метро DAMAC Properties. Пляж Джумейра розміщений в 17 км від готелю. Автобусна зупинка Ritz-Carlton Hotel 1 знаходиться в 150 метрах від Готель Rixos Premium Dubai. За 30 хвилин їзди ви зможете дістатися до аеропорту Al Maktoum.\nНомери\nУ всіх шикарних номерах з видом на море є індивідуальний кондиціонер, міні-бар і особистий сейф. Гості готелю можуть насолодитися неймовірним видом. Номери включають в себе власні ванні кімнати, оснащені душем без піддону, феном і тропічним душем.\n\nХарчування\nГостям пропонують смачно поснідати у ресторані. У готелі знаходиться ресторан для некурців та снек-бар. У барі готелю є більярдний стіл і тераса. Пропонуючи широкий вибір страв, Thyme і Blue Jade знаходяться на пляжі, в 100 метрах від готелю.\n\nПослуги\nНа території готелю можна взяти авто напрокат.\n\nВідпочинок\nУ готелі Rixos Premium Dubai доступні дитячі ліжечка, послуги няні і ігровий майданчик. Можливості для спорту включають спортзал, фітнес-центр і тренажери для бігу.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники готелю розмовляють англійською, німецькою, італійською, російською, турецькою, арабською, гінді, грузинською, Lithuanian, Malay, Swahili, Tagalog / Filipino, українською, Urdu, в\'єтманською.\n\nКількість поверхів:   35.  Кількість номерів:   414.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "WYNDHAM DUBAI MARIN",
                    Stars = 4,
                    Description = @"Готель Wyndham Dubai Marina знаходиться в 20 км від аеропорту Al Maktoum і пропонує обмін валют, парковку і перукарню для комфортного перебування гостей. Готель було відкрито в 2015 році. Цей 4-зірковий готель пропонує безкоштовні маршрутні перевезення, трансфер з аеропорту і цілодобову охорону, а також безкоштовний WiFi.\n\nРозташування\nЗа 15 хвилин ви дістанетесь до Променада The Walk at JBR. З готелю до Burj Khalifa можна доїхати за 50 хвилин. Автобусна зупинка Hilton Jumeira Hotel 2 знаходиться поруч з Готель Wyndham Dubai Marina, приблизно в 10 хвилинах ходьби.\nНомери\nВсі 486 номерів оснащені системою опалення, сейфом і письмовим столом. Готель пропонує неймовірний краєвид на море. Усі власні ванні кімнати мають душову кабіну, туалетно-косметичні засоби і халати.\n\nХарчування\nСніданок готують щоранку і подають у ресторані. Насолодитися гостям пропонують американською кухнею в ресторані American Steakhouse And Add. Ви можете скуштувати чай і каву у кафе-барі. Camoon Restaurant \& Cafe і Burgerfuel JBR Dubai готують широкий асортимент страв і знаходяться в 150 метрах.\n\nПослуги\nДля дослідження місцевості на території є авто і лімузини напрокат.\n\nВідпочинок\nУ готелі Wyndham Dubai Marina є оздоровчий клуб і парна, а також спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, іспанською, італійською, нідерландською, португальською, румунською, китайською, польською, російською, турецькою, арабською, гінді, Tagalog / Filipino, українською, Urdu, в\'єтманською.\n\nКількість поверхів:   32.  Кількість номерів:   486.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HOTEL BUR DUBAI",
                    Stars = 3,
                    Description = @"Готель Wyndham Dubai Marina знаходиться в 20 км від аеропорту Al Maktoum і пропонує обмін валют, парковку і перукарню для комфортного перебування гостей. Готель було відкрито в 2015 році. Цей 4-зірковий готель пропонує безкоштовні маршрутні перевезення, трансфер з аеропорту і цілодобову охорону, а також безкоштовний WiFi.\n\nРозташування\nЗа 15 хвилин ви дістанетесь до Променада The Walk at JBR. З готелю до Burj Khalifa можна доїхати за 50 хвилин. Автобусна зупинка Hilton Jumeira Hotel 2 знаходиться поруч з Готель Wyndham Dubai Marina, приблизно в 10 хвилинах ходьби.\nНомери\nВсі 486 номерів оснащені системою опалення, сейфом і письмовим столом. Готель пропонує неймовірний краєвид на море. Усі власні ванні кімнати мають душову кабіну, туалетно-косметичні засоби і халати.\n\nХарчування\nСніданок готують щоранку і подають у ресторані. Насолодитися гостям пропонують американською кухнею в ресторані American Steakhouse And Add. Ви можете скуштувати чай і каву у кафе-барі. Camoon Restaurant \& Cafe і Burgerfuel JBR Dubai готують широкий асортимент страв і знаходяться в 150 метрах.\n\nПослуги\nДля дослідження місцевості на території є авто і лімузини напрокат.\n\nВідпочинок\nУ готелі Wyndham Dubai Marina є оздоровчий клуб і парна, а також спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, іспанською, італійською, нідерландською, португальською, румунською, китайською, польською, російською, турецькою, арабською, гінді, Tagalog / Filipino, українською, Urdu, в\'єтманською.\n\nКількість поверхів:   32.  Кількість номерів:   486.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Abu Dhabi 
                id = cities.FirstOrDefault(x => x.Name == "Абу-Дабі").Id;
                hotels.Add(new Hotel
                {
                    Name = "KHALIDIYA PALACE RAYHAAN",
                    Stars = 5,
                    Description = @"Khalidiya Palace Rayhaan знаходиться в самому серці Абу-Дабі, неподалік Al Khubeirah Garden, і пропонує розважальний центр, відкритий басейн і зону басейну. Цей комфортабельний готель приймає гостей з 2010 року. У ньому є суміжні номери та послуги парковки, автосервіс і цілодобова охорона.\n\nРозташування\nГості можуть відвідати Marina Mall, що в 2.2 км від готелю. Золотий пляж розташований у хвилині ходьби до готелю. До сувенірних крамниць і торгового центра можна легко дістатися.\nНомери\nДо послуг гостей номери з телебаченням, кавоваркою і приладдям для прасування, а також з власними ванними кімнатами, де є біде, тропічний душ і безкоштовні туалетно-косметичні засоби. Номери мають краєвид на океан. Ці номери також мають мікрохвильову піч, електрочайник і пральну машину.\n\nХарчування\nЩоранку в їдальні готелю подається гарячий сніданок. Гості зможуть насолодитися стравами вегетаріанської кухні в ресторані на терасі з сучасною обстановкою. У готелі є кафе-бар з безкоштовним Wi-Fi, настільним футболом і терасою. Різноманітні страви та напої подають Li Beirut і Rosewater, які розташовані в 5 хвилинах ходьби.\n\nЦей готель надає повний сніданок за додаткову плату. \n\nВідпочинок\nДо того ж, готель пропонує послуги няні, дитячий буфет і міні-клуб. На території є широкий вибір спортивних занять, такі як дайвінг, катання на водних лижах і сафарі по пустелі.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, українською, італійською, китайською, польською, російською, арабською, гінді, індонезійською, африкаансом, Malayalam, PanjabiÂ / Punjabi, словацькою, албанською, Tamil, Tagalog / Filipino, українською, Urdu.\n\nКількість поверхів:   21.  Кількість номерів:   443.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "ANDAZ CAPITAL GATE ABU DHABI - A CONCEPT BY HYATT",
                    Stars = 5,
                    Description = @"Функціональний Готель Hyatt Capital Gate - це 5-зірковий готель з сучасними номерами, що розташований в береговому районі Абу-Дабі. Поєднання шикарного стилю та спокійної атмосфери зробить ваше перебування незабутнім. Умови для відпочинку в готелі включають спільний лаунж і бібліотеку, а також тут є такі зручності, як безкоштовна парковка, обмін валют і сувенірна крамниця.\n\nРозташування\nНайважливіші пам\'ятки Абу-Дабі, такі як Спортивне містечко Шейха Заїда та Церква євангельської громади знаходяться неподалік. Гості швидко доберуться до центру Абу-Дабі, який знаходиться в 9 км від готелю. Поля для гольфу, бари і стадіон знаходяться неподалік.\nНомери\nГотель Hyatt Capital Gate Абу-Дабі надає гостям кімнати, що мають систему клімат-контролю, місце для зберігання речей і сервант. Деякі номери пропонують вид на канал. Гості оцінять наявність фену, біде і безкоштовних туалетно-косметичних засобів в ванних кімнатах.\n\nХарчування\nВи можете пообідати в іменитому ресторані, який пропонує делікатеси авторської кухні. Кафе-бар - це ідеальне місце для того, щоб розслабитися і спробувати смачні напої. До найближчих ресторанів, таких як 18o, Prive і 18 Degrees, легко дістатися.\n\nЩоранку подається повний сніданок за прийнятною ціною. \n\nВідпочинок\nУ готелі Hyatt Capital Gate є спа-центр, парна і солярій, а також спортзал, фітнес-центр і студія фітнесу.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники у готелі розмовляють англійською, німецькою, іспанською, італійською, чешською, російською, арабською, гінді, індонезійською, Macedonian, сербською, Tagalog / Filipino, українською, Urdu.\n\nРік реконструкції:   2011.  Кількість поверхів:   5.  Кількість номерів:   189.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Sharjah  
                id = cities.FirstOrDefault(x => x.Name == "Севілья").Id;
                hotels.Add(new Hotel
                {
                    Name = "RADISSON BLU RESORT SHARJAH",
                    Stars = 5,
                    Description = @"Radisson Blu Resort Sharjah - це елегантний 5-зірковий готель в районі Пляж і узбережжя, що пропонує звуконепроникні номери з видом на місто. Radisson Blu Resort Sharjah приймає гостей у Шарджі з 1982 року. У готелі можна скористатися доставкою преси, послугами носія і чисткою взуття, а також місцем для паління, місцями для паркування і газетним кіоском.\n\nРозташування\nГості оцінять першокласне розташування в центрі, в шопінг районі, поблизу музею і палацу, а також пишного саду і пальмових дерев. До центру Шарджи з готелю можна дійти за 10 хвилин. Безпосередньо біля готелю знаходяться торговий центр і ринок.\nНомери\nRadisson Blu Resort Sharjah має номери, оснащені кабельним телебаченням з фільмами на замовлення, панорамними вікнами і вітальним набором. Гості готелю можуть насолодитися дивовижним видом. Radisson Blu Resort Sharjah також пропонує гостям кухонну плиту, тостер і кухонне приладдя.\n\nХарчування\nСніданок шведський стіл накривають в обідній зоні кожного ранку. Страви місцевої кухні подають у милому традиційному ресторані. Ви можете завітати до лобі-бару на території та спробувати алкогольні напої. Щоб поїсти, гості можуть обрати між El Manza Restaurant і Pizzaro Ristorante.\n\nЗа AED 65 з людини за добу в готелі сервірується сніданок-шведський стіл. \n\nПослуги\nВи можете скористатися послугами прокату човни і авто.\n\nВідпочинок\nRadisson Blu Resort Sharjah пропонує ігровий майданчик, ігрову кімнату і дитячий ресторан для гостей з дітьми. Фітнес-послуги готелю включають спортзал, заняття аеробікою і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, українською, іспанською, італійською, норвежською, китайською, російською, арабською, гінді, Tagalog / Filipino, українською.\n\nРік реконструкції:   2010.  Кількість поверхів:   15.  Кількість номерів:   305.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "COPTHORNE HOTEL SHARJAH",
                    Stars = 4,
                    Description = @"4-зірковий Copthorne Hotel Sharjah розташований на відстані 3.6 км від Nahda Park. Готель з архітектурою в яскравому стилі вміщує 255 номерів. У готелі можна скористатися пральнею, послугами консьєржа і доставкою покупок, а також банкоматом, парковкою і сувенірним магазином.\n\nРозташування\nГотель знаходиться в діловому районі Шарджи, неподалік Al Noor Island. Copthorne Hotel Sharjah розташований в 16 км від A Club. Стадіон і океанаріум знаходяться безпосередньо біля Copthorne Hotel Sharjah. Метро знаходиться в декількох кроках від готелю. Гості можуть дістатися до аеропорту Dubai за 15 хвилин на машині.\nНомери\nГотель оснащений індивідуальним кондиціонером, кавоваркою і апаратурою hi-fi у кожному номері. Деякі з комфортабельних номерів пропонують вид на місто. Copthorne Hotel Sharjah також пропонує гостям мікрохвильову піч, посудомийну машину і тостер.\n\nХарчування\nУ ресторані готелю сервірується поживний сніданок шведський стіл. Ресторан на терасі запрошує скуштувати страви інтернаціональної кухні. Лобі-бар пропонує широкий вибір чаю і кави. Готель розташований в районі Al Majaz, в 5 хвилинах пішки до Bait Al Mandi Restaurant і Katis Restaurant, де можна спробувати широкий вибір страв.\n\nВідпочинок\nВи можете чудово провести час у цілорічному відкритому басейні з сауною, джакузі і баром біля басейну. У Copthorne Hotel Sharjah є заняття фітнесом і спортзал.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал готелю розмовляє англійською, російською, арабською, гінді, Tagalog / Filipino.\n\nКількість поверхів:   11.  Кількість номерів:   255.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "CITYMAX SHARJAH",
                    Stars = 3,
                    Description = @"Citymax Sharjah - це 3-зірковий готель, в якому є безкоштовна приватна парковка, сауна і перукарня. Готель Citymax Sharjah радо приймає гостей в шикарних номерах з 2011 року. Додаткові послуги включають у себе цілодобовий ресепшн, цілодобове обслуговування номерів і хімчистку.\n\nРозташування\nДо аеропорту Dubai можна доїхати за 20 хвилин їзди, а Велика мечеть знаходиться в 14 км. До Сахара центр з готелю можна дістатися за 10 хвилин їзди. Гості можуть провести час, відвідавши океанаріум, розважальні заклади і ресторани, які розташовані поруч з готелем. До станції метро Nakheel Harbour\&Tower 1 можна легко дістатися.\nНомери\nМіні-бар, система клімат-контролю і сейф для ноутбука є стандартними зручностями у номерах. Цей традиційний готель має 239 номерів з власними ванними кімнатами.\n\nХарчування\nГостям щодня пропонується сніданок шведський стіл. У цілодобовому ресторані можна спробувати вишукані страви регіональної кухні. До найближчих ресторанів, таких як Shatee Restaurant, Chappan Bhog і Panda Chinese Restaurant, легко дістатися.\n\nЗа AED 25 з людини за добу в готелі сервірується сніданок-шведський стіл. \n\nВідпочинок\nУ готелі доступні дитячі ліжечка, послуги няні і ігровий майданчик для гостей з дітьми. Любителі спорту можуть скористатися спортзалом, фітнес-центром і студією фітнесу.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники у готелі розмовляють англійською, арабською, гінді, Tagalog / Filipino.\n\nКількість поверхів:   13.  Кількість номерів:   239.".Replace(@"\n", " "),
                    CityId = id
                });





                //-------------------Shri Lanka---------------------
                //------ Columbo   
                id = cities.FirstOrDefault(x => x.Name == "Коломбо").Id;
                hotels.Add(new Hotel
                {
                    Name = "LE PAPILLON",
                    Stars = 5,
                    Description = @"Готель пропонує континентальний сніданок щодня, а також номери з видом на місто. 7 звуконепроникні номери обладнані сучасними зручностями. Додаткові послуги включають у себе пральню, хімчистку і прибирання номерів.\n\nРозташування\nU.S. Embassy знаходиться орієнтовно в 15 хвилинах ходьби. До The Bandaranaike Museum можна дійти за 20 хвилин. Вежа, церква і галерея Коломбо знаходяться в декількох хвилинах ходьби від готелю. Готель розміщений в 20 хвилинах ходьби від залізничної станції Slave Island Railway. Готель Le Papillon в 20 хвилинах їзди від аеропорту Colombo Ratmalana.\nНомери\nГотель Le Papillon надає гостям кімнати, які мають міні-бар, зону відпочинку і письмовий стіл. У номерах гості зможуть скористатися власними ванними кімнатами з душем, феном і біде.\n\nХарчування\nМеню ресторану пропонує страви інтернаціональної кухні. Найближчі ресторани, в тому числі Peach Valley і The Commons, знаходяться в 5 хвилинах ходьби від готелю.\n\nВідпочинок\nУ готелі є дитячі ліжечка, дитяче харчування і дитяче меню для туристів з дітьми.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається безкоштовна приватна парковка.\n\nКількість номерів:   7.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "FAIRWAY COLOMBO",
                    Stars = 4,
                    Description = @"4-зірковий Готель Fairway Colombo пропонує розміщення лише в 2.1 км від Dutch Hospital Shopping Precinct. Розташовуючись у будинку в голландському стилі, готель має 181 кімнат. Додаткові послуги включають у себе пральню, лікаря за викликом і чистку взуття.\n\nРозташування\nВін знаходиться в центрі Коломбо, поруч з Dutch Museum. Гості також можуть відвідати The Bandaranaike Museum, що в 10 хвилинах їзди. Стадіон і казино знаходяться безпосередньо біля Готель Fairway Коломбо. Готель центрально розташований недалеко від залізничної станції Slave Island Railway.\nНомери\nУсі номери в Готель Fairway Colombo оснащені багатоканальним телебаченням, телефоном з міжнародною лінією і телефоном з гучномовцем. До того ж, деякі номери мають вид на місто. Звуконепроникні номери вирізняються дизайном в стилі модерн.\n\nХарчування\nУ Готель Fairway Colombo щодня подають комплексний сніданок для гостей. Ресторан на території готелю містить у меню страви морської кухні. Гості можуть відвідати кафе-бар. Неподалік є декілька ресторанів, включно з Pagoda Tea Room і WIP (Work In Progress).\n\nВідпочинок\nГотель також пропонує дитячі ліжечка і догляд за дітьми.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники готелю розмовляють англійською, китайською, арабською, гінді.\n\nКількість номерів:   181.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Koggala    
                id = cities.FirstOrDefault(x => x.Name == "Когалла").Id;
                hotels.Add(new Hotel
                {
                    Name = "OYO 393 Madoldu Eco Resort",
                    Stars = 3,
                    Description = @"Курортний еко-готель Madoldu розташований у містечку Коггала. До послуг гостей ресторан та безкоштовний Wi-Fi. Відстань від закладу до мальовничого озера Коггала становить 2,4 км.\n\nНомери з видом на озеро оснащені балконом, телевізором та власною ванною кімнатою з душем.\n\nГості курортного еко-готелю Madoldu можуть відпочити у саду і на терасі та скористатися приладдям для барбекю. У закладі облаштовано приміщення для проведення засідань, спільний лаунж та камеру зберігання багажу. На території помешкання та в його околицях можна зайнятися різними видами активного відпочинку, зокрема велоспортом, риболовлею і дайвінгом. Гостям надається безплатна автостоянка.\n\nВідстань від курортного еко-готелю до крикетного стадіону, маяка і форту Галле складає 17,3 км. Міжнародний аеропорт Бандаранаїке розміщений за 167 км від закладу.".Replace(@"\n", " "),
                    CityId = id
                });



                //-------------------Italy---------------------
                //------ Rome     
                id = cities.FirstOrDefault(x => x.Name == "Рим").Id;
                hotels.Add(new Hotel
                {
                    Name = "LE PAPILLON",
                    Stars = 5,
                    Description = @"Готель пропонує континентальний сніданок щодня, а також номери з видом на місто. 7 звуконепроникні номери обладнані сучасними зручностями. Додаткові послуги включають у себе пральню, хімчистку і прибирання номерів.\n\nРозташування\nU.S. Embassy знаходиться орієнтовно в 15 хвилинах ходьби. До The Bandaranaike Museum можна дійти за 20 хвилин. Вежа, церква і галерея Коломбо знаходяться в декількох хвилинах ходьби від готелю. Готель розміщений в 20 хвилинах ходьби від залізничної станції Slave Island Railway. Готель Le Papillon в 20 хвилинах їзди від аеропорту Colombo Ratmalana.\nНомери\nГотель Le Papillon надає гостям кімнати, які мають міні-бар, зону відпочинку і письмовий стіл. У номерах гості зможуть скористатися власними ванними кімнатами з душем, феном і біде.\n\nХарчування\nМеню ресторану пропонує страви інтернаціональної кухні. Найближчі ресторани, в тому числі Peach Valley і The Commons, знаходяться в 5 хвилинах ходьби від готелю.\n\nВідпочинок\nУ готелі є дитячі ліжечка, дитяче харчування і дитяче меню для туристів з дітьми.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається безкоштовна приватна парковка.\n\nКількість номерів:   7.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "FAIRWAY COLOMBO",
                    Stars = 4,
                    Description = @"4-зірковий Готель Fairway Colombo пропонує розміщення лише в 2.1 км від Dutch Hospital Shopping Precinct. Розташовуючись у будинку в голландському стилі, готель має 181 кімнат. Додаткові послуги включають у себе пральню, лікаря за викликом і чистку взуття.\n\nРозташування\nВін знаходиться в центрі Коломбо, поруч з Dutch Museum. Гості також можуть відвідати The Bandaranaike Museum, що в 10 хвилинах їзди. Стадіон і казино знаходяться безпосередньо біля Готель Fairway Коломбо. Готель центрально розташований недалеко від залізничної станції Slave Island Railway.\nНомери\nУсі номери в Готель Fairway Colombo оснащені багатоканальним телебаченням, телефоном з міжнародною лінією і телефоном з гучномовцем. До того ж, деякі номери мають вид на місто. Звуконепроникні номери вирізняються дизайном в стилі модерн.\n\nХарчування\nУ Готель Fairway Colombo щодня подають комплексний сніданок для гостей. Ресторан на території готелю містить у меню страви морської кухні. Гості можуть відвідати кафе-бар. Неподалік є декілька ресторанів, включно з Pagoda Tea Room і WIP (Work In Progress).\n\nВідпочинок\nГотель також пропонує дитячі ліжечка і догляд за дітьми.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники готелю розмовляють англійською, китайською, арабською, гінді.\n\nКількість номерів:   181.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "ROYAL HOTEL",
                    Stars = 3,
                    Description = @"Культурно-історичний Royal Hotel розташований в 20 хвилинах ходьби від Парк Аль-Джазіра у Шарджі. Готель з архітектурою в ісламському стилі вміщує 80 номерів. До послуг гостей запропоновано WiFi на всій території готелю.\n\nРозташування\nГотель знаходиться поруч з Мечеть Корніш і недалеко від Zahra Square - Clock Tower Roundabout. Гості можуть легко дістатися до Торговий центр Блу Саук, що знаходиться приблизно в 3.2 км звідси. Станція метро Nakheel Harbour\&Tower 1 знаходиться поблизу готелю.\nНомери\nЗвуконепроникні номери включають у себе міні-бар, центральне опалення і сервант. Номери виходять вікнами на місто. В розпорядженні гостей у номерах є ванна, душ і банні рушники.\n\nХарчування\nГостям подають сніданок шведський стіл щодня. Ресторан готує страви європейської кухні. Ви можете повечеряти в ресторані KFC за 350 метрів від готелю.\n\nПослуги\nСервіс представлений пральнею, послугами парковки і послугами консьєржа.\n\nВідпочинок\nГотель також пропонує обмін валют, камеру схову багажу і сейф. Гості можуть потренуватися у фітнес-центрі.\n\nІнтернет\nWi-Fi надається в номерах готелю безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nСпівробітники готелю розмовляють англійською, російською, арабською, українською.\n\nКількість номерів:   80.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HILTON SHARJAH",
                    Stars = 5,
                    Description = @"Розташований в самому серці Шарджи, цей стильний готель має 259 номерів, а також оздоровчий клуб, парну і салон краси. Готель Hilton Sharjah оформлений у виточнченому стилі. Гості можуть користуватися високошвидкісний Інтернет та черговим магазином, парковкою і сувенірним магазином.\n\nРозташування\nBlue Souk знаходиться всього в 2.2 км від готелю. Від готелю можна доїхати до P/25 Bar за 60 хвилин. Цей готель відмінно розташований поруч з ресторанами, океанаріумом і стадіоном.\nНомери\nВсі номери у Готель Hilton Sharjah мають сейф для ноутбука, кавоварку і вітальню. Деякі кімнати мають панорамний краєвид на озеро. У ванних кімнатах можна скористатися феном, біде і тропічним душем.\n\nХарчування\nКожного ранку в готелі подають сніданок шведський стіл. Гостям пропонуються повсякденні страви інтернаціональної кухні в великому ресторані. Фреш-бар надає широкий асортимент чаю, освіжаючих напоїв і коктейлів. На території на вибір є різні ресторани, у тому числі Katis Restaurant і Masala Craft.\n\nГотель пропонує гостям сніданок-шведський стіл за ціною AED 96 з людини за добу. \n\nВідпочинок\nУ готелі є відкритий басейн, корт для ракетболу і корти для сквошу, а також дитячі ліжечка, дитяче харчування і послуги няні для дітей. Готель Hilton Sharjah пропонує спортивні заходи для любителів спорту, у тому числі віндсерфінг, піші прогулянки і прогулянки на конях на території.\n\nІнтернет\nВисокошвидкісний доступ в Інтернет в номерах готелю, вартістьAED 100 на день\n\nВисокошвидкісний доступ в Інтернет в номерах готелю, вартістьAED 50 на час\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал у готелі розмовляє англійською, німецькою, російською, арабською, гінді, індонезійською, Tagalog / Filipino, українською.\n\nРік реконструкції:   2011.  Кількість поверхів:   18.  Кількість номерів:   259.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Venice      
                id = cities.FirstOrDefault(x => x.Name == "Венеція").Id;
                hotels.Add(new Hotel
                {
                    Name = "SAGREDO HOTEL",
                    Stars = 5,
                    Description = @"Готель Ca\' Sagredo знаходиться в районі Джудекка і пропонує вид на канал. Готель, оформлений у сучасному стилі та оновлений у 2010 році, містить 4 поверхів. На території готелю є трансфер з аеропорту, прасування і доставка преси для усіх гостей.\n\nРозташування\nN galleria знаходиться в 20 хвилинах їзди, а Мурано - 30 хвилинах ходьби. Цей вражаючий готель знаходиться в центрі Венеції. Ринок, торгові центри і бутики, а також Міст Ріальто знаходяться у пішій доступності. Коротка прогулянка в 10 хвилин приведе до залізничної станції Venice Santa Lucia. Аеропорт Marco Polo розміщений приблизно в 10 км.\nНомери\nНомери готелю пропонують сейф, кавоварку і зону відпочинку. Поселившись в одному з номерів готелю Ca\' Sagredo, можна спостерігати приголомшливий пейзаж з його вікон. Кожна кімната має мармурові ванні кімнати зі стільницею з двома умивальниками, сушаркою і махровими халатами.\n\nХарчування\nРесторан Establishment Include A відкритий з з 12:30 до 14:30 і подає страви місцевої кухні. У снек-барі подають смачні страви та напої. Гості можуть пообідати в L\'Alcova Restaurant at Ca\' Sagredo Hotel і Osteria La Bottega ai Promessi Sposi, які знаходяться в 50 метрах від готелю.\n\nЦей готель надає повний сніданок за додаткову плату. \n\nВідпочинок\nУ готелі можна насолодитися паровою банею і масажем. Для любителів спорту пропонуються заняття фітнесом, спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПарковки немає.\n\nПерсонал у готелі розмовляє англійською, іспанською, італійською.\n\nРік реконструкції:   2010.  Кількість поверхів:   4.  Кількість номерів:   42.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "CARLTON CAPRI",
                    Stars = 3,
                    Description = @"3-зірковий Готель Carlton Capri знаходиться у бізнес-районі місцевості Венеції та пропонує світлі номери. Готель розміщений у 4-поверховому будинку.\n\nРозташування\nTeatro La Fenice розташований на відстані 1.1 км від готелю, а Colonna Commemorativa dei Moti del 1848 в 1.1 км. Завдяки відмінному розташуванню, ви зможете легко дістатися всіх визначних пам\'яток, включно з Rialto Bridge і Scuola Grande dei Carmini. Залізнична станція Венеція-Санта-Лючія в 5 хвилинах ходьби від готелю.\nНомери\nГотель пропонує в номерах мінібар, сейф і кавоварку. Деякі номери мають вид на сад. У розпорядженні гостей душ, фен і туалетно-косметичні засоби.\n\nХарчування\nУ готелі запропоновано великий сніданок шведський стіл. На території готелю є ресторан для гурманів та лобі-бар. Гості можуть відвідати Ostaria al Vecio Pozzo, La Rivetta і Ristorante Pizzeria Al Bacco Felice, що знаходяться приблизно в 100 метрах від готелю.\n\nВідпочинок\nГотель Carlton Capri Венеція надає такі послуги як джакузі і спа-терапія безкоштовно. У готелі є тераса для засмаги, шезлонги і спільний лаунж для проведення вільного часу. Для підтримання спортивної форми в готелі Carlton Capri гостям надані заняття фітнесом і спортзал.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nПарковки немає.\n\nПерсонал готелю розмовляє англійською, іспанською, італійською.\n\nКількість поверхів:   4.  Кількість номерів:   40.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "WE_CROCIFERI",
                    Stars = 5,
                    Description = @"Готель We_Crociferi знаходиться близько до Ponte dei Sospiri і має 127 кімнат з видом на море.\n\nРозташування\nМаючи розташування в районі Кастелло, цей готель знаходиться лише в 15 хвилинах пішки від Punta della Dogana. Готель розташувався в 1 км від центру міста. Coop San Felice розташовано поблизу. Готель знаходиться недалеко від залізничного вокзалу. До аеропорту Венеція Марко Поло можна доїхати на машині.\nНомери\nНомери готелю пропонують гостям балкон, мінікухню і диван. У кожному номері є ванна кімната, що має ванну, душ і рушники.\n\nХарчування\nКожного ранку в готелі подають сніданок шведський стіл. В готелі є цілодобовий ресторан і лаунж-бар. Пройшовши 50 метрів, ви побачите ресторани на будь-який смак, зокрема Osteria Ai Tronchi, Osteria Alla Frasca і Combo.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nПарковки немає.\n\nСпівробітники у готелі розмовляють англійською, іспанською, італійською, португальською.\n\nКількість номерів:   127.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Florence     
                id = cities.FirstOrDefault(x => x.Name == "Флоренція").Id;
                hotels.Add(new Hotel
                {
                    Name = "BERNINI PALACE",
                    Stars = 5,
                    Description = @"Bernini Palace розміщений у районі Палаццо Пітті, у 400 метрах від Базиліка Санта-Кроче, і має номери з видами на собор. Ця будівля була зведена 1550 року. Ви можете скористатись камерою зберігання багажу, сейфом і окремим гаражем.\n\nРозташування\nГотель знаходиться поруч з M.G. Design та кафедральним собором, галереєю і музеєм. Готель знаходиться на відстані 5 хвилин ходьби від Piazza della Signoria. Торгові центри і торгові вулиці знаходяться неподалік від готелю. Готель розміщений в 15 хвилинах ходьби від залізничної станції Santa Maria Novella.\nНомери\nГотель має класичні номери з супутниковим телебаченням, плазмовим телевізором і кавоваркою. Гості готелю можуть насолодитися дивовижним видом. Усі ванні кімнати пропонують ванну, душ без піддону і умивальник.\n\nХарчування\nГотель Bernini Palace щоранку пропонує сніданок шведський стіл. Ресторан для некурців пропонує широкий вибір страв сучасної кухні. Гості можуть відвідати бар або відпочити в ресторані Stylish La Chiostrina. All\'Antico Vinaio і Brown Sugar Lounge Bar пропонують гостям повечеряти і знаходяться вони в 50 метрах від території готелю.\n\nВідпочинок\nГотель пропонує гостям з дітьми дитячі ліжечка і послуги няні. Гості також можуть зайнятися великим тенісом, прогулянками на конях і міні-гольфом.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території знаходиться платна приватна парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, іспанською, італійською, португальською, російською.\n\nКількість поверхів:   5.  Кількість номерів:   74.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "MARTELLI",
                    Stars = 3,
                    Description = @"Привітний 3-зірковий готель Martelli знаходиться у Флоренції. 53 звукоізольовані номери обладнані сучасними зручностями. До послуг гостей цілодобовий ресепшн і пральня.\n\nРозташування\nPalazzo Capponi та Costume Gallery знаходяться в 15 і в 15 хвилинах ходьби відповідно. Завдяки центральному розташуванню, ви зможете легко дістатися всіх визначних пам\'яток, включно з Fontana di Piazza Santa Croce і Uffizi Gallery. До залізничної станції Санта-Марія-Новелла – 10 хвилин пішки.\nНомери\nДеякі номери оснащені кондиціонером, опаленням і балконом для вашої зручності. Деякі кімнати мають відмінний краєвид на гори. Усі номери мають суміжні ванні кімнати, що містять ванну, душ і біде.\n\nХарчування\nЩоранку з 07:30 till 10:30 гості можуть насолодитися континентальним сніданком. Також до послуг гостей затишний бар. Chianineria Trattoria dall\'Oste, Ristorante Alla Griglia і Trattoria Za Za знаходяться в 50 метрах від готелю.\n\nІнтернет\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nПоблизу надається приватна парковка за EUR 24 на день.\n\nПерсонал у готелі розмовляє англійською, іспанською, італійською.\n\nРік реконструкції:   2010.  Кількість поверхів:   4.  Кількість номерів:   53.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HOSTEL 7 SANTI",
                    Stars = 2,
                    Description = @"3-зірковий Hostel 7 Santi пропонує відмінне розміщення в історичній частині Флоренції. Hostel 7 Santi доповнений простими дерев\'яними меблями. У хостелі є такі послуги, як місце для паління і ліфт.\n\nРозташування\nПомешкання розташоване в 3 км від центра Флоренції, де з легкістю можна дістатися до Piazza della Signoria. Гості зможуть повечеряти в La Riseria і Strapizzami e Non Solo, що приблизно в 100 метрах від помешкання. Традиційний хостел розташований поблизу Ponte Vecchio. До залізничної станції Firenze C.M. 5 хвилин пішки.\nНомери\nПомешкання складається з 59 номерів. Hostel 7 Santi пропонує гостям номери з кондиціонером, опаленням і окремим балконом, а також з ліжками укомплектованими шафками, подушками з піни з пам\'яттю і постільною білизною. Відвідувачам пропонують зупинитися в стандартних номерах з регульованими ліжками і односпальними ліжками. У гостей є доступ до власними ванних кімнат. Вони обладнані душовими, душовою кабіною і рукомийником.\n\nВідпочинок\nНічний клуб, сейф і камера схову багажу зроблять ваше перебування у Флоренції незабутнім.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПарковки немає.\n\nКількість номерів:   59.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Verona    
                id = cities.FirstOrDefault(x => x.Name == "Верона").Id;
                hotels.Add(new Hotel
                {
                    Name = "SOLE HOTEL VERONA",
                    Stars = 3,
                    Description = @"Комфортабельний Sole Hotel Verona пропонує своїм гостям 24 звуконепроникних номерів, а також камеру схову багажу, сейф і парковку.\n\nРозташування\nПомешкання розташовується в 1.6 км від Арена ді Верона. Museo di Castelvecchio знаходиться за два кроки від готелю, а Stadio Marcantonio Bentegodi - в 1200 метрах. Стратегічне розташування дозволить насолодитися озерами і річкою. Гості можуть дістатися до залізничної станції Stazione Verona Porta Nuova за 5 хвилин ходьби.\nНомери\nКожен номер пропонує стельовий вентилятор, LCD телевізор і кухню. У багатьох номерах є вид на море. Усі номери в Sole Hotel Verona укомплектовані мікрохвильовою піччю, посудомийною машиною і морозильною камерою, а також ванною, душем і сушаркою.\n\nХарчування\nМісцеві ресторани Trattoria Muramare знаходяться в 950 метрах від готелю.\n\nПослуги\nДля додаткового комфорту в готелі доступні пральня, цілодобова охорона і обслуговування номерів.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 10 на день.\n\nПерсонал готелю розмовляє англійською, німецькою, іспанською, італійською, португальською, російською.\n\nКількість номерів:   24.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "MILANO ",
                    Stars = 4,
                    Description = @"Готель Milano - це 3-зірковий комфортабельний готель з цілодобовою охороною, доставкою преси і послугами носія. Milano - це 4-поверховий готель з 52 світлими номерами. Цей готель має на своїй території камеру схову багажу, приватну парковку і гараж.\n\nРозташування\nІдеальне розташування в районі Старе Місто Верони пропонує легкий доступ до Арена ді Верона, що знаходиться в 5 хвилинах ходьби. Розташування готелю — 1 км від центру Верони. Гості оцінять близькість до кафедрального собору, амфітеатру і театру в діловому районі Верони. Поруч знаходиться залізнична станція Stazione Verona Porta Nuova.\nНомери\nКабельне телебачення, сервант і особистий туалет є, зокрема, в усіх номерах. Деякі номери до того ж мають вид на океан. Готель Milano надає ванні кімнати, оснащені душем, безкоштовними туалетно-косметичними засобами і тапочками.\n\nХарчування\nСніданок шведський стіл сервірується щодня, до того ж на території готелю є снек-бар. Готель пропонує ресторан місцевої кухні. У барі готелю є тераса і Wi-Fi. Різноманітні страви та напої подають Il pizzino da Guido і La Griglia, які розташовані в 5 хвилинах ходьби.\n\nВідпочинок\nНа території готелю можна насолодитися паровою банею, турецькою банею і масажем.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 25 на день.\n\nСпівробітники у готелі розмовляють англійською, німецькою, іспанською, італійською, румунською, російською, Moldovan.\n\nРік реконструкції:   2010.  Кількість поверхів:   4.  Кількість номерів:   52.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HOTEL FIERA",
                    Stars = 4,
                    Description = @"Привабливий Готель Fiera знаходиться у районі Фьєра неподалік Basilica Santa Teresa di Gesu Bambino. З 2000 року готель приймає гостей в самому серці Верони. На території готелю є цілодобовий ресепшн, хімчистка і доставка преси для усіх гостей.\n\nРозташування\nКоротка прогулянка приведе вас до Arco della Costa всього за 30 хвилин. Центр Верони розташований на відстані 3 км. Недалеко від готелю є виставкові центри і конференц-центри. Готель знаходиться в 15 хвилинах ходьби від залізничної станції Stazione Verona Porta Nuova. Найближчий аеропорт - це Valerio Catullo, що в 10 км від готелю.\nНомери\nКожен з номерів для некурців включає в себе високошвидкісний Інтернет, сейф і робочу зону. Деякі номери до того ж мають вид на місто. Номери включають у себе ванні кімнати з ванною, душем без піддону і сушаркою.\n\nХарчування\nЩоранку у ресторані подають сніданок. Гості зможуть пообідати в лаунж-ресторану у готелі. У кафе-барі на території раді запропонувати гостям приємний відпочинок. Trattoria L\'Ortaia зі стравами континентальної кухні знаходиться зовсім поруч.\n\nВідпочинок\nСпортзал і фітнес-центр пропонуються для проведення вільного часу.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, італійською, румунською, російською.\n\nКількість поверхів:   6.  Кількість номерів:   82.".Replace(@"\n", " "),
                    CityId = id
                });





                //-------------------France---------------------
                //------ Lyon   
                id = cities.FirstOrDefault(x => x.Name == "Ліон").Id;
                hotels.Add(new Hotel
                {
                    Name = "RESIDHOTEL LYON PART DIEU",
                    Stars = 3,
                    Description = @"Residhotel Lyon Part Dieu має ідеальне розташування поруч з Communaute Jesuite і складається з 76 номерів з видами на море. Готель приймає гостей у Ліоні з 2000 року.\n\nРозташування\nПомешкання розташовується в 1.2 км від Cinema Bellecombe. Parc Sergent Blandan знаходиться в 15 хвилинах ходьби від готелю. Поряд з готелем розміщується Armee du Salut. Трамвайна зупинка Gare Part-Dieu Vivier Merle та залізнична станція Пар-Дьйо розміщеніо в 300 і 300 метрах від готелю.\nНомери\nДеякі номери містять супутникове телебачення, телевізор з плоским екраном і кавоварку. Номери включають у себе власні ванні кімнати, укомплектовані ванною, душем і феном.\n\nХарчування\nКонтинентальний сніданок доступний на замовлення. У Coeur de Ble, CLASS CROUTE і Cafe Restaurant Double 7 можна повечеряти, пройшовши 50 метрів від готелю.\n\nЩоранку в їдальні готелю подається континентальний сніданок за ціною EUR 8.50 з людини за добу. \n\nВідпочинок\nБез додаткової оплати надаються джакузі і спа-терапія.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка (може знадобитися попереднє замовлення) за EUR 9 на день.\n\nРік реконструкції:   2011.  Кількість поверхів:   8.  Кількість номерів:   76.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "CAMPANILE LYON CENTRE - GARE PART DIEU",
                    Stars = 3,
                    Description = @"Якісний і доступний Готель Campanile Lyon Centre - Gare Part Dieu розташований в 15 хвилинах ходьби від Tour Part-Dieu у Ліоні. Готель приймає гостей з 1990 року і був відреставрований в 2011 році. На території готелю є цілодобовий ресепшн, цілодобова охорона і послуги консьєржа для усіх гостей.\n\nРозташування\nГості оцінять ідеальне розташування готелю в центрі Ліона. До центру Ліона можна прогулятися за 30 хвилин. Такі туристичні місця, як музей і вежа, знаходяться поблизу. Станція метро Станція Part-Dieu розміщена в 5 хвилинах ходьби від готелю.\nНомери\nГотель Campanile Lyon Centre - Gare Part Dieu має в наявності 172 номерів з видами на сад. Вони також обладнані центральним опаленням, місцем для зберігання речей і кавоваркою. Власні ванні кімнати також мають ванну, душ і фен.\n\nХарчування\nГотель Campanile Lyon Centre - Gare Part Dieu пропонує своїм гостям сніданок шведський стіл кожного дня. У ресторані готелю готують страви регіональної кухні. Гості можуть відвідати бар або відпочити в ресторані Famous. Готель розташований всього в 50 метрах від Campanile і Autogrill.\n\nЗа EUR 9.90 з людини за добу в готелі сервірується сніданок-шведський стіл.  Щоранку в їдальні готелю подається сніданок-шведський стіл за ціною EUR 4.75 за ніч з дитини у віці до 10 років. \n\nПослуги\nВ готелі є послуга оренди авто.\n\nВідпочинок\nУ готелі передбачені такі розваги, як караоке і розважальні програми.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка за EUR 10 на день.\n\nСпівробітники у готелі розмовляють англійською, німецькою, іспанською, італійською, японською, російською, арабською, Lithuanian.\n\nРік реконструкції:   2011.  Кількість поверхів:   6.  Кількість номерів:   172.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Orly   
                id = cities.FirstOrDefault(x => x.Name == "Орлі").Id;
                hotels.Add(new Hotel
                {
                    Name = "NOVOTEL PARIS COEUR D'ORLY AIRPORT",
                    Stars = 4,
                    Description = @"Novotel Paris Coeur D\'Orly Airport пропонує чудове помешкання, щоб зупинитися в Орлі. Цей готель поєднує елегантний стиль в архітектурі із сучасними зручностями з 2016 року. Цей готель має на своїй території камеру схову багажу, сейф і парковку.\n\nРозташування\nLe Paris знаходиться в 15 км від готелю, а Rungis \& Co - в 3.4 км. Центр Орлі розміщується в 3 км від готелю. За 20 хвилин ви дійдете до станції метро Rungis - La Fraternelle RER.\nНомери\nДо послуг відвідувачів у всіх номерах є телевізор з супутниковими каналами, система опалення і письмовий стіл і власні ванні кімнати. Також в номерах є електрочайник, посудомийна машина і кавоварка.\n\nХарчування\nНа території знаходиться спорт-бар. Серед ресторанів поруч пропонується Caviar House, розташований в 10 хвилинах ходьби від готелю.\n\nВідпочинок\nNovotel Paris Coeur D\'Orly Airport до того ж надає дитяче харчування, дитяче меню і ігрову кімнату для сімей з дітьми. Для любителів активного відпочинку запропоновані фітнес-центр і фітнес-зал.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається громадська парковка за EUR 23 на день.\n\nКількість поверхів:   6.  Кількість номерів:   163.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "NOVOTEL PARIS COEUR D'ORLY AIRPORT",
                    Stars = 4,
                    Description = @"Novotel Paris Coeur D\'Orly Airport пропонує чудове помешкання, щоб зупинитися в Орлі. Цей готель поєднує елегантний стиль в архітектурі із сучасними зручностями з 2016 року. Цей готель має на своїй території камеру схову багажу, сейф і парковку.\n\nРозташування\nLe Paris знаходиться в 15 км від готелю, а Rungis \& Co - в 3.4 км. Центр Орлі розміщується в 3 км від готелю. За 20 хвилин ви дійдете до станції метро Rungis - La Fraternelle RER.\nНомери\nДо послуг відвідувачів у всіх номерах є телевізор з супутниковими каналами, система опалення і письмовий стіл і власні ванні кімнати. Також в номерах є електрочайник, посудомийна машина і кавоварка.\n\nХарчування\nНа території знаходиться спорт-бар. Серед ресторанів поруч пропонується Caviar House, розташований в 10 хвилинах ходьби від готелю.\n\nВідпочинок\nNovotel Paris Coeur D\'Orly Airport до того ж надає дитяче харчування, дитяче меню і ігрову кімнату для сімей з дітьми. Для любителів активного відпочинку запропоновані фітнес-центр і фітнес-зал.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається громадська парковка за EUR 23 на день.\n\nКількість поверхів:   6.  Кількість номерів:   163.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "SEJOURS & AFFAIRES PARIS-VITRY",
                    Stars = 3,
                    Description = @"Sejours \& Affaires Paris-Vitry - це 3-зірковий комфортабельний готель, який знаходиться поруч з Novita\'Expo. Готель Sejours \& Affaires Paris-Vitry радо приймає гостей в сучасних номерах з 2010 року. Цей 3-зірковий готель пропонує цілодобовий ресепшн, обслуговування номерів і прасування для зручності гостей.\n\nРозташування\nДо Лувр можна дістатися машиною за 10 хвилин. Щоб дістатися з готелю до Ейфелева Вежа, потрібно проїхати 10 хвилин. Також можете знайти торгові центри і ринок в декількох хвилинах від готелю. До станції метро Villejuif-Paul Vaillant-Couturier можна швидко дійти за 15 хвилин.\nНомери\nУсі номери укомплектовано телевізором з супутниковими каналами, центральним опаленням і кавоваркою. Для більшого комфорту ванні кімнати оснащені ванною, душем і феном.\n\nХарчування\nКонтинентальний сніданок, який надає широкий вибір страв, подається кожного ранку. Гості можуть смачно повечеряти в піцерія Factory Lounge, що знаходиться в 100 метрах.\n\nГотель пропонує гостям континентальний сніданок за ціною EUR 8 з людини за добу. \n\nПослуги\nГостям доступні камера схову багажу, сейф і парковка.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка за EUR 8 на день.\n\nСпівробітники готелю розмовляють англійською, іспанською, арабською.\n\nКількість поверхів:   8.  Кількість номерів:   80.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Paris    
                id = cities.FirstOrDefault(x => x.Name == "Париж").Id;
                hotels.Add(new Hotel
                {
                    Name = "VILLA LUTECE PORT ROYAL",
                    Stars = 4,
                    Description = @"4-зірковий Villa Lutece Port Royal оформлений в історичному стилі та розміщений неподалік 13th Arrondissement. Villa Lutece Port Royal приймає гостей у своїх суміжних номерах з 2002 року. Цей 4-зірковий готель пропонує цілодобовий ресепшн, хімчистку і прибирання номерів, а також безкоштовний WiFi.\n\nРозташування\nIle Saint-Louis знаходиться орієнтовно в 20 хвилинах ходьби. До Institut du Monde Arabe можна дійти за 15 хвилин. Поруч з готелем ви можете знайти річку і парки. Гості дійдуть до залізничної станції Jussieu за 10 хвилин. До аеропорту Orly можна доїхати автомобілем за 20 хвилин.\nНомери\nДля зручності гостей в номерах готелю Villa Lutece Port Royal є особистий сейф, холодильник і комора. Також в деяких номерах є вид на море. Кожен номер має великі ванні кімнати з душем, дзеркалом для гоління і безкоштовними туалетно-косметичними засобами.\n\nХарчування\nГості можуть насолодитися сніданком шведський стіл у лобі. У ресторані готелю готують страви інтернаціональної кухні. Гостям пропонують відпочити в барі готелю з улюбленим напоєм. До найближчих ресторанів, таких як Royal Bombay і The Long Red Bar, легко дістатися.\n\nГотель пропонує гостям ситний англійський сніданок за ціною EUR 18 з людини за добу. \n\nВідпочинок\nУ готелі є приватний басейн з джакузі. У наявності є спортзал і фітнес-центр.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається громадська парковка за EUR 2.40 на час.\n\nПерсонал у готелі розмовляє англійською, іспанською, італійською, японською.\n\nКількість поверхів:   4.  Кількість номерів:   39.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HOTEL DANEMARK",
                    Stars = 3,
                    Description = @"3-зірковий Готель Danemark може похизуватися зручним розташуванням в 2 км від Louvre Museum. Готель складається з 15 звукоізольованих номерів. У готелі можна скористатися хімчисткою, обслуговуванням номерів і доставкою преси, а також сейфом, ліфтом і екскурсійним бюро.\n\nРозташування\nГотель розташований у районі 6-й - Сен-Жермен і неподалік Тріумфальна арка. Готель знаходиться в 2 км від центру міста. До того ж, палац, музей і вежа знаходяться безпосередньо біля готелю. Готель розташований поблизу станції метро Станція Raspail і залізничної станції Gare Montparnasse.\nНомери\nУсі номери цього відмінного готелю мають телебачення, прес для брюк і картини. Власні ванні кімнати оснащені душем, феном і безкоштовними туалетно-косметичними засобами для комфорту гостей.\n\nХарчування\nУ готелі щодня накривають континентальний сніданок. Місцеві ресторани La Coupole і Le Timbre знаходяться в 100 метрах від готелю. Гості можуть розслабитися і перекусити в барі готелю.\n\nЩоранку в їдальні готелю подається континентальний сніданок за ціною EUR 11 з людини за добу. \n\nВідпочинок\nЦей готель має на своїй території відкритий плавальний басейн.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу знаходиться платна громадська парковка.\n\nСпівробітники у готелі розмовляють англійською, іспанською, італійською, каталанською, португальською, арабською.\n\nКількість номерів:   15.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "VICTORIA",
                    Stars = 2,
                    Description = @"Victoria - це 2-зірковий чудовий готель, який знаходиться поруч з Grevin Museum. Готель Victoria датується 1970 роком.\n\nРозташування\nЦентр Жоржа Помпіду розташований в 1500 метрах від готелю, а Printemps - на відстані 1200 метрів. Якщо прогулятися від готелю 20 хвилин, то можна дійти до центру Парижа. З готелю можна дістатися до палацу, пам\'ятників і оперного театру. Станція метро Станція Бурс розташована приблизно в 5 хвилинах ходьби.\nНомери\nВсі номери у Готель Victoria Париж мають сейф, патіо і робочий стіл. Ці номери пропонують вид на внутрішній двір. У цих номерах наявні власні ванні кімнати з ванною, душем і феном.\n\nХарчування\nСніданок шведський стіл подають щодня. У готелі є великий ресторан інтернаціональної кухні. У бістро-барі на території можна приємно провести час. Широкий асортимент страв пропонується в Bouillon Chartier і Le Zinc des Cavistes, що у 5 хвилинах ходьби.\n\nГотель пропонує гостям сніданок-шведський стіл за ціною EUR 6 з людини за добу. \n\nПослуги\nГостям надається цілодобовий ресепшн, обслуговування номерів і допомога в підборі турів/квитків, а також камера схову багажу, ліфт і торговий автомат.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПарковки немає.\n\nПерсонал у готелі розмовляє англійською, іспанською, італійською.\n\nКількість поверхів:   4.  Кількість номерів:   103.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "LA CLEF TOUR EIFFEL PARIS",
                    Stars = 5,
                    Description = @"Готель La Clef Tour Eiffel Paris знаходиться в бізнес-районі Парижа, поблизу Montparnasse. Готель має цілодобовий ресторан та 112 сучасних номерів. Ви можете насолодитися доброзичливою атмосферою, а також скористатися камерою зберігання багажу, сейфом і парковкою.\n\nРозташування\nБездоганне розташування в самому серці Парижа поруч вокзалу пропонує швидкий доступ до Єлисейські Поля за 20 хвилин ходьби. Arc de Triomphe розташований у 15 хвилинах ходьби. Музей, театр і вежа знаходяться неподалік. Станція метро Станція Trocadero знаходиться в 5 хвилинах ходьби від готелю. Всього 20 хвилин їзди від готелю до аеропорту Le Bourget.\nНомери\nНомери укомплектовано кондиціонером, центральним опаленням і холодильником, а також посудомийною машиною, кавоваркою і чайником. Кімнати мають винятковий краєвид на вулицю. Також гості зможуть скористатися мармуровими ванними кімнатами з тропічним душем, сушаркою і туалетно-косметичними засобами.\n\nХарчування\nСніданок шведський стіл подають щоранку у ресторані в Готель La Clef Tour Eiffel Paris. Ресторан на території готелю пропонує страви інтернаціональної кухні. Ви можете спробувати каву і сік у снек-барі. Надаючи гостям широкий вибір страв, Jamin і Essaouira знаходяться в 100 метрах.\n\nПослуги\nПослуги прокату авто, велосипедів і лімузинів допоможуть краще вивчити місто.\n\nВідпочинок\nДля дітей надаються дитячі ліжечка, послуги няні і майданчик. Для гостей надаються заняття фітнесом, спортзал і фітнес-центр, що допоможе підтримати спортивну форму.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається приватна парковка за EUR 35 на день.\n\nСпівробітники готелю розмовляють англійською, іспанською, португальською, японською, російською, арабською.\n\nКількість поверхів:   7.  Кількість номерів:   112.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "HOTEL DU COLLECTIONNEUR ARC DE TRIOMPHE",
                    Stars = 5,
                    Description = @"Розміщуючи гостей в гарних номерах, ексклюзивний Hotel Du Collectionneur Arc De Triomphe знаходиться лише в 2.8 км від lovely paris. Du Collectionneur Arc De Triomphe це 5-зірковий готель в французькому стилі. У готелі працює басейн з масажними струменими, купальною кабіною і сауною.\n\nРозташування\nВам сподобається зручне розташування готелю в музейному районі Парижа. Ви можете знайти Musee de l\'Homme лише в 2.2 км від помешкання. Біля готелю розташовані торгові центри і дизайнерські бутики. Готель розміщений в 15 хвилинах ходьби від залізничної станції Gare de Paris-Saint-Lazare.\nНомери\nДеякі номери оснащені кабельним телебаченням з фільмами на замовлення, міні-кухнею і письмовим столом для вашої зручності. Деякі номери до того ж мають вид на сад. Оформлені в паризькому стилі номери обставлені меблями у стилі ар-деко, а також є кавоварка, холодильник і чайник.\n\nХарчування\nГостям пропонують відпочити в доброзичливій атмосфері вишуканого ресторану, де подають страви місцевої кухні. У коктейль-барі є місцеві напої. В шопінг районі є Le Safran і Birdie Num Num, які знаходяться в 50 метрах від готелю.\n\nЩоранку в їдальні готелю подається континентальний сніданок за ціною EUR 20 з людини за добу.  Готель пропонує гостям сніданок-шведський стіл за ціною EUR 39 з людини за добу. \n\nПослуги\nДля дослідження місцевості на території є авто напрокат.\n\nВідпочинок\nДо зручностей відносяться критий басейн, тенісний корт і поле для гольфу. Активним гостям готель пропонує спортзал і фітнес-зал.\n\nІнтернет\nВисокошвидкісний доступ в Інтернет надається в номерах готелю безкоштовно.\n\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території знаходиться платна приватна парковка.\n\nПерсонал готелю розмовляє англійською, німецькою, іспанською, італійською, нідерландською, російською, арабською.\n\nКількість поверхів:   7.  Кількість номерів:   478.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Bordeaux  
                id = cities.FirstOrDefault(x => x.Name == "Бордо").Id;
                hotels.Add(new Hotel
                {
                    Name = "HOTEL DES QUINCONCES",
                    Stars = 5,
                    Description = @"Маючи номер для алергіків і веранду для засмаги, Hotel Des Quinconces пропонує оселитися в одному зі звуконепроникних номерів з видом на місто. Окрім трансферу з аеропорту, прасування і доставки покупок, в готелі є камера схову багажу, парковка і газетний кіоск.\n\nРозташування\nДо центру Бордо можна дістатися пішки за 20 хвилин. CAPC Musee d\'Art Contemporain знаходиться приблизно в 5 хвилинах їзди. Від готелю до трамвайної зупинки Jardin Public всього 450 метрів. До Hotel Des Quinconces можна дістатися за 20 хвилин їзди від аеропорту Mérignac.\nНомери\nУ номерах є такі зручності, як міні-бар, вбиральня і робочий стіл. У всіх номерах є власні ванні кімнаті, оснащені сушаркою, халатами і туалетно-косметичними засобами.\n\nХарчування\nГостям щодня пропонується континентальний сніданок. Le Bouchon Bordelais і Le Pressoir D\'Argent знаходяться на відстані 500 метрів.\n\nВідпочинок\nДля дітей надаються дитячі ліжечка, манеж і дитячий буфет.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nПоблизу надається приватна парковка (може знадобитися попереднє замовлення) за EUR 35 на день.\n\nСпівробітники готелю розмовляють англійською, іспанською, китайською.\n\nКількість номерів:   9.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "LES CRIQUETS HOTEL RESTAURANT SPA",
                    Stars = 4,
                    Description = @"Кількість номерів:   21.".Replace(@"\n", " "),
                    CityId = id
                });


                //-------------------George---------------------
                //------ Batumi 
                id = cities.FirstOrDefault(x => x.Name == "Батумі").Id;
                hotels.Add(new Hotel
                {
                    Name = "EUPHORIA BATUMI CONVENTION & CASINO HOTEL",
                    Stars = 5,
                    Description = @"Готель Euphoria знаходиться на пляжі в безпосередній близькості до Metro City Forum AVM та пропонує цілодобовий ресепшн, пральню і хімчистку. Готель складається з 523 кімнат.\n\nРозташування\nГотель розміщений в 15 хвилинах ходьби від Casino Campione Batumi. Центр міста розташований в 4 км від готелю. Поряд з готелем розміщується Batumi casinos. Завдяки близькому розташуванню автобусної зупинки, гості готелю легко дістануться до будь-якої частини Батумі.\nНомери\nГотель пропонує суміжні номери з кондиціонером, Wi-Fi і сервантом, щоб ваше перебування у Батумі було комфортнішим. Кожен номер пропонує вид на гори. Вони оснащені ванними кімнатами з ванною, душем і біде.\n\nХарчування\nГості можуть пообідати в Mamamia і Eclipse Restaurant, які знаходяться в 50 метрах від готелю.\n\nВідпочинок\nГості можуть скористатися такими зручностями, як сауна і спа-терапія, що надаються безкоштовно. На території Готель Euphoria Батумі є приватний басейн.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nПерсонал у готелі розмовляє англійською, російською, турецькою, грузинською.\n\nКількість номерів:   523.".Replace(@"\n", " "),
                    CityId = id
                });
                hotels.Add(new Hotel
                {
                    Name = "MARANI HOTEL",
                    Stars = 3,
                    Description = @"3-зірковий Marani Hotel пропонує розміщення на відстані 1.4 км від Колесо огляду. Готель має 18 звуконепроникних номерів. Сімейний готель оснащений парковкою і екскурсійним бюро.\n\nРозташування\nГотель знаходиться поруч з Adjara Arts Museum та кафедральним собором і музеєм. Парк 6 травня знаходиться на відстані всього 1.2 км. Поряд з готелем розміщується Батумський університет. Залізничний вокзал знаходиться в декількох кроках від готелю.\nНомери\nУсі номери мають холодильник, кухню і диван для затишного перебування гостей у готелі. Під час перебування у готелі ви можете насолодитися видами на гори. У розпорядженні мешканців власні ванні кімнати з феном, душовою кабіною і рушниками.\n\nХарчування\nЗавітайте до Wine Restaurant Marani, Khinkali House Salkhino і Khinkali House Kalakuri, що знаходяться на відстані 50 метрів.\n\nІнтернет\nWi-Fi надається у всьому готелі безкоштовно.\n\nПарковка\nНа території надається безкоштовна громадська парковка.\n\nПерсонал у готелі розмовляє англійською, російською, турецькою, грузинською.\n\nКількість номерів:   18.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Tbilisi 
                id = cities.FirstOrDefault(x => x.Name == "Тбілісі").Id;
                hotels.Add(new Hotel
                {
                    Name = "MERCURE TBILISI OLD TOWN",
                    Stars = 4,
                    Description = @"".Replace(@"\n", " "),
                    CityId = id
                });


                //-------------------Cuba---------------------
                //------ Varadero   
                id = cities.FirstOrDefault(x => x.Name == "Варадеро").Id;
                hotels.Add(new Hotel
                {
                    Name = "PARADISUS VARADERO RESORT & SPA (ADULTS ONLY)",
                    Stars = 5,
                    Description = @"Шикарний Paradisus Varadero Resort \& Spa (Adults Only) знаходиться неподалік Hicacos Peninsula і має вид на море. Готель був відкритий у 2000 році та має фасад у королівському стилі. Готель надає прекрасне обслуговування і такі зручності, як оздоровчий центр, спа-центр і гідромасажну ванну.\n\nРозташування\nParadisus Varadero Resort \& Spa (Adults Only) надає кімнати з письмовим столом, праскою з дошкою для прасування і DVD програвачем та має бездоганне розташування поблизу до Taller de Ceramica Artistica. Гості також можуть відвідати Parque de Las 8000 Taquillas, що в 20 хвилинах їзди. Неподалік є бухта і тропічний сад.\nНомери\nПоселившись в одному з номерів готелю Paradisus Varadero Resort \& Spa (Adults Only), можна спостерігати дивовижний пейзаж з його вікон.\n\nХарчування\nРесторан готелю Paradisus Varadero Resort \& Spa (Adults Only) подає страви авторської кухні. Ви також можете випити витончені напої в кафе-барі. Серед закладів харчування неподалік є Paradisus Varadero Resort \& Spa.\n\nПослуги\nГості також зможуть взяти човни і авто напрокат.\n\nВідпочинок\nГостям запропонують гідромасаж і парову баню, а також інші послуги. Для спортивного дозвілля в готелі є спортзал, заняття аеробікою і бігова доріжка.\n\nКількість номерів:   421.".Replace(@"\n", " "),
                    CityId = id
                });
                //------ Havana
                id = cities.FirstOrDefault(x => x.Name == "Гавана").Id;
                hotels.Add(new Hotel
                {
                    Name = "E MIRAZUL",
                    Stars = 4,
                    Description = @"4-зірковий Готель E Mirazul, розташований прямо біля Pabellón para la Maqueta de la Capital, має в розпорядженні обмін валют і парковку. Готель пропонує розміщення в Гавані в будівлі 2017 року.\n\nРозташування\nКубинська фабрика мистецтва - в 2.1 км від готелю, а San Francisco de Paula Church Antigua Iglesia De San Francisco De Paula - в 4 км. Гості швидко доберуться до центру Гавани, який знаходиться в 4 км від готелю. Розташування Готель E Mirazul дозволяє швидко дістатися до Пам’ятник загиблим на Броненосному кораблі «Мен».\nНомери\nКожен номер у цьому готелі оснащений безкоштовним Wi-Fi, мінібаром і кондиціонером.\n\nХарчування\nLa Nota, La Carboncita Paladar і Santana пропонують величезний вибір страв у 150 метрах від готелю.\n\nІнтернет\nWi-Fi в зонах загального користування готелю, вартістьUSD 1 на день\n\nПарковка\nНа території надається безкоштовна приватна парковка.\n\nКількість номерів:   8.".Replace(@"\n", " "),
                    CityId = id
                });

                context.AddRange(hotels);
                context.SaveChanges();
            }
        }

        public static void SeedRoomTypes(EFDbContext context)
        {
            if(context.RoomTypes.Count() == 0)
            {
                var roomTypes = new List<RoomType>();

                roomTypes.Add(new RoomType { Name = "Одномітний" });
                roomTypes.Add(new RoomType { Name = "Двухмісний" });
                roomTypes.Add(new RoomType { Name = "Трьохмісний" });
                roomTypes.Add(new RoomType { Name = "Апартаменти" });
                roomTypes.Add(new RoomType { Name = "Делюкс" });
                roomTypes.Add(new RoomType { Name = "Президентський" });

                context.AddRange(roomTypes);
                context.SaveChanges();
            }
        }

        public static void SeedComforts(EFDbContext context)
        {
            if(context.Comforts.Count() == 0)
            {
                var comforts = new List<Comfort>();

                comforts.Add(new Comfort { Name = "WI-FI" });
                comforts.Add(new Comfort { Name = "Ресторан" });
                comforts.Add(new Comfort { Name = "Все включено" });
                comforts.Add(new Comfort { Name = "Спа центр" });
                comforts.Add(new Comfort { Name = "Трансфер до/з аеропорту" });
                comforts.Add(new Comfort { Name = "Басейн" });
                comforts.Add(new Comfort { Name = "Автостоянка" });
                comforts.Add(new Comfort { Name = "Обслуговування номерів" });
                comforts.Add(new Comfort { Name = "Станція для зарядки електромобілів" });

                context.AddRange(comforts);
                context.SaveChanges();
            }
        }

        public static void SeedHotelPhotos(EFDbContext context,IMediator mediator)
        {
            if(context.PhotosToHotels.Count() == 0)
            {
                var photos = new List<AddHotelPhotoCommand>();

                photos.Add(new AddHotelPhotoCommand
                {
                    HotelId = "0adf99cc-2b33-49ce-91ed-cf39a46f2803",
                    PhotosBase64 = new List<string>
                    {
                        "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"
                    },
                });
               

                photos.ForEach(x => mediator.Send(x));
            }
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();


                // Roles: 3
                // Users: 4
                // Countries: 10
                // Cities: 31
                // Airports: 20
                // Hotels: 68
                // RoomTypes: 6
                // Comforts: 9
                // Hotel photos: N/A

                SeederDB.SeedRoles(context, manager, managerRole); // --- DONE
                SeederDB.SeedUsers(context, manager, managerRole); // --- DONE

                SeederDB.SeedCountries(context);
                SeederDB.SeedCities(context);
                SeederDB.SeedAirports(context);
                SeederDB.SeedHotels(context);
                SeederDB.SeedRoomTypes(context);
                SeederDB.SeedComforts(context);
                SeederDB.SeedHotelPhotos(context,mediator);
            }

        }
    }
}
