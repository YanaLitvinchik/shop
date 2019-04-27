using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GoodRepository : IGoodRepository
    {
        ShopModel db = new ShopModel();
        public void CreateOrUpdate(Good g)
        {
            db.Good.AddOrUpdate(g);
        }
        public Good Get(int id)
        {
            return db.Good.Find(id);
        }
        public IEnumerable<Good> GetAll()
        {
            return db.Good;
        }
        public void Remove(Good g)
        {
            db.Entry(g).State = EntityState.Deleted;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
