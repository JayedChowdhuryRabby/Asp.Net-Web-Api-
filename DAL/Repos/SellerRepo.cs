using DAL.Interface;
using DAL.Models.Login;
using DAL.Models.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SellerRepo : Repo, IRepo<Seller, int, bool>
    {
        public bool Create(Seller obj)
        {
            db.Sellers.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Sellers.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Seller> Read()
        {
            return db.Sellers.ToList();
        }
        public Seller Read(int id)
        {
            return db.Sellers.Find(id);
        }
        public bool Update(Seller obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
