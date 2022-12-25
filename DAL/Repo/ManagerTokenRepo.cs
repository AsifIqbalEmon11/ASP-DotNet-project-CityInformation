using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ManagerTokenRepo : Repo, IRepo<ManagerToken, string, ManagerToken>
    {
        public ManagerToken Add(ManagerToken obj)
        {
            db.ManagerTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var dbobj = Get(id);
            db.ManagerTokens.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<ManagerToken> Get()
        {
            return db.ManagerTokens.ToList();
        }

        public ManagerToken Get(string id)
        {
            return db.ManagerTokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public ManagerToken Update(ManagerToken obj)
        {
            var dbobj = Get(obj.TKey);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
