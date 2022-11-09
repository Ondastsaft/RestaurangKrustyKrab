using RestaurantKrustyKrab.Restaurant;
namespace RestaurantKrustyKrab.People
{
    internal class Guest : Person
        {
        static internal Random random = new Random();
        internal int Prefered_dish { get; set; }
        internal int Money { get; set; }
        internal List<Dish> Order { get; set; }
        internal int Satisfaction { get; set; }
        internal bool Recieved_Order { get; set; }
        internal int Dishing_start { get; set; }
        internal int Dishing_end { get; set; }

        public Guest(string name, int money , int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            Money = money;
            Order = new List<Dish>();
            Prefered_dish = random.Next(1, 10);
            Satisfaction = 0;
            Recieved_Order = false;
            Dishing_start = -1;

        }
    }
}
