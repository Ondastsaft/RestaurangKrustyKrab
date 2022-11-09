using RestaurantKrustyKrab.Restaurant;

namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal bool IsAvailable { get; set; }
        internal int Competence { get; set; }
        public string Activity { get; set; }
        public string OrderforTable { get; set; }
        public List<Dish> DishesCooking { get; set; }
        internal int TimeToCook { get; set; }

        public Chef(string name, int competence, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Name = name;
            Competence = competence;
            DishesCooking = new List<Dish>();
        }
    }
}
