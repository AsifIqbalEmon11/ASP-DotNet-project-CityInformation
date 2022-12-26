using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class HotelBookService
    {
        public static List<HotelBookDTO> Get()
        {
            var data = DataAccessFactory.HotelBookDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<HotelBook, HotelBookDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<HotelBookDTO>>(data);
        }

        public static HotelBookDTO Get(int id)
        {
            var data = DataAccessFactory.HotelBookDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<HotelBook, HotelBookDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<HotelBookDTO>(data);
        }

        public static HotelBookDTO Add(HotelBookDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<HotelBookDTO, HotelBook>();
                c.CreateMap<HotelBook, HotelBookDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<HotelBook>(div);
            var data = DataAccessFactory.HotelBookDataAccess().Add(ht);

            if (data != null) return mapper.Map<HotelBookDTO>(data);
            return null;
        }

        public static HotelBookDTO Update(HotelBookDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<HotelBookDTO, HotelBook>();
                c.CreateMap<HotelBook, HotelBookDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<HotelBook>(div);
            var data = DataAccessFactory.HotelBookDataAccess().Update(ht);

            if (data != null) return mapper.Map<HotelBookDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.HotelBookDataAccess().Delete(id);

            if (data != false) return true;
            return false;
        }
    }
}
