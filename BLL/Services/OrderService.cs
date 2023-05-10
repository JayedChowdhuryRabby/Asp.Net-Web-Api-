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
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }
        public static OrderDTO Get(int orderId)
        {
            var data = DataAccessFactory.OrderData().Read(orderId);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }
        public static bool Add(OrderDTO order)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var GetOrder = mapper.Map<Order>(order);
            var success = DataAccessFactory.OrderData().Create(GetOrder);
            return success;
        }
        public static bool Update(OrderDTO orderDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var GetOrder = mapper.Map<Order>(orderDTO);
            var success = DataAccessFactory.OrderData().Update(GetOrder);
            return success;
        }
        public static bool Delete(int orderId)
        {
            return DataAccessFactory.OrderData().Delete(orderId);
        }
    }
}
