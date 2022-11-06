using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Reception : RestaurantArea
    {
        internal Queue<Company> CompanyWaitingQueue = new Queue<Company>();
        internal List<Guest> WaitingList { get; set; }
        internal List<Waiter> WaiterList { get; set; }


        public Reception(int positionX, int positionY)
        {

            this.Frame = new string[13, 25];
            this.WaitingList = WaitingList;
            this.WaiterList = WaiterList;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
