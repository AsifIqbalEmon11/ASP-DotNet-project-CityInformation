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
    public class CarServices
    {
        public static List<CarDTO> Get()
        {
            var data = DataAccessFactory.CarDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Car, CarDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CarDTO>>(data);
        }

        public static CarDTO Get(int id)
        {
            var data = DataAccessFactory.CarDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Car, CarDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CarDTO>(data);
        }

        public static CarDTO Add(CarDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CarDTO, Car>();
                c.CreateMap<Car, CarDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Car>(div);
            var data = DataAccessFactory.CarDataAccess().Add(ht);

            if (data != null) return mapper.Map<CarDTO>(data);
            return null;
        }

        public static CarDTO Update(CarDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CarDTO, Car>();
                c.CreateMap<Car, CarDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Car>(div);
            var data = DataAccessFactory.CarDataAccess().Update(ht);

            if (data != null) return mapper.Map<CarDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.CarDataAccess().Delete(id);

            if (data != false) return true;
            return false;
        }
    }
}
