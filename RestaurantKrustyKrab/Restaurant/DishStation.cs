using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class DishStation : RestaurantArea
    {
        public DishStation(int fromTop, int fromLeft) : base(fromTop, fromLeft)
        {
            Frame = new string[8, 25];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
