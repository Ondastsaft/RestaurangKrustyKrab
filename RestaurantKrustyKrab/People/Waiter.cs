namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        internal bool Available { get; set; }
        internal int ServiceLevel { get; set; }
        internal Company WaitersCompany { get; set; }
        internal KeyValuePair<string, Dictionary<string, int>> Area_Order { get; set; }
        internal Dictionary<string, int> Name_MenuIndex = new Dictionary<string, int>();
        public Waiter(string name, int serviceLevel, bool available, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            Available = available;
            WaitersCompany = new Company(0);
        }
    }
}
