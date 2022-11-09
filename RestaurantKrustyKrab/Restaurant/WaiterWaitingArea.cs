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
                WaitersAtArea.Add(new Waiter(waiterName, 0, true, FromTop + 1, FromLeft + 2));
            }

        }
        public override void PrintMe()
        {
            int row = 0;
            foreach (var waiter in WaitersAtArea)
            {
                Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + row);
                Console.Write(waiter.Name);
                row++;
            }
        }
        public override void EraseMe()
        {
            for (int i = 0; i < Frame.GetLength(0) - 1; i++)
            {
                Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + i);
                Console.Write(new string(' ', Frame.GetLength(1) - 2));
            }
        }




    }

}
