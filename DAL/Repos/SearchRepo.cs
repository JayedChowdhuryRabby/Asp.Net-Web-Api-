using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SearchRepo : Repo, IRepo<Search, int, bool>
    {
        public bool Create(Search obj)
        {
            db.Searchs.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var del = Read(id);
            db.Searchs.Remove(del);
            return db.SaveChanges() > 0;
        }

        public List<Search> Read()
        {
            return db.Searchs.ToList();
        }

        public Search Read(int id)
        {
            return db.Searchs.Find(id);
        }

        public bool Update(Search obj)
        {
            var up = Read(obj.search_Id);
            db.Entry(up).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    
    }
}
