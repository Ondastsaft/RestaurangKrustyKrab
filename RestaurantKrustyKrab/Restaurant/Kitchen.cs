using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : Template
    {
  
        internal List<Chef> ChefList { get; set; }
     
        internal bool FoodIsReady { get; set; }
        internal List<Dish> Order { get; set; }

        public Kitchen(bool foodIsReady, int positionX, int positionY)
        {
            this.Frame = new string[12, 45];
            this.ChefList = new List<Chef>();
            PositionX = positionX;
            PositionY = positionY;
            FoodIsReady = foodIsReady;
            Order = new List<Dish>();
        }
    }
}
