using DAL.Interface;
using DAL.Models.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, bool>
    {
        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public List<Admin> Read()
        {
            return db.Admins.ToList();
        }
        public Admin Read(int id)
        {
            return db.Admins.Find(id);
        }
        public bool Update(Admin obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
