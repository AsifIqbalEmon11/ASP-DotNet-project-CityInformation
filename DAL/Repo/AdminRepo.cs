using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>,IAuth<AdminToken,Admin>
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        

        public AdminToken Authenticate(Admin obj)
        {
            var data = db.Admins.FirstOrDefault(u => u.Username.Equals(obj.Username) && u.Password.Equals(obj.Password));
            AdminToken t = null;
            if (data != null)
            {
                string token = Guid.NewGuid().ToString();
                t.AdminId = obj.Id;
                t.TKey = token;
                t.CreationTime = DateTime.Now;
                db.AdminTokens.Add(t);
                db.SaveChanges();

            }

            return t;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Admins.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public bool isAuthenticate(string obj)
        {
            var rs = db.AdminTokens.Any(e => e.TKey.Equals(obj) && e.ExpirationTime == null);
            return rs;
        }

        public bool Logout(string obj)
        {
            var t = db.AdminTokens.FirstOrDefault(e => e.TKey.Equals(obj));
            if (t != null)
            {
                t.ExpirationTime = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Admin Update(Admin obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
