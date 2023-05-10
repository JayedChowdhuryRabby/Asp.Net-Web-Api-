using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderDetailService
    {
        public static List<OrderDetailDTO> Get()
        {
            var data = DataAccessFactory.OrderDetailData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDetailDTO>>(data);
            return mapped;
        }
        public static OrderDetailDTO Get(int Id)
        {
            var data = DataAccessFactory.OrderDetailData().Read(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDetailDTO>(data);
            return mapped;
        }
        public static bool Add(OrderDetailDTO orderDetailDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var GetOrderDetail = mapper.Map<OrderDetail>(orderDetailDTO);
            var success = DataAccessFactory.OrderDetailData().Create(GetOrderDetail);
            return success;
        }
        public static bool Update(OrderDetailDTO orderDetailDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetailDTO, OrderDetail>();
            });
            var mapper = new Mapper(cfg);
            var GetOrderDetail = mapper.Map<OrderDetail>(orderDetailDTO);
            var success = DataAccessFactory.OrderDetailData().Update(GetOrderDetail);
            return success;
        }
        public static bool Delete(int Id)
        {
            return DataAccessFactory.CustomerData().Delete(Id);
        }
    }
}
