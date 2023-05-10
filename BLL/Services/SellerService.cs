using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.SignUp;

namespace BLL.Services
{
    public class SellerService
    {
        public static List<SellerDTO> Get()
        {
            var data = DataAccessFactory.SellerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seller, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SellerDTO>>(data);
            return mapped;
        }
        public static SellerDTO Get(int id)
        {
            var data = DataAccessFactory.SellerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seller, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SellerDTO>(data);
            return mapped;
        }
        public static bool Add(SellerDTO seller)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerDTO, Seller>();
            });
            var mapper = new Mapper(cfg);
            var GetSeller = mapper.Map<Seller>(seller);
            var success = DataAccessFactory.SellerData().Create(GetSeller);
            return success;
        }
        public static bool Update(SellerDTO SellerDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerDTO, Seller>();
            });
            var mapper = new Mapper(cfg);
            var GetSeller = mapper.Map<Seller>(SellerDto);
            var success = DataAccessFactory.SellerData().Update(GetSeller);
            return success;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.SellerData().Delete(id);
        }
    }
}
