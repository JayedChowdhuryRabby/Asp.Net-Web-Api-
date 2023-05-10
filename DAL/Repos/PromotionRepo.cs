using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PromotionRepo : Repo, IRepo<Promotion, int, bool>
    {
        public bool Create(Promotion obj)
        {
            db.Promotions.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var prompt = Read(id);
            db.Promotions.Remove(prompt);
            return db.SaveChanges() > 0;
        }

        public List<Promotion> Read()
        {
            return db.Promotions.ToList();
        }

        public Promotion Read(int id)
        {
            return db.Promotions.Find(id);
        }

        public bool Update(Promotion obj)
        {
            var prompt = Read(obj.prompid);
            db.Entry(prompt).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    
    }
}
