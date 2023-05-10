using AutoMapper;
using BLL.DTOs.SignUp;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class CartService
    {
        public static List<CartDTO> Get()
        {
            var data = DataAccessFactory.CartData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Cart, CartDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CartDTO>>(data);
            return mapped;
        }
        public static CartDTO Get(int id)
        {
            var data = DataAccessFactory.CartData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Cart, CartDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CartDTO>(data);
            return mapped;
        }
        public static bool Add(CartDTO cart)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartDTO, Cart>();
            }); 
            var mapper = new Mapper(cfg);
            var Getcart = mapper.Map<Cart>(cart);
            var success = DataAccessFactory.CartData().Create(Getcart);
            return success;
        }
        public static bool Update(CartDTO CartDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CartDTO, Cart>();
            });
            var mapper = new Mapper(cfg);
            var GetCart = mapper.Map<Cart>(CartDto);
            var success = DataAccessFactory.CartData().Update(GetCart);
            return success;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CartData().Delete(id);
        }
    }
}
