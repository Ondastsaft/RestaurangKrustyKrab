namespace RestaurantKrustyKrab.Restaurant
{
    internal class DishStation : RestaurantArea
    {
        public DishStation(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[8, 25];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
