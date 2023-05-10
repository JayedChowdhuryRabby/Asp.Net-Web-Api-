using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PayService
    {
        public static List<PayDTO> Get()
        {
            var data = DataAccessFactory.PayData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Pay, PayDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PayDTO>>(data);
            return mapped;
        }
        public static PayDTO Get(int id)
        {
            var data = DataAccessFactory.PayData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Pay, PayDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PayDTO>(data);
            return mapped;
        }
        public static bool Add(PayDTO cart)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PayDTO, Pay>();
            });
            var mapper = new Mapper(cfg);
            var Getcart = mapper.Map<Pay>(cart);
            var success = DataAccessFactory.PayData().Create(Getcart);
            return success;
        }
        public static bool Update(PayDTO CartDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PayDTO, Pay>();
            });
            var mapper = new Mapper(cfg);
            var GetCart = mapper.Map<Pay>(CartDto);
            var success = DataAccessFactory.PayData().Update(GetCart);
            return success;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PayData().Delete(id);
        }
    }
}
