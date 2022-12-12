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


    }
}
