using DAL.Interface;
using DAL.Models;
using DAL.Models.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PayRepo : Repo, IRepo<Pay, int, bool>
    {
        public bool Create(Pay obj)
        {
            db.Pays.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Pays.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Pay> Read()
        {
            return db.Pays.ToList();
        }
        public Pay Read(int id)
        {
            return db.Pays.Find(id);
        }
        public bool Update(Pay obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
