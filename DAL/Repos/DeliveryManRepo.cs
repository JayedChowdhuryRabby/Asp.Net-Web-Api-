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
    internal class DeliveryManRepo : Repo, IRepo<DeliveryMan, int, bool>
    {
        public bool Authenticate(string email, string pass)
        {
            var data = db.DeliveryMans.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(pass));
            if (data != null) return true;
            return false;
        }

        public bool Create(DeliveryMan obj)
        {
            db.DeliveryMans.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var delman = Read(id);
            db.DeliveryMans.Remove(delman);
            return db.SaveChanges() > 0;

        }

        public List<DeliveryMan> Read()
        {
            return db.DeliveryMans.ToList();
        }

        public DeliveryMan Read(int id)
        {
            return db.DeliveryMans.Find(id);
        }

        public bool Update(DeliveryMan obj)
        {
            var delman = Read(obj.DelId);
            db.Entry(delman).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
