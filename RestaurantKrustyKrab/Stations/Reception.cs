using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant;

namespace RestaurantKrustyKrab.Stations
{
    internal class Reception : Template
    {
        internal List<Guest> WaitingList { get; set; }

        public Reception(int positionX, int positionY)
        {
            Frame = new string[13, 25];
            WaitingList = WaitingList;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
