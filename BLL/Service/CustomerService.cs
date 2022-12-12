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
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CustomerDTO>>(data);
        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomerDTO>(data);
        }

        public static CustomerDTO Add(CustomerDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Customer>(div);
            var data = DataAccessFactory.CustomerDataAccess().Add(ht);

            if (data != null) return mapper.Map<CustomerDTO>(data);
            return null;
        }

        public static CustomerDTO Update(CustomerDTO div)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var ht = mapper.Map<Customer>(div);
            var data = DataAccessFactory.CustomerDataAccess().Update(ht);

            if (data != null) return mapper.Map<CustomerDTO>(data);
            return null;
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Delete(id);
            if (data != false) return true;
            return false;
        }
    }
}
