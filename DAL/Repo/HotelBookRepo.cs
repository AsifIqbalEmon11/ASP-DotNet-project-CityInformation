using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

    internal class HotelBookRepo : Repo, IRepo<HotelBook, int, HotelBook>
    {
        public HotelBook Add(HotelBook obj)
        {
            db.HotelBooks.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.HotelBooks.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<HotelBook> Get()
        {
            return db.HotelBooks.ToList();
        }

        public HotelBook Get(int id)
        {
            return db.HotelBooks.Find(id);
        }

        public HotelBook Update(HotelBook obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
