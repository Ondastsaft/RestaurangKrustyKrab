using RestaurantKrustyKrab.People;
using System.Collections;
using System.Text;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady = false;
        private Dictionary<string, Dictionary<string, int>> orderQueue = new Dictionary<string, Dictionary<string, int>>();
        internal Hashtable Dishes { get; set; }


        public Kitchen(string name, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
        {
            Frame = new string[12, 45];
            FromTop = fromTop;
            FromLeft = fromLeft;
            Dishes = new Hashtable();
            Dishes.Add(1, new Dish("Wagyu beef", 500, 0, ""));
            Dishes.Add(2, new Dish("Pasta Bolgonese", 99, 0, ""));
            Dishes.Add(3, new Dish("Hot Hund", 1000, 0, ""));
            Dishes.Add(4, new Dish("Fisk o' Chips", 120, 0, ""));
            Dishes.Add(5, new Dish("Fisk grataine", 120, 0, ""));
            Dishes.Add(6, new Dish("Fisk sticks", 79, 0, ""));
            Dishes.Add(7, new Dish("Halloumi salad", 115, 0, ""));
            Dishes.Add(8, new Dish("Falafel", 79, 0, ""));
            Dishes.Add(9, new Dish("Wok", 10, 0, ""));

            for (int i = 0; i < 5; i++)
            {
                string chefName = "Chef " + (i + 1);
                ChefsAtArea.Add(new Chef(chefName, 0, FromTop + 1, FromLeft + 2));
            }
        }
        public void TakeOrder(Dictionary<string, Dictionary<string, int>> order)
        {
            var orderkvp = order.First();
            orderQueue.Add(orderkvp.Key, orderkvp.Value);

        }

        public void WorkKitchen()
        {
            int chefindex = 0;
            foreach (Chef chef in ChefsAtArea)
            {
                if (orderQueue.Count > 0)
                {
                    var orderkvp = orderQueue.First();
                    var order = orderkvp.Value;

                    if (chef.IsAvailable)
                    {
                        chef.IsAvailable = false;
                        foreach (var kvp in order)
                        {
                            var dish = (Dish)Dishes[kvp.Value];
                            dish.DestinationTable = orderkvp.Key;
                            ChefsAtArea[chefindex].DishesCooking.Add(Dishes[kvp.Value] as Dish);
                            ChefsAtArea[chefindex].TimeToCook = 10;
                        }
                        orderQueue.Remove(orderkvp.Key);
                        break;
                    }
                    chefindex++;
                }

            }
        }
        public override void PrintMe()
        {
            int row = 0;
            foreach (Chef chef in ChefsAtArea)
            {
                if (chef.DishesCooking.Count > 1)
                {
                    StringBuilder dishesCookingForTable = new StringBuilder();
                    dishesCookingForTable.Append("Cooking for table " + chef.DishesCooking[0].DestinationTable);
                    foreach (Dish dish in chef.DishesCooking)
                    {
                        dishesCookingForTable.Append(dish.Name + " ");
                    }
                    Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + row);
                    Console.Write(chef.Name + " " + chef.Activity + " " + dishesCookingForTable.ToString());
                }
                else
                {
                    Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + row);
                    Console.Write(chef.Name + " " + chef.Activity);
                }
                row++;
            }

        }
    }
}
