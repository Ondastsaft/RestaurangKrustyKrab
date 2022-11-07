using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Fish
{
    internal class Cod : Dish
    {
        public Cod(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "Cod";
            Price = 150;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }
    }
}
