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
        public Steak(int price, int destinationTable, string guest) : base(price, destinationTable, guest)
        {
            Name = "Steak";
            Price = 100;
            Quality = quality;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
