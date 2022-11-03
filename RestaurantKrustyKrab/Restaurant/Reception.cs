using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Reception
    {
        internal string[,] DrawReception { get; set; }
        internal List<Guest> WaitingList { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }

        public Reception(int positionX, int positionY)
        {
            this.DrawReception = new string[13, 12];
            this.WaitingList = WaitingList;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
