using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerTokenRepo : Repo, IRepo<CustomerToken, string, CustomerToken>
    {
        public CustomerToken Add(CustomerToken obj)
        {
            db.CustomerTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerToken> Get()
        {
            throw new NotImplementedException();
        }

        public CustomerToken Get(string id)
        {
            return db.CustomerTokens.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public CustomerToken Update(CustomerToken obj)
        {
            var dbobj = Get(obj.TKey);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
