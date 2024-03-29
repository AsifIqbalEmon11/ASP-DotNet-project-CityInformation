﻿using AutoMapper;
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
        public static bool IsAuthenticated(string token)
        {
            var rs = DataAccessFactory.ManagerAuthDataAccess().isAuthenticate(token);
            return rs;

        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.ManagerAuthDataAccess().Logout(token);
        }

    }
}
