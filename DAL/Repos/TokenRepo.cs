using DAL.Interface;
using DAL.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Read()
        {
            return db.Tokens.ToList();
        }

        public Token Read(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenString.Equals(id));
        }

        public Token Update(Token obj)
        {
            var token = Read(obj.TokenString);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
            return null;
        }
    }
}
