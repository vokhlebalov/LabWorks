using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufactures
{
    public class ManufacturesComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            if (x == null && y == null)
                return 0;
            else if (y == null)
                return 1;
            else if (x == null)
                return -1;

            
            if (x is Manufacture && y is Manufacture)
            {
                return (x as Manufacture).CompareTo(y as Manufacture);
            }
            else if (x is Manufacture && !(y is Manufacture))
            {
                return 1;
            }
            else if (!(x is Manufacture) && y is Manufacture)
            {
                return -1;
            }
            return 0;
        }
    }
}
