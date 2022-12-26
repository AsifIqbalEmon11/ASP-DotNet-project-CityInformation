namespace DAL.Migrations
{
    using DAL.EF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.ProjectContext context)
        {
            List<Division> div = new List<Division>();
            string[] dname = new string[] { "Dhaka",
                "Rajshahi",
                "Chittagong",
                "Khulna",
                "Slyhet"
            };
            Random rand = new Random();
            for (int i = 1; i <= 5; i++)
            {
                div.Add(new Division()
                {
                    Id = i,
                    Name = dname[rand.Next(0, 5)],

                });
            }
            context.Divisions.AddOrUpdate(div.ToArray());

            List<City> citys = new List<City>();
            string[] name = new string[] { "Uttara",
                "Dhanmondi",
                "Banani",
                "Gulshan",
                "Mirpur"
            };
            
            for (int i = 1; i <= 5; i++)
            {
                citys.Add(new City()
                {
                    Id = i,
                    Name = name[rand.Next(0, 5)],
                    DId = rand.Next(1, 6),

                });
            }
            context.Citys.AddOrUpdate(citys.ToArray());

            List<Hotel> hotels = new List<Hotel>();
            string[] hname = new string[] { "ABC international",
                "Hotel Uttara international",
                "Hotel Greencity international",
                "Hotel Skyview international",
                "Hotel Sonargaon "
            };
            string[] aname = new string[] { "Azampur",
                "Sector-4",
                "Mirpur-14",
                "Dhamondi lake",
                "Gulshan-2"
            };

            for (int i = 1; i <= 5; i++)
            {
                hotels.Add(new Hotel()
                {
                    Id = i,
                    Name = hname[rand.Next(0, 5)],
                    Address = aname[rand.Next(0, 5)],
                    CityId = rand.Next(1, 6),

                });
            }
            context.Hotels.AddOrUpdate(hotels.ToArray());


            List<Room> rooms = new List<Room>();
            string[] names = new string[] { "Regular",
                "Deluxe",
                "Super Deluxe",
                "Premium",
                "Presidential Suite"
            };
            
            for (int i = 1; i < 200; i++)
            {
                rooms.Add(new Room()
                {
                    Id = i,
                    CategoryName = names[rand.Next(0, 5)],
                    Rent = rand.Next(3000, 10000),
                    HotelId = rand.Next(1, 6),
                }); ;
            }
            context.Rooms.AddOrUpdate(rooms.ToArray());

            List<Manager> managers = new List<Manager>();
            string[] manname = new string[] { "Asif",
                "Jamin",
                "Jim "
            };
            string[] db = new string[] { "02-4-22",
                "03-5-09",
            };
            string[] usname = new string[] { "asif11",
                "jim22",
                "jamin33",
            };
            string[] pass = new string[] { "1111",
                "2222",
                "3333",
            };

            for (int i = 1; i <= 2; i++)
            {
                managers.Add(new Manager()
                {
                    Id = i,
                    Name = manname[rand.Next(0, 2)],
                    Username = usname[rand.Next(0, 2)],
                    Password = pass[rand.Next(0, 2)],
                    Gender= "Male",
                    DOB = db[rand.Next(0, 2)],
                    AdminId = 1,

                });
            }
            context.Managers.AddOrUpdate(managers.ToArray());

            List<ManagerToken> mtoken = new List<ManagerToken>();        

            for (int i = 1; i <= 1; i++)
            {
                mtoken.Add(new ManagerToken()
                {
                    Id = i,
                    TKey = "ABCDERFG",
                    CreationTime = System.DateTime.Now,
                    ManagerId=1,

                });
            }
            context.ManagerTokens.AddOrUpdate(mtoken.ToArray());

            List<Admin> admins = new List<Admin>();
            string[] adminanname = new string[] { "Asif",
                "Jamin",
                "Jim "
            };
            string[] admindob = new string[] { "02-4-22",
                "03-5-09",
            };
            string[] adminusname = new string[] { "asif11",
                "jim22",
                "jamin33",
            };
            string[] adminpass = new string[] { "1111",
                "2222",
                "3333",
            };

            for (int i = 1; i <= 2; i++)
            {
                admins.Add(new Admin()
                {
                    Id = i,
                    Name = adminanname[rand.Next(0, 2)],
                    Username = adminusname[rand.Next(0, 2)],
                    Password = adminpass[rand.Next(0, 2)],
                    Gender = "Male",
                    DOB = admindob[rand.Next(0, 2)],


                });
            }
            context.Admins.AddOrUpdate(admins.ToArray());

            List<AdminToken> atoken = new List<AdminToken>();

            for (int i = 1; i <= 1; i++)
            {
                atoken.Add(new AdminToken()
                {
                    Id = i,
                    TKey = "ABCDERFG",
                    CreationTime = System.DateTime.Now,
                    AdminId = 1,

                });
            }
            context.AdminTokens.AddOrUpdate(atoken.ToArray());

            List<RentCar> rents = new List<RentCar>();
            string[] rcname = new string[] { "Hello Rent A Car",
                "Cumilla  Rent A Car",
                "Uttara Rent A Car",
                "Skyview Rent A Car",
                "Muzib Rent A Car "
            };
            string[] catgname = new string[] { "Azampur",
                "Sector-11",
                "Sector-09",
                "Dhamondi-27",
                "Nikunjo-1"
            };
            for (int i = 1; i <= 5; i++)
            {
                rents.Add(new RentCar()
                {
                    Id = i,
                    Name = rcname[rand.Next(0, 5)],
                    Address = catgname[rand.Next(0, 5)],
                    CId = rand.Next(1, 6),

                });
            }
            context.RentCars.AddOrUpdate(rents.ToArray());

            List<Car> cars = new List<Car>();
            string[] carname = new string[] { "Economy",
                "Business",
                "Luxury",
                "Mini Bus",
                "Compact SUV"
            };

            for (int i = 1; i < 200; i++)
            {
                cars.Add(new Car()
                {
                    Id = i,
                    CategoryName = carname[rand.Next(0, 5)],
                    Rent = rand.Next(3000, 10000),
                    RentId = rand.Next(1, 6),
                });
            }
            context.Cars.AddOrUpdate(cars.ToArray());

            List<Customer> customers = new List<Customer>();
            string[] customername = new string[] { "Ahnaf",
                "Sizan",
                "Sarah",
                "Billal",
                "Tonmoy"
            };
            string[] username = new string[] { "Ahnaf12",
                "Sizan34",
                "Sarah45",
                "Billal12",
                "Tonmoy78"
            };
            string[] passw = new string[] { "12345",
                "45678",
                "7997987",
            };
            string[] genderdemo = new string[] { "Male",
                "Female",
            };
            string[] dobdemo = new string[] { "1-8-1998",
                "01-01-1995",
            };
            for (int i = 1; i < 6; i++)
            {
                customers.Add(new Customer()
                {
                    Id = i,
                    Name = customername[rand.Next(0, 5)],
                    Username = username[rand.Next(0, 5)],
                    Password = passw[rand.Next(0, 3)],
                    Gender = genderdemo[rand.Next(0, 2)],
                    DOB = dobdemo[rand.Next(0, 2)],
                    AdminId = rand.Next(1, 8),
                });
            }
            context.Customers.AddOrUpdate(customers.ToArray());



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
