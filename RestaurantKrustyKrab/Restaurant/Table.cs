using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table
    {
        internal string[,] DrawTable { get; set; }
        private int Seats { get; set; }
        private int Quality { get; set; }
        private Company Company { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }
        private bool IsAvailable { get; set; }
        internal int TableNumber { get; set; }


        public Table(int seats, int quality, int positionX, int positionY, bool isAvailable, int tableNumber)
        {
            this.DrawTable = new string[4, 20];
            Seats = seats;
            Quality = quality;
            PositionX = positionX;
            PositionY = positionY;
            IsAvailable = isAvailable;
            TableNumber = tableNumber;
        }


    }
}
