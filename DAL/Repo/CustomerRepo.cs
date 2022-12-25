using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, Customer>, IAuth<CustomerToken,Customer>
    {
        public Customer Add(Customer obj)
        {
            db.Customers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public CustomerToken Authenticate(Customer obj)
        {
            var data = db.Customers.FirstOrDefault(u => u.Username.Equals(obj.Username) && u.Password.Equals(obj.Password));
            CustomerToken t = null;
            if (data != null)
            {
                string token = Guid.NewGuid().ToString();
                t.CustomerId = obj.Id;
                t.TKey = token;
                t.CreationTime = DateTime.Now;
                db.CustomerTokens.Add(t);
                db.SaveChanges();

            }
            return t;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Customers.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public bool isAuthenticate(string obj)
        {
            var rs = db.CustomerTokens.Any(e => e.TKey.Equals(obj) && e.ExpirationTime == null);
            return rs;
        }

        public bool Logout(string obj)
        {
            var t = db.CustomerTokens.FirstOrDefault(e => e.TKey.Equals(obj));
            if (t != null)
            {
                t.ExpirationTime = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Customer Update(Customer obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
