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
                hotels.Add(new Hotel {
                    Name = "ROYAL LAGOONS AQUA PARK RESORT & SPA",
                    Stars = 5,
                    Description = @"Royal Lagoons Aqua Park Resort \& Spa знаходиться в районі Villages Road, 9 км від Diving Center Hurghada і має в наявності обмін валют, камеру схову багажу і перукарню. Цей 5-зірковий готель був відкритий 2007 році.\n\nРозташування\nRoyal Lagoons Aqua Park Resort \& Spa надає кімнати з системою опалення, кондиціонером і вбиральнею та має центральне розташування поблизу до Hurghada Grand Aquarium. Гості можуть дійти до Нова пристань для яхт, подолавши відстань 8 км звідси. До океанаріуму, барів і ресторанів можна дійти за кілька хвилин.\nНомери\nНомери виходять вікнами на сад.\n\nХарчування\nУ готелі щодня подають сніданок шведський стіл. Ресторан має широкий вибір фірмових делікатесів італійської кухні. Кафе-бар подає місцеві напої кожен день.\n\nПослуги\nRoyal Lagoons Aqua Park Resort \& Spa Хургада надає гостям цілодобовий ресепшн, цілодобове обслуговування номерів і послуги носія.\n\nВідпочинок\nГості можуть насолодитися приватним басейном з водною гіркою, гідромасажною ванною і сауною. Для занять спортом є спортзал, заняття аеробікою і фітнес-центр.\n\nІнтернет\nWi-Fi доступний в в номерах готелю за додаткову плату.\n\nWi-Fi надається в зонах загального користування готелю безкоштовно.\n\nПарковка\nНа території надається безкоштовна громадська парковка.\n\nКількість номерів:   366.".Replace(@"/n","<br />"),                    
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


        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();

                // Roles: 3
                // Users: 4
                // Countries: 10
                // Cities: 31
                // Airports: 20
                // Hotels: 68

                //SeederDB.SeedRoles(context,manager,managerRole); // --- DONE
                //SeederDB.SeedUsers(context, manager, managerRole); // --- DONE

                SeederDB.SeedCountries(context);
                SeederDB.SeedCities(context);
                SeederDB.SeedAirports(context);
                SeederDB.SeedHotels(context);
            }

        }
    }
}
