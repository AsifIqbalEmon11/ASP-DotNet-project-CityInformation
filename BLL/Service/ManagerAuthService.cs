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
    public class ManagerAuthService
    {
        public static ManagerTokenDTO Authenticate(ManagerDTO manager)

        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Manager, ManagerDTO>();
                c.CreateMap<ManagerDTO,Manager>();
                c.CreateMap<ManagerToken, ManagerTokenDTO>();
                c.CreateMap<ManagerTokenDTO, ManagerToken>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Manager>(manager);
            var rs = DataAccessFactory.ManagerAuthDataAccess().Authenticate(ht);
            var token = mapper.Map<ManagerTokenDTO>(rs);
            return token;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = DataAccessFactory.ManagerTokenDataAccess().Get(token);
            if (tk != null && tk.ExpirationTime == null)
            {
                return true;
            }
            return false;

        }
    }
}
