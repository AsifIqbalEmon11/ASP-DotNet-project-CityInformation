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
    public class RoomService
    {
        public static List<RoomDTO> Get()
        {
            var data = DataAccessFactory.HotelDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Room, RoomDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<RoomDTO>>(data);
        }

        public static RoomDTO Get(int id)
        {
            var data = DataAccessFactory.RoomDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Room, RoomDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<RoomDTO>(data);
        }

        public static RoomDTO Add(RoomDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RoomDTO, Room>();
                c.CreateMap<Room, RoomDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Room>(div);
            var data = DataAccessFactory.RoomDataAccess().Add(ht);

            if (data != null) return mapper.Map<RoomDTO>(data);
            return null;
        }

        public static RoomDTO Update(RoomDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RoomDTO, Room>();
                c.CreateMap<Room, RoomDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Room>(div);
            var data = DataAccessFactory.RoomDataAccess().Update(ht);

            if (data != null) return mapper.Map<RoomDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.RoomDataAccess().Delete(id);

            if (data != false) return true;
            return false;
        }
    }
}
