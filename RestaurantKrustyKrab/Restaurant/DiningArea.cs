using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class DiningArea : RestaurantArea
    {
        internal List<Table> tables = new List<Table>();
        internal DiningArea(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[13, 25];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }

    }
}
