using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Reception : RestaurantArea
    {
        internal Queue<Company> CompanyWaitingQueue = new Queue<Company>();

        public Reception(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[13, 25];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
