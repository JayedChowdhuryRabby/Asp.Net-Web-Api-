using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order, int, bool>
    {
        public bool Create(Order obj)
        {
            db.Orders.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int orderId)
        {
            var ex = Read(orderId);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Order> Read()
        {
            return db.Orders.ToList();
        }

        public Order Read(int orderId)
        {
            return db.Orders.Find(orderId);
        }

        public bool Update(Order obj)
        {
            var ex = Read(obj.orderId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
