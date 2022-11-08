using RestaurantKrustyKrab.People;
using System.Collections;
using System.ComponentModel;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady = true;
        internal Hashtable Dishes { get; set; }
        

        public Kitchen(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[12, 45];
            FromTop = fromTop;
            FromLeft = fromLeft;
            Dishes = new Hashtable();
            Dishes.Add(1,new Dish("Wagyu beef", 500, 0, 0));
            Dishes.Add(2, new Dish("Pasta Bolgonese", 99, 0, 0));
            Dishes.Add(3, new Dish("Hot Hund", 1000, 0, 0));
            Dishes.Add(4, new Dish("Fisk o' Chips", 120, 0, 0));
            Dishes.Add(5, new Dish("Fisk grataine", 120, 0, 0));
            Dishes.Add(6, new Dish("Fisk sticks", 79, 0, 0));
            Dishes.Add(7, new Dish("Halloumi salad", 115, 0, 0));
            Dishes.Add(8, new Dish("Falafel", 79, 0, 0));
            Dishes.Add(9, new Dish("Wok", 10, 0, 0));

            for (int i = 0; i < 5; i++)
            {
                string chefName = "Chef " + (i + 1);
                ChefsAtArea.Add(new Chef(chefName, 0, FromTop + 1, FromLeft + 2));
            }
        }
    }
}
