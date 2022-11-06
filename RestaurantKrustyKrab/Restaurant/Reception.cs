using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Reception : RestaurantArea
    {
        internal Queue<Company> CompanyWaitingQueue = new Queue<Company>();

        public Reception(int positionX, int positionY) : base(positionX,positionY)
        {
            this.Frame = new string[13, 25];
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
