using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady = true;

        public Kitchen(int fromTop, int fromLeft) : base(fromTop, fromLeft)
        {
            Frame = new string[12, 45];
            FromTop = fromTop;
            FromLeft = fromLeft;

            for (int i = 0; i < 5; i++)
            {
                string name = "Chef " + (i + 1);
                ChefsAtArea.Add(new Chef(name, 0, this.FromTop, this.FromLeft));
            }
        }
    }
}
