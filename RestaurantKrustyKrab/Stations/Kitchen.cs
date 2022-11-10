using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant;
using RestaurantKrustyKrab.Restaurant.Dishes;

namespace RestaurantKrustyKrab.Stations
{
    internal class Kitchen : Template
    {

        internal List<Chef> ChefList { get; set; }

        internal bool FoodIsReady { get; set; }
        internal Queue<Dish> Orders { get; set; }
        internal Queue<Dish> ReadyOrders { get; set; }

        public Kitchen(bool foodIsReady, int positionX, int positionY)
        {
            Frame = new string[12, 50];
            ChefList = new List<Chef>();
            PositionX = positionX;
            PositionY = positionY;
            FoodIsReady = foodIsReady;
            Orders = new Queue<Dish>();
            ReadyOrders = new Queue<Dish>();

        }

    }
}
