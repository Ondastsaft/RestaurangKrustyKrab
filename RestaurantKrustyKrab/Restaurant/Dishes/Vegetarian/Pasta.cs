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
        public Pasta(int price, int destinationTable, string guest) : base(price, destinationTable, guest)
        {
            Name = "Pasta";
            Price = 80;
            Quality = quality;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
