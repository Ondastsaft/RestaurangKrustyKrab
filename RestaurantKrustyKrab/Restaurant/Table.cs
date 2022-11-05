using RestaurantKrustyKrab.People;
using System.Collections;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table : Template
    {

        internal int Seats { get; set; }
        internal int Quality { get; set; }
        internal List<Company> BookedSeats { get; set; }
        internal bool IsAvailable { get; set; }
        internal int TableNumber { get; set; }
        internal Hashtable Orders { get; set; }
        internal bool WaitingForFood { get; set; }

        public Table(int seats, int quality, int positionX, int positionY, bool isAvailable, int tableNumber, bool waitingForFood)
        {
            this.Frame = new string[4, 20];
            Seats = seats;
            Quality = quality;
            PositionX = positionX;
            PositionY = positionY;
            IsAvailable = isAvailable;
            TableNumber = tableNumber;
            this.BookedSeats = new List<Company>();
            this.Orders = new Hashtable();
            WaitingForFood = waitingForFood;
        }


    }
}
