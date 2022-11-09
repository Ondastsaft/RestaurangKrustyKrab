using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class RestaurantArea
    {
        internal string[,] Frame { get; set; }
        //internal Dictionary<string, RestaurantArea> Area { get; set; }
        internal string Name { get; set; }
        internal List<Waiter> WaitersAtArea { get; set; }
        internal List<Chef> ChefsAtArea { get; set; }
        internal Company CompanyAtArea { get; set; }


        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }

        public RestaurantArea(string name, int fromTop, int fromLeft)
        {
            Name = name;
            WaitersAtArea = new List<Waiter>();
            ChefsAtArea = new List<Chef>();
            CompanyAtArea = new Company(0);
            CompanyAtArea.Guests.Clear();
            Frame = new string[1, 1];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
        public virtual void EraseMe()
        {
            for (int i = 0; i < Frame.GetLength(0); i++)
            {
                Console.SetCursorPosition(FromLeft + 1, FromTop + 1);
                Console.Write(new string(' ', Frame.GetLength(1) - 2));
            }

        }

        public virtual void PrintMe()
        {

        }
    }
}
