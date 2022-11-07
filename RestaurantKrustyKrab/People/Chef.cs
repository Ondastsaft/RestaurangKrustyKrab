using RestaurantKrustyKrab.Restaurant;
using System.Transactions;

namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal int Competence { get; set; }
        internal bool Busy { get; set; }
        internal List<Dish> Preparing { get; set; }
        internal int TimeStart { get; set; }
        internal int TimeEnd { get; set; }
        internal bool Cooking { get; set; }

        public Chef(string name, int competence, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            TimeStart = 0;
            Name = name;
            Competence = competence;
            Busy = false;
            Preparing = new List<Dish>();
            Cooking = false;
        }


       

    }
}
