using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Login;
using DAL;
using DAL.Models;
using DAL.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService
    {
        public static List<TokenDTO> Get()
        {
            var data = DataAccessFactory.TokenData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TokenDTO>>(data);
            return mapped;
        }
    }
    
}
