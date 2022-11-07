using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady = true;

        public Kitchen(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[12, 45];
            FromTop = fromTop;
            FromLeft = fromLeft;

            for (int i = 0; i < 5; i++)
            {
                string chefName = "Chef " + (i + 1);
                ChefsAtArea.Add(new Chef(chefName, 0, this.FromTop, this.FromLeft));
            }
        }
    }
}
