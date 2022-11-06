using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class WaiterWaitingArea : RestaurantArea
    {
        public WaiterWaitingArea(int positionX, int positionY) : base(positionX, positionY)
        {
            PositionX = positionX;
            PositionY = positionY;

            for (int i = 0; i < 3; i++)
            {
                string name = "Waiter " + (i + 1);
                WaitersAtArea.Add(new Waiter(name, 0, false, 110, 3));
            }

        }
    }

}
