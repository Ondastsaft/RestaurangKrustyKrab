using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class DishStation
    {
        internal string[,] DrawDishes { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }
        internal List<Guest> WashingBears { get; set; }

        public DishStation(int positionX, int positionY)
        {
            this.DrawDishes = new string[8, 25];
            PositionX = positionX;
            PositionY = positionY;
            this.WashingBears = WashingBears;
        }
    }
}
