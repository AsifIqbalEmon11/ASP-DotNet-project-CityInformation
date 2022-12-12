using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class RentCarRepo : Repo, IRepo<RentCar, int, RentCar>
    {
        public RentCar Add(RentCar obj)
        {
            db.RentCars.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.RentCars.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<RentCar> Get()
        {
            return db.RentCars.ToList();
        }

        public RentCar Get(int id)
        {
            return db.RentCars.Find(id);
        }

        public RentCar Update(RentCar obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
