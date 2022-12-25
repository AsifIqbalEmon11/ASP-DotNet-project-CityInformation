using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminTokenRepo : Repo, IRepo<AdminToken, string, AdminToken>
    {
        public AdminToken Add(AdminToken obj)
        {
            db.AdminTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var dbobj = Get(id);
            db.AdminTokens.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<AdminToken> Get()
        {
            return db.AdminTokens.ToList();
        }

        public AdminToken Get(string id)
        {
            return db.AdminTokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public AdminToken Update(AdminToken obj)
        {
            var dbobj = Get(obj.TKey);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
