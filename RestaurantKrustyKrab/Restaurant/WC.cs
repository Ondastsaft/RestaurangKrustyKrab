namespace RestaurantKrustyKrab.Restaurant
{
    internal class WC : RestaurantArea
    {

        public WC(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[13, 12];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
