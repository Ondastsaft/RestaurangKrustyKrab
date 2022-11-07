using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class WaiterWaitingArea : RestaurantArea
    {
        public WaiterWaitingArea(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[7, 15];
            FromTop = fromTop;
            FromLeft = fromLeft;

            for (int i = 0; i < 3; i++)
            {
                string waiterName = "Waiter " + (i + 1);
                WaitersAtArea.Add(new Waiter(waiterName, 0, false, 110, 5));
            }

        }
    }

}
