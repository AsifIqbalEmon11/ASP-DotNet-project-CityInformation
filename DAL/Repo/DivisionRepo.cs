using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DivisionRepo : Repo, IRepo<Division, int, Division>
    {
        public Division Add(Division obj)
        {
            db.Divisions.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Divisions.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Division> Get()
        {
            return db.Divisions.ToList();
        }

        public Division Get(int id)
        {
            return db.Divisions.Find(id);
        }
        public Division Update(Division obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
