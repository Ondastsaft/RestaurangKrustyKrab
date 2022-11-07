using RestaurantKrustyKrab.People;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantKrustyKrab.Restaurant.Dishes.Meat
{
    internal class Steak : Dish
    {
        public Steak(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Steak";
            Price = 100;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
