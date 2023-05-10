using AutoMapper;
using BLL.DTOs.SignUp;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }
        public static CustomerDTO Get(int customer_id)
        {
            var data = DataAccessFactory.CustomerData().Read(customer_id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }
        public static bool Add(CustomerDTO customer)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var GetCustomer = mapper.Map<Customer>(customer);
            var success = DataAccessFactory.CustomerData().Create(GetCustomer);
            return success;
        }
        public static bool Update(CustomerDTO customerDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(cfg);
            var GetCustomer = mapper.Map<Customer>(customerDTO);
            var success = DataAccessFactory.CustomerData().Update(GetCustomer);
            return success;
        }
        public static bool Delete(int customer_id)
        {
            return DataAccessFactory.CustomerData().Delete(customer_id);
        }
    }
}
