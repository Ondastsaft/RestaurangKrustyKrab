using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class DishStation : RestaurantArea
    {
        public DishStation(int positionX, int positionY) : base(positionX, positionY)
        {
            Frame = new string[8, 25];
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
