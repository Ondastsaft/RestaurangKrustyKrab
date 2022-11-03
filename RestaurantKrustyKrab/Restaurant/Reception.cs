using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Reception: Template
    {
        internal List<Guest> WaitingList { get; set; }
 
        public Reception(int positionX, int positionY)
        {
            this.Frame = new string[13, 12];
            this.WaitingList = WaitingList;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
