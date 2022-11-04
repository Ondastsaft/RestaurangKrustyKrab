using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table : Template
    {

        internal int Seats { get; set; }
        internal int Quality { get; set; }
        internal Company Company { get; set; }
        internal bool IsAvailable { get; set; }
        internal int TableNumber { get; set; }


        public Table(int seats, int quality, int positionX, int positionY, bool isAvailable, int tableNumber)
        {
            this.Frame = new string[4, 20];
            Seats = seats;
            Quality = quality;
            PositionX = positionX;
            PositionY = positionY;
            IsAvailable = isAvailable;
            TableNumber = tableNumber;
            this.Company = new Company(0);
        }


    }
}
