using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class DishStation : RestaurantArea
    {
  
        internal List<Guest> WashingBears { get; set; }

        public DishStation(int positionX, int positionY) : base(positionX, positionY)
        {
            this.Frame = new string[8, 25];
            PositionX = positionX;
            PositionY = positionY;
            this.WashingBears = WashingBears;
        }
    }
}
