using RestaurantKrustyKrab.Restaurant;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        internal bool Busy { get; set; }
        internal int ServiceLevel { get; set; }
        internal Company CompanyProperty { get; set; }
        internal List<Dish> Menu { get; set; }
        internal List<Dish> Orders { get; set; }
        internal int WipeTimer { get; set; }
        internal int ServingTable { get; set; }
        public Waiter(string name, int serviceLevel, bool busy, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            Busy = busy;
            Orders = new List<Dish>();
            CompanyProperty = new Company(0);
            CompanyProperty.Guests.Clear();
            WipeTimer = -4;
            ServingTable = -1; //means not serving any table


        }

         
    }
}
