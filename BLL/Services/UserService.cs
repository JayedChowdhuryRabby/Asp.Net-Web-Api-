using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.Login;
using DAL.Models.Login;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }
        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }
        public static bool Add(UserDTO userDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var GetUser = mapper.Map<User>(userDto);
            var success = DataAccessFactory.UserData().Create(GetUser);
            return success;
        }
        public static bool Update(UserDTO UserDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var GetUser = mapper.Map<User>(UserDto);
            var success = DataAccessFactory.UserData().Update(GetUser);
            return success;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductData().Delete(id);
        }
    }
}
