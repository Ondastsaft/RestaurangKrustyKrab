using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen
    {
        internal string[,] DrawKitchen { get; set; }
        internal List<Chef> ChefList { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }
        internal bool FoodIsReady { get; set; }

        public Kitchen(bool foodIsReady, int positionX, int positionY)
        {
            this.DrawKitchen = new string[12, 45];
            this.ChefList = ChefList;
            PositionX = positionX;
            PositionY = positionY;
            FoodIsReady = foodIsReady;
        }
    }
}
