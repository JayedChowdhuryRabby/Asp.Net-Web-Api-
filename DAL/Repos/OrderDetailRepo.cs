using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderDetailRepo : Repo, IRepo<OrderDetail, int, bool>
    {
        public bool Create(OrderDetail obj)
        {
            db.OrderDetails.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.OrderDetails.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<OrderDetail> Read()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail Read(int Id)
        {
            return db.OrderDetails.Find(Id);
        }

        public bool Update(OrderDetail obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}
