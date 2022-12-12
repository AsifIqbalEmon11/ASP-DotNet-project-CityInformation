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
    public class ManagerService
    {
        public static List<ManagerDTO> Get()
        {
            var data = DataAccessFactory.ManagerDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Manager, ManagerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ManagerDTO>>(data);
        }

        public static ManagerDTO Get(int id)
        {
            var data = DataAccessFactory.ManagerDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Manager, ManagerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ManagerDTO>(data);
        }

        public static ManagerDTO Add(ManagerDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ManagerDTO, Manager>();
                c.CreateMap<Manager, ManagerDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Manager>(div);
            var data = DataAccessFactory.ManagerDataAccess().Add(ht);

            if (data != null) return mapper.Map<ManagerDTO>(data);
            return null;
        }

        public static ManagerDTO Update(ManagerDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ManagerDTO, Manager>();
                c.CreateMap<Manager, ManagerDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Manager>(div);
            var data = DataAccessFactory.ManagerDataAccess().Update(ht);

            if (data != null) return mapper.Map<ManagerDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.ManagerDataAccess().Delete(id);
            if (data != false) return true;
            return false;
        }
    }
}
