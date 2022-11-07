using RestaurantKrustyKrab.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Fish
{
    internal class SalmonPie : Dish
    {
        public SalmonPie(int destinationTable, string guest) : base(destinationTable, guest)
        {
            Name = "SalmonPie";
            Price = 140;
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;
        }




    }
}
