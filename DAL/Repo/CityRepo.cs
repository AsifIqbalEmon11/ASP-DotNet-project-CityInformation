using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CityRepo : Repo, IRepo<City, int, City>
    {
        public City Add(City obj)
        {
            db.Citys.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Citys.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<City> Get()
        {
            return db.Citys.ToList();
        }

        public City Get(int id)
        {
            return db.Citys.Find(id);
        }

        public City Update(City obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
