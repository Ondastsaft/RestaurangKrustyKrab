using System.Security.Cryptography.X509Certificates;
using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class WC : RestaurantArea
    {
   
        public WC(int fromTop, int fromLeft) : base(fromTop, fromLeft)
        {
            Frame = new string[13, 12];
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}
