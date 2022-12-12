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
    public class DivisionService
    {
        public static List<DivisionDTO> Get()
        {
            var data = DataAccessFactory.DivisionDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Division, DivisionDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<DivisionDTO>>(data);
        }

        public static DivisionDTO Get(int id)
        {
            var data = DataAccessFactory.DivisionDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Division, DivisionDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<DivisionDTO>(data);
        }

        public static DivisionDTO Add(DivisionDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DivisionDTO, Division>();
                c.CreateMap<Division, DivisionDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Division>(div);
            var data = DataAccessFactory.DivisionDataAccess().Add(ht);

            if (data != null) return mapper.Map<DivisionDTO>(data);
            return null;
        }

        public static DivisionDTO Update(DivisionDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DivisionDTO, Division>();
                c.CreateMap<Division, DivisionDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Division>(div);
            var data = DataAccessFactory.DivisionDataAccess().Update(ht);

            if (data != null) return mapper.Map<DivisionDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.DivisionDataAccess().Delete(id);
            
            if (data != null) return true;
            return false;
        }


    }
}
