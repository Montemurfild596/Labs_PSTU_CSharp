using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    internal class SortByCost : IComparer<Item>
    {
        int IComparer<Item>.Compare(Item x, Item y)
        {
            return String.Compare(x.Cost.ToString(), y.Cost.ToString());
        }
    }
}
