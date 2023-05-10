using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, bool>
    {
        public bool Create(Customer obj)
        {
            db.Customers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int customer_id)
        {
            var ex = Read(customer_id);
            db.Customers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Customer> Read()
        {
            return db.Customers.ToList();
        }

        public Customer Read(int customer_id)
        {
            return db.Customers.Find(customer_id);
        }

        public bool Update(Customer obj)
        {
            var ex = Read(obj.customer_id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
