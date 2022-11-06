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
        List<Waiter> WaitersAtArea = new List<Waiter>();
        List<Chef> ChefsAtArea = new List<Chef>();
        List<Company> CompaniesAtArea = new List<Company>();
        List<Guest> GuestsAtArea = new List<Guest>();
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }

        public RestaurantArea(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }
    }
}
