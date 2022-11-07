using RestaurantKrustyKrab.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant.Dishes.Fish
{
    internal class Sushi : Dish
    {
        public Sushi(int price, int destinationTable, string guest) : base(price, destinationTable, guest)
        {
            Name = "Sushi";
            Price = 130;
            Quality = quality;
            DestinationTable = destinationTable;
            Guest = guest;
        }




    }
}
