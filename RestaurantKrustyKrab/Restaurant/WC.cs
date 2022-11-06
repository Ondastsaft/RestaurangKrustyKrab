namespace RestaurantKrustyKrab.Restaurant
{
    internal class WC : RestaurantArea
    {
   
        public WC(int positionX, int positionY)
        {
            this.Frame = new string[13, 12];
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
