using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CartLine
    {
        public Good Good { get; set; }
        public int Quantity { get; set; }
    }
}
