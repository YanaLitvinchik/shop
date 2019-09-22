using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Validation;


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

            try
            {

                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                    
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                        System.Diagnostics.Debug.WriteLine(err.ErrorMessage + " ");
                        }
                }
            }
        }
    }
}
