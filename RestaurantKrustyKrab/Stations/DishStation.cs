using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant;

namespace RestaurantKrustyKrab.Stations
{
    internal class DishStation : Template
    {

        internal List<Guest> Guests { get; set; }

        public DishStation(int positionX, int positionY)
        {
            Frame = new string[8, 25];
            PositionX = positionX;
            PositionY = positionY;

            Guests = new List<Guest>();
            Guests.Clear();
        }
    }
}
