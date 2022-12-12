using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CarRepo : Repo, IRepo<Car, int, Car>
    {
        public Car Add(Car obj)
        {
            db.Cars.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Cars.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Car> Get()
        {
            return db.Cars.ToList();
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public Car Update(Car obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
