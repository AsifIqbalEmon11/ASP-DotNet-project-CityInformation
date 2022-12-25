using DAL.EF.Models;
using DAL.Interface;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
       public static IRepo<City, int, City> CityDataAccess()
        {
            return new CityRepo();
        }
        public static IRepo<Division, int, Division> DivisionDataAccess()
        {
            return new DivisionRepo();
        }
        public static IRepo<Hotel, int, Hotel> HotelDataAccess()
        {
            return new HotelRepo();
        }
        public static IRepo<Room, int, Room> RoomDataAccess()
        {
            return new RoomRepo();
        }
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<Manager, int, Manager> ManagerDataAccess()
        {
            return new ManagerRepo();
        }
        public static IRepo<Customer, int, Customer> CustomerDataAccess()
        {
            return new CustomerRepo();
        }
        public static IRepo<RentCar, int, RentCar> RentCarDataAccess()
        {
            return new RentCarRepo();
        }
        public static IRepo<Car, int, Car> CarDataAccess()
        {
            return new CarRepo();
        }
        public static IAuth<AdminToken, Admin> AdminAuthDataAccess()
        {
            return new AdminRepo();
        }
        public static IAuth<CustomerToken, Customer> CustomerAuthDataAccess()
        {
            return new CustomerRepo();
        }
        public static IAuth<ManagerToken, Manager> ManagerAuthDataAccess()
        {
            return new ManagerRepo();
        }
        public static IRepo<AdminToken, string, AdminToken> AdminTokenDataAccess()
        {
            return new AdminTokenRepo();
        }
        public static IRepo<ManagerToken, string, ManagerToken> ManagerTokenDataAccess()
        {
            return new ManagerTokenRepo();
        }
        public static IRepo<CustomerToken, string, CustomerToken> CustomerTokenDataAccess()
        {
            return new CustomerTokenRepo();
        }


    }
}
