namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        internal bool Available { get; set; }
        internal int ServiceLevel { get; set; }
        internal Company Company { get; set; }
        internal Dictionary<string, Dictionary<string, int>> Area_Order = new Dictionary<string, Dictionary<string, int>>();
        internal Dictionary<string, int> Name_MenuIndex = new Dictionary<string, int>();
        public Waiter(string name, int serviceLevel, bool available, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            Available = available;
            Company = new Company(0);
        }
    }
}
