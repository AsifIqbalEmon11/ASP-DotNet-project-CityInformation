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
    public class RentCarServices
    {
        public static List<RentCarDTO> Get()
        {
            var data = DataAccessFactory.RentCarDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RentCar, RentCarDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<RentCarDTO>>(data);
        }

        public static RentCarDTO Get(int id)
        {
            var data = DataAccessFactory.RentCarDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RentCar, RentCarDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<RentCarDTO>(data);
        }

        public static RentCarDTO Add(RentCarDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RentCarDTO, RentCar>();
                c.CreateMap<RentCar, RentCarDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<RentCar>(div);
            var data = DataAccessFactory.RentCarDataAccess().Add(ht);

            if (data != null) return mapper.Map<RentCarDTO>(data);
            return null;
        }

        public static RentCarDTO Update(RentCarDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RentCarDTO, RentCar>();
                c.CreateMap<RentCar, RentCarDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<RentCar>(div);
            var data = DataAccessFactory.RentCarDataAccess().Update(ht);

            if (data != null) return mapper.Map<RentCarDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.RentCarDataAccess().Delete(id);

            if (data != false) return true;
            return false;
        }
    }
}
