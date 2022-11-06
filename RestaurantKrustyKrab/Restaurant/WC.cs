using System.Security.Cryptography.X509Certificates;
using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class WC : RestaurantArea
    {
   
        public WC(int positionX, int positionY) : base(positionX, positionY)
        {
            this.Frame = new string[13, 12];
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
