using RestaurantKrustyKrab.People;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table : RestaurantArea
    {

        internal int Seats { get; set; }
        internal int Quality { get; set; }
        internal Company Company { get; set; }

        internal bool IsAvailable = true;
        internal int TableNumber { get; set; }
        internal Waiter WaiterAtTable { get; set; }


        public Table(string name, int fromTop, int fromLeft, int seats, int quality, int tableNumber) : base(name, fromTop, fromLeft)
        {
            Frame = new string[4, 20];
            Seats = seats;
            Quality = quality;
            FromTop = fromTop;
            FromLeft = fromLeft;
            TableNumber = tableNumber;
        }


    }
}
