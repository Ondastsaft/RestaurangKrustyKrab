using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady { get; set; }

        public Kitchen(bool foodIsReady, int positionX, int positionY) : base(positionX, positionY)
        {
            this.Frame = new string[12, 45];
            PositionX = positionX;
            PositionY = positionY;
            FoodIsReady = foodIsReady;
        }
    }
}
