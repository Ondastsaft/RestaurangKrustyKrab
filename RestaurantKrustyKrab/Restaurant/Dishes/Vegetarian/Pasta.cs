using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Vegetarian
{
    internal class Pasta : Dish
    {
        public Pasta(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Pasta";
            Price = 80;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
