using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop0._1.Models
{
    public interface IRange
    {
        IEnumerable<int> GetRange(int a, int b);
    }
    public class Range: IRange
    {
        public IEnumerable<int> GetRange(int a, int b)
        {
            for (int i = a; i <= b; i++)
                yield  return i;
        }
    }
}