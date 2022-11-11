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
            WaitersAtArea = new List<Waiter>();
        }
        public override void PrintMe()
        {
            int row = 0;
            foreach (Company company in CompanyWaitingQueue)
            {
                Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + row);
                Console.Write(company.Name);
                row++;
            }
            row = 0;
            foreach (Waiter waiter in WaitersAtArea)
            {

                Console.SetCursorPosition(FromLeft - 12, FromTop + 1 + row);
                Console.Write(waiter.Name);
                foreach (Guest guest in waiter.WaitersCompany.Guests)
                {
                    Console.SetCursorPosition(FromLeft - 12, FromTop + 2 + row);
                    Console.Write(guest.Name);
                    row++;
                }

                row++;
                row++;
            }
        }
        public override void EraseMe()
        {
            for (int i = 0; i < Frame.GetLength(0); i++)
            {
                Console.SetCursorPosition(FromLeft - 12, FromTop + 1 + i);
                Console.Write(new string(' ', 10));
            }
        }
    }
}

