using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ProjectContext : DbContext
    {
        public DbSet<Division> Divisions { get; set; }
        public DbSet<City> Citys { get; set;}
        public DbSet<Hotel> Hotels { get; set;}
        public DbSet<HotelBook> HotelBooks { get; set; }
        public DbSet<Car> Cars { get; set;}
        public DbSet<RentCar> RentCars { get; set;}
        public DbSet<Room> Rooms { get; set;}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AdminToken> AdminTokens { get; set; }

        public DbSet<CustomerToken> CustomerTokens { get; set; }
        public DbSet<ManagerToken> ManagerTokens { get; set; }

    }
}
