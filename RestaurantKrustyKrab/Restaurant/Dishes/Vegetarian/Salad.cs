using RestaurantKrustyKrab.People;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Vegetarian
{
    internal class Salad : Dish
    {
        public Salad(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Salad";
            Price = 70;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
