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
    public class CityService
    {
        public static List<CityDTO> Get()
        {
            var data = DataAccessFactory.CityDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<City, CityDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CityDTO>>(data);
        }

        public static CityDTO Get(int id)
        {
            var data = DataAccessFactory.CityDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<City, CityDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CityDTO>(data);
        }

        public static CityDTO Add(CityDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CityDTO, City>();
                c.CreateMap<City, CityDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<City>(div);
            var data = DataAccessFactory.CityDataAccess().Add(ht);

            if (data != null) return mapper.Map<CityDTO>(data);
            return null;
        }

        public static CityDTO Update(CityDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CityDTO, City>();
                c.CreateMap<City, CityDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<City>(div);
            var data = DataAccessFactory.CityDataAccess().Update(ht);

            if (data != null) return mapper.Map<CityDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.CityDataAccess().Delete(id);
            if (data != null) return false;
            return false;
        }
    }
}
