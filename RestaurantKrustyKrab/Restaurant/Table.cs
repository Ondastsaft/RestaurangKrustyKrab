using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table : RestaurantArea
    {

        internal int Seats { get; set; }
        internal int Quality { get; set; }
        internal Company Company { get; set; }
        internal bool IsAvailable { get; set; }
        internal int TableNumber { get; set; }
        internal Waiter WaiterAtTable { get; set; }


        public Table(int seats, int quality, int positionX, int positionY, bool isAvailable, int tableNumber) : base(positionX, positionY)
        {
            this.Frame = new string[4, 20];
            Seats = seats;
            Quality = quality;
            PositionX = positionX;
            PositionY = positionY;
            IsAvailable = isAvailable;
            TableNumber = tableNumber;
        }


    }
}
