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
    internal class Falafel : Dish
    {
        public Falafel(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Falafel";
            Price = 90;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
