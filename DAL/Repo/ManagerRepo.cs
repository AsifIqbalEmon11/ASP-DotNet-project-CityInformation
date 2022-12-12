using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ManagerRepo : Repo, IRepo<Manager, int, Manager>
    {
        public Manager Add(Manager obj)
        {
            db.Managers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Managers.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Manager> Get()
        {
            return db.Managers.ToList();
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public Manager Update(Manager obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
