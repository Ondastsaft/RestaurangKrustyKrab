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
        internal List<Company> CompaniesAtArea { get; set; }
        internal List<Guest> GuestsAtArea { get; set; }

        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }

        public RestaurantArea(string name, int fromTop, int fromLeft)
        {
            Name = name;
            WaitersAtArea = new List<Waiter>();
            ChefsAtArea = new List<Chef>();
            CompaniesAtArea = new List<Company>();
            GuestsAtArea = new List<Guest>();
            Frame = new string[1, 1];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
