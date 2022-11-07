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
        public SalmonPie(int price, int destinationTable, string guest) : base(price, destinationTable, guest)
        {
            Name = "SalmonPie";
            Price = 140;
            Quality = quality;
            DestinationTable = destinationTable;
            Guest = guest;
        }




    }
}
