namespace RestaurantKrustyKrab.People
{
    internal class Guest : Person
    {
        public string OrderedFood { get; set; }
        public string Activity { get; set; }
        public Guest(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Activity = "Waiting";

        }
    }
}
