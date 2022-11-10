using RestaurantKrustyKrab.People;
using System.Collections;
using System.Text;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Kitchen : RestaurantArea
    {
        internal bool FoodIsReady = false;
        private Dictionary<string, Dictionary<string, int>> OrderQueue = new Dictionary<string, Dictionary<string, int>>();
        private Queue<KeyValuePair<string, Dictionary<string, Dish>>> OrdersToServe = new Queue<KeyValuePair<string, Dictionary<string, Dish>>>();
        private Hashtable Dishes { get; set; }
        private Hashtable Chefmaster { get; set; }


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
        public void TakeOrder(KeyValuePair<string, Dictionary<string, int>> order)
        {

            OrderQueue.Add(order.Key, order.Value);

        }
        public void CallForService(string table, List<Dish> dishesToServe)
        {
            Dictionary<string, Dictionary<string, int>> destinationTable_names_MenuIndex = Chefmaster[table] as Dictionary<string, Dictionary<string, int>>;
            Dictionary<string, int> names_MenuIndex = destinationTable_names_MenuIndex[table];
            Dictionary<string, Dish> name_dish = new Dictionary<string, Dish>();

            foreach (var name in names_MenuIndex.Keys)
            {
                name_dish.Add(name, dishesToServe[names_MenuIndex[name]]);

                string dishname = (Dishes[names_MenuIndex[name]] as Dish).Name;
                foreach (Dish dishFromChef in dishesToServe)
                {
                    if (dishFromChef.Name == dishname)
                    {
                        name_dish.Add(name, dishFromChef);
                    }
                }
            }
            OrdersToServe.Enqueue(new KeyValuePair<string, Dictionary<string, Dish>>(table, name_dish));
            Chefmaster.Remove(table);
            FoodIsReady = true;
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("Food is ready");
        }
        public void WorkKitchen()
        {

            for (int i = 0; i < ChefsAtArea.Count; i++)
            {
                bool foodFinished = false;
                if (OrderQueue.Count > 0)
                {
                    if (ChefsAtArea[i].IsAvailable)
                    {
                        ChefsAtArea[i].IsAvailable = false;
                        var order = OrderQueue.First();
                        string destinationTable = order.Key;
                        var names_DishIndexes = order.Value;
                        List<Dish> dishesForChef = new List<Dish>();
                        foreach (int menuIndex in names_DishIndexes.Values)
                        {
                            dishesForChef.Add(Dishes[menuIndex] as Dish);
                        }
                        KeyValuePair<string, List<Dish>> table_Dishes = new KeyValuePair<string, List<Dish>>();
                        Chefmaster.Add(destinationTable, names_DishIndexes);
                        ChefsAtArea[i].Cook(table_Dishes);
                        OrderQueue.Remove(order.Key);
                    }
                    else
                    {
                        foodFinished = ChefsAtArea[i].Cook();
                        if (foodFinished)
                        {
                            KeyValuePair<string, List<Dish>> = ChefsAtArea[i].OrderForTable;
                        }
                    }
                }
            }
        }
        public override void PrintMe()
        {
            int row = 0;
            foreach (Chef chef in ChefsAtArea)
            {
                if (chef.OrderForTable.Value.Count > 1)
                {
                    StringBuilder dishesCookingForTable = new StringBuilder();
                    dishesCookingForTable.Append("Cooking for table " + chef.OrderForTable.Key);
                    foreach (Dish dish in chef.OrderForTable.Value)
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
