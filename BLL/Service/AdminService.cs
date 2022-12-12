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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<AdminDTO>>(data);
        }

        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<AdminDTO>(data);
        }

        public static AdminDTO Add(AdminDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Admin>(div);
            var data = DataAccessFactory.AdminDataAccess().Add(ht);

            if (data != null) return mapper.Map<AdminDTO>(data);
            return null;
        }

        public static AdminDTO Update(AdminDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Admin>(div);
            var data = DataAccessFactory.AdminDataAccess().Update(ht);

            if (data != null) return mapper.Map<AdminDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Delete(id);
            if (data != false) return true;
            return false;
        }
    }
}
