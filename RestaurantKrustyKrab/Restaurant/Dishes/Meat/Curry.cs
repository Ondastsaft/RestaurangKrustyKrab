using RestaurantKrustyKrab.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Meat
{
    internal class Curry : Dish
    {
        public Curry(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Curry";
            Price = 120;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
