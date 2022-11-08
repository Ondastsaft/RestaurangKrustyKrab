using RestaurantKrustyKrab.Restaurant;
namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        internal bool Busy { get; set; }
        internal int ServiceLevel { get; set; }
        internal Company Company { get; set; }
        internal List<Dish> Menu { get; set; }
        internal Dictionary<string, Dictionary<string, int>> Area_Order { get; set; }
        internal Dictionary<string, int> Name_MenuIndex { get; set; }
        public Waiter(string name, int serviceLevel, bool busy, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            Busy = busy;
        }
    }
}
