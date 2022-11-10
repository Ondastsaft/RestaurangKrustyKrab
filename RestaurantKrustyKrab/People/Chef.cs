using RestaurantKrustyKrab.Restaurant;

namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal bool IsAvailable { get; set; }
        internal int Competence { get; set; }
        public string Activity { get; set; }
        public KeyValuePair<string, List<Dish>> OrderforTable { get; set; }
        private int TimeToCook { get; set; }

        public Chef(string name, int competence, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Name = name;
            Competence = competence;
        }

        public void Cook()
        {
            if (!IsAvailable)
            {
                if (TimeToCook > 0)
                {
                    TimeToCook--;
                }
                if (TimeToCook == 0)
                {

                }
            }

        }
        public void Cook(KeyValuePair<string, List<Dish>> order)
        {
            OrderforTable = order;
            TimeToCook = 10;
            IsAvailable = false;
        }
    }
}
