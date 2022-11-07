using System;
using RestaurantKrustyKrab.People;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class RestaurantArea
    {
        internal string[,] Frame { get; set; }
        //internal Dictionary<string, RestaurantArea> Area { get; set; }
        internal string Name { get; set; }
        internal List<Waiter> WaitersAtArea = new List<Waiter>();
        internal List<Chef> ChefsAtArea = new List<Chef>();
        internal List<Company> CompaniesAtArea = new List<Company>();
        internal List<Guest> GuestsAtArea = new List<Guest>();
        internal List<Table> TableList = new List<Table>();
        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }

        public RestaurantArea(int fromTop, int fromLeft)
        {
            Frame = new string[1, 1];
            Name = "X";
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
