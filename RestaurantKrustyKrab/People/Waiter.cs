using RestaurantKrustyKrab.Restaurant;
namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        internal bool Busy { get; set; }
        internal int ServiceLevel { get; set; }
        internal Company Company { get; set; }
        internal List<Dish> Menu { get; set; }
        internal List<Dish> Order { get; set; }
        public Waiter(string name, int serviceLevel, bool busy, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            Busy = busy;
        }
    }
}
