using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGoodRepository
    {
        IEnumerable<Good> GetAll();
        void CreateOrUpdate(Good item);
        Good Get(int id);
        void Remove(Good item);
        void SaveChanges();
    }
}
