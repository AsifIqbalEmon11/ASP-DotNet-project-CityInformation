using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ManagerRepo : Repo, IRepo<Manager, int, Manager>, IAuth<ManagerToken,Manager>
    {
        public Manager Add(Manager obj)
        {
            db.Managers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
      

        public ManagerToken Authenticate(Manager obj)
        {
            var data = db.Managers.FirstOrDefault(u => u.Username.Equals(obj.Username) && u.Password.Equals(obj.Password));
            ManagerToken t = null;
            if (data != null)
            {
                string token = Guid.NewGuid().ToString();
                t.ManagerId = data.Id;
                t.TKey = token;
                t.CreationTime = DateTime.Now;
                db.SaveChanges();

            }
            return t;
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
