using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady = true;

        public Kitchen(int positionX, int positionY) : base(positionX, positionY)
        {
            Frame = new string[12, 45];
            PositionX = positionX;
            PositionY = positionY;

            for (int i = 0; i < 5; i++)
            {
                string name = "Chef " + (i + 1);
                ChefsAtArea.Add(new Chef(name, 0, this.PositionX, this.PositionY));
            }
        }
    }
}
