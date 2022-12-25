using AutoMapper;
using BLL.DTO;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class HotelService
    {
        public static List<HotelDTO> Get()
        {
            var data = DataAccessFactory.HotelDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Hotel, HotelDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<HotelDTO>>(data);
        }

        public static HotelDTO Get(int id)
        {
            var data = DataAccessFactory.HotelDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Hotel, HotelDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<HotelDTO>(data);
        }

        public static HotelDTO Add(HotelDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<HotelDTO, Hotel>();
                c.CreateMap<Hotel, HotelDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Hotel>(div);
            var data = DataAccessFactory.HotelDataAccess().Add(ht);

            if (data != null) return mapper.Map<HotelDTO>(data);
            return null;
        }

        public static HotelDTO Update(HotelDTO div)
        {
            var data= DataAccessFactory.HotelDataAccess().Get(div.Id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Hotel, HotelDTO>();
                c.CreateMap<HotelDTO, Hotel>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Hotel>(div);
            data = DataAccessFactory.HotelDataAccess().Update(ht);
            if (data != null) return mapper.Map<HotelDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.HotelDataAccess().Delete(id);

            return data;
        }
    }
}
