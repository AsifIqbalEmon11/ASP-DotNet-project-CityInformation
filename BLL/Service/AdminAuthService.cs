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
    public class AdminAuthService
    {
        public static AdminTokenDTO Authenticate(AdminDTO admin)

        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
                c.CreateMap<AdminDTO,Admin>();
                c.CreateMap<AdminToken, AdminTokenDTO>();
                c.CreateMap<AdminTokenDTO, AdminToken>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Admin>(admin);
            var rs = DataAccessFactory.AdminAuthDataAccess().Authenticate(ht);
            var token = mapper.Map<AdminTokenDTO>(rs);
            return token;
        }
        public static bool IsAuthenticated(string token)
        {
            var rs = DataAccessFactory.AdminAuthDataAccess().isAuthenticate(token);
            return rs;

        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.AdminAuthDataAccess().Logout(token);
        }

    }
}
