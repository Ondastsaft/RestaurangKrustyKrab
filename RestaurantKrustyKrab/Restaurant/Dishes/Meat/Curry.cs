using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Meat
{
    internal class Curry : Dish
    {
        public Curry(int price, int destinationTable, string guest) : base(price, destinationTable, guest)
        {
            Name = "Curry";
            Price = 120;
            Quality = quality;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
