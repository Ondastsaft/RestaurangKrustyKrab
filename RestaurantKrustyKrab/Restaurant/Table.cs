using RestaurantKrustyKrab.People;

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


        public Table(int seats, int quality, int fromTop, int fromLeft, int tableNumber) : base(fromTop, fromLeft)
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
