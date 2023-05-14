using AutoMapper;
using BLL.DTOs.Login;
using DAL;
using DAL.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AuthService
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string email, string pass)
        {
            var result = DataAccessFactory.AuthData().Authenticate(email, pass);
            if (result)
            {
                var token = new Token();
                token.UserEmail = email; 
                token.CreateDate = DateTime.Now;
                token.TokenString= Guid.NewGuid().ToString();   
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var config = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            return null;
        }
        public static bool SellerAccess(string tokenkey)
        {
            var extoken = DataAccessFactory.TokenData().Read(tokenkey);
            var user = DataAccessFactory.UserData().Read();
            var IsSeller = (from u in user
                           where u.Email == extoken.UserEmail
                           select u.Role).FirstOrDefault();
            if (IsSeller.Equals("Seller"))
            {
                return true;
            }
            return false;
        }
        public static bool CustomerAccess(string tokenkey)
        {
            var extoken = DataAccessFactory.TokenData().Read(tokenkey);
            var user = DataAccessFactory.UserData().Read();
            var IsSeller = (from u in user
                            where u.Email == extoken.UserEmail
                            select u.Role).FirstOrDefault();
            if (IsSeller.Equals("Customer"))
            {
                return true;
            }
            return false;
        }
        public static bool AdminAccess(string tokenkey)
        {
            var extoken = DataAccessFactory.TokenData().Read(tokenkey);
            var user = DataAccessFactory.UserData().Read();
            var IsSeller = (from u in user
                            where u.Email == extoken.UserEmail
                            select u.Role).FirstOrDefault();
            if (IsSeller.Equals("Admin"))
            {
                return true;
            }
            return false;
        }
        public static bool DeliveryManAccess(string tokenkey)
        {
            var extoken = DataAccessFactory.TokenData().Read(tokenkey);
            var user = DataAccessFactory.UserData().Read();
            var IsSeller = (from u in user
                            where u.Email == extoken.UserEmail
                            select u.Role).FirstOrDefault();
            if (IsSeller.Equals("DeliveryMan"))
            {
                return true;
            }
            return false;
        }
        public static bool IsTokenValid(string tokenkey)
        {
            var extoken = DataAccessFactory.TokenData().Read(tokenkey);
            if (extoken != null && extoken.ExpiryDate == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extoken = DataAccessFactory.TokenData().Read(tkey);
            extoken.ExpiryDate = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extoken) != null)
            {
                return true;
            }
            return false;
        }
    }
}
