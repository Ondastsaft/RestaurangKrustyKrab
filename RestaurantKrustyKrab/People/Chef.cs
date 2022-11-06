using RestaurantKrustyKrab.Restaurant;
using System.Transactions;

namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal int Competence { get; set; }
        internal bool Busy { get; set; }
        internal List<Dish> Preparing { get; set; }


        public Chef(string name, int competence, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            Competence = competence;
            this.Busy = false;
            this.Preparing = new List<Dish>();
        }


       

    }
}
