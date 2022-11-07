using RestaurantKrustyKrab.People;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantKrustyKrab.Restaurant.Dishes.Meat
{
    internal class Ribs : Dish
    {
        public Ribs(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Ribs";
            Price = 110;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
