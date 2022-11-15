using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    {
        internal string[,] MyDrawing { get; set; }
        internal string Name { get; set; }
        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }
        internal Dictionary<string, RestaurantArea> MyRestaurantAreas { get; set; } 
        internal int CounterRestaurant { get; set; }
        public int Time { get; set; }
        public Lobby()
        {
            MyRestaurantAreas = new Dictionary<string, RestaurantArea>();
            MyRestaurantAreas.Add("Kitchen", new Kitchen("Kitchen", 3, 155));
            MyRestaurantAreas = GenerateTables(MyRestaurantAreas);
            MyRestaurantAreas.Add("Reception", new Reception("Reception", 3, 31));
            MyRestaurantAreas.Add("WC", new WC("WC", 25, 188));
            MyRestaurantAreas.Add("WaiterWaitingArea", new WaiterWaitingArea("Waiters", 3, 105));
            MyRestaurantAreas.Add("DishStation", new DishStation("Washing Bears", 3, 125));
            CounterRestaurant = 0;
            MyDrawing = new string[50, 200];
            Name = "Krusty Krab";
            FromTop = 2;
            FromLeft = 2;
            Time = 0;
        }
        //LoopMetoder
        public void LobbyRun()
        {
            Window.OurDraw(Name, FromTop, FromLeft, MyDrawing);
            Draw();
            PrintAllAreas();

            while (true)
            {
                LoopRestaurant();

            }
        }
        public void LoopRestaurant()
        {

            CompanyArrivalRandomizer();
            WorkWaiter();
            Console.ReadKey();
            (MyRestaurantAreas["Kitchen"] as Kitchen).WorkKitchen();

            CounterRestaurant++;
            Console.SetCursorPosition(25, 3);
            Console.Write(CounterRestaurant.ToString());
        }
        private void CompanyArrivalRandomizer()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number < 100 && (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count < 10)
            {
                (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Enqueue
                    (new Company((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count));
            }
        }
        //Servitörens LoopMetoder
        private void WorkWaiter()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                if (kvp.Value is Table)
                {
                    if ((kvp.Value as Table).WaiterAtTable != null)
                    {
                        (kvp.Value as Table).WaiterAtTable.Available = true;
                    }
                }

            }//Luddig Reset

            for (int i = 0; i < (MyRestaurantAreas["WaiterWaitingArea"] as WaiterWaitingArea).WaitersAtArea.Count; i++)
            {
                bool continueloop = true;
                if ((MyRestaurantAreas["WaiterWaitingArea"] as WaiterWaitingArea).WaitersAtArea[i].Available && (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count > 0)
                {
                    continueloop = GreetCompany("WaiterWaitingArea", i);
                }
            }//GreetCompany

            for (int i = 0; i < (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count; i++)
            {
                ShowTable("Reception", i);
            }//ShowTable

            foreach (var kvp in MyRestaurantAreas)
            {
                if (kvp.Value is Table && (kvp.Value as Table).CompanyAtArea.Guests.Count > 0 && (kvp.Value as Table).WaiterAtTable.Available && !(kvp.Value as Table).HasOrdered)
                {
                    TakeOrderFromGuest(kvp.Key);
                }
            } //Take Order

            foreach (var kvp in MyRestaurantAreas)
            {
                if (kvp.Value is Table && (kvp.Value as Table).HasOrdered && (kvp.Value as Table).WaiterAtTable.Area_Order.Value != null &&
                    (kvp.Value as Table).WaiterAtTable.Area_Order.Value.Count > 0 && (kvp.Value as Table).WaiterAtTable.Available)
                {
                    PlaceOrderAtKitchen(kvp.Key);
                }
            }//PlaceOrder
        }

        private void ResetWaiter()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                if (kvp.Value is Table)
                {
                    if ((kvp.Value as Table).WaiterAtTable != null)
                    {
                        if (kvp.Value is Table && (kvp.Value as Table).WaiterAtTable.Available == false)

                            (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable.Available = true;
                    }
                }
                else
                {
                    foreach (Waiter waiter in kvp.Value.WaitersAtArea)
                    {
                        waiter.Available = true;
                    }
                }
            }
        }


        private bool GreetCompany(string keyAreaContaingingWaiter, int indexOfWaiterInAreaWaiterList)
        {
            Waiter waiter = new Waiter("", 0, false, 0, 0);    //varför skapa nya
            waiter = MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea[indexOfWaiterInAreaWaiterList];
            MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea.RemoveAt(indexOfWaiterInAreaWaiterList);
            waiter.Available = false;
            waiter.WaitersCompany = (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Dequeue();
            string company = waiter.WaitersCompany.Name;
            MyRestaurantAreas["Reception"].WaitersAtArea.Add(waiter);
           
            MyRestaurantAreas["WaiterWaitingArea"].EraseMe();
            MyRestaurantAreas["WaiterWaitingArea"].PrintMe();
            Console.SetCursorPosition(35, 20);
            Console.WriteLine("Greet Company " + company + " " + waiter.Name);
            MyRestaurantAreas["Reception"].EraseMe();
            MyRestaurantAreas["Reception"].PrintMe();
            return false;
        }
        private bool ShowTable(string areaKey, int WaiterIndex)
        {
            bool continueLoop = true;
            if (MyRestaurantAreas[areaKey].WaitersAtArea.Count >= 0)
            {
                Company company = MyRestaurantAreas[areaKey].WaitersAtArea[WaiterIndex].WaitersCompany;
                Waiter waiter = MyRestaurantAreas[areaKey].WaitersAtArea[WaiterIndex];

                foreach (var kvp in MyRestaurantAreas)
                {
                    if (kvp.Value is Table)
                    {
                        if (company.Guests.Count < 3)
                        {
                            if ((kvp.Value as Table).IsAvailable && (kvp.Value as Table).Seats == 2 && company.SeatedAtTable == false)
                            {
                                waiter.Available = false;
                                MyRestaurantAreas[kvp.Key].CompanyAtArea = company;
                                company.SeatedAtTable = true;
                                MyRestaurantAreas[kvp.Key].EraseMe();
                                MyRestaurantAreas[kvp.Key].PrintMe();
                                MyRestaurantAreas[areaKey].WaitersAtArea[WaiterIndex].WaitersCompany = null;
                                (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable = (waiter);
                                MyRestaurantAreas[areaKey].WaitersAtArea.RemoveAt(WaiterIndex);
                                MyRestaurantAreas[areaKey].EraseMe();
                                MyRestaurantAreas[areaKey].PrintMe();
                                MyRestaurantAreas[kvp.Key].CompanyAtArea.SeatedAtTable = true;
                                (MyRestaurantAreas[kvp.Key] as Table).IsAvailable = false;
                                Console.SetCursorPosition(35, 21);
                                Console.WriteLine("ShowTable " + company.Name + " " + waiter.Name + " " + MyRestaurantAreas[kvp.Key].Name);
                                continueLoop = false;
                                break;
                            }
                        }
                        else if (company.Guests.Count >= 3)
                        {
                            if ((kvp.Value as Table).IsAvailable && (kvp.Value as Table).Seats == 4 && company.SeatedAtTable == false)
                            {
                                waiter.Available = false;
                                MyRestaurantAreas[kvp.Key].CompanyAtArea = company;
                                company.SeatedAtTable = true;
                                (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable = (waiter);
                                MyRestaurantAreas[kvp.Key].EraseMe();
                                MyRestaurantAreas[kvp.Key].PrintMe();
                                (MyRestaurantAreas[kvp.Key] as Table).IsAvailable = false;
                                MyRestaurantAreas[kvp.Key].CompanyAtArea.SeatedAtTable = true;
                                MyRestaurantAreas[areaKey].WaitersAtArea[WaiterIndex].WaitersCompany = null;
                                MyRestaurantAreas[areaKey].WaitersAtArea.RemoveAt(WaiterIndex);
                                MyRestaurantAreas[areaKey].EraseMe();
                                MyRestaurantAreas[areaKey].PrintMe();
                                Console.SetCursorPosition(35, 21);
                                Console.WriteLine("ShowTable " + company.Name + " " + waiter.Name + " " + MyRestaurantAreas[kvp.Key].Name);
                                continueLoop = false;
                                break;
                            }
                        }
                    }

                }
            }
            return continueLoop;
        }
        private bool TakeOrderFromGuest(string areaKey)
        {
            bool continueLoop = false;
            Random random = new Random();
            Company company = MyRestaurantAreas[areaKey].CompanyAtArea;
            if (!company.HasOrdered)
            {
                Waiter waiter = (MyRestaurantAreas[areaKey] as Table).WaiterAtTable;
                int indexer = 1;
                foreach (Guest guest in company.Guests)
                {
                    foreach (Guest guest2 in company.Guests)
                    {
                        if (guest.Name == guest2.Name)
                        {
                            guest.Name = (guest.Name + " " + indexer);
                            indexer++;
                            guest2.Name = (guest2.Name + " " + indexer);
                            indexer++;
                        }
                    }
                    int orderNumber = random.Next(1, 10);
                    waiter.Name_MenuIndex.Add(guest.Name, orderNumber);
                    guest.Name = (guest.Name + " " + (MyRestaurantAreas[areaKey] as Table).Dishes[orderNumber]);
                    guest.Activity = "WFF";
                }
                waiter.Area_Order = new KeyValuePair<string, Dictionary<string, int>>(areaKey, waiter.Name_MenuIndex);
                waiter.Available = false;
                company.HasOrdered = true;
                MyRestaurantAreas[areaKey].CompanyAtArea = company;

                (MyRestaurantAreas[areaKey] as Table).WaiterAtTable = waiter;
                (MyRestaurantAreas[areaKey] as Table).HasOrdered = true;

                MyRestaurantAreas[areaKey].EraseMe();
                MyRestaurantAreas[areaKey].PrintMe();
            }
            return continueLoop;
        }
        private bool PlaceOrderAtKitchen(string areakey)
        {
            bool continueLoop = false;
            Waiter waiter = (MyRestaurantAreas[areakey] as Table).WaiterAtTable;
            (MyRestaurantAreas[areakey] as Table).HasOrdered = false;
            (MyRestaurantAreas[areakey] as Table).WaiterAtTable = new Waiter("", 0, false, 0, 0);

            //var order = new KeyValuePair<string, Dictionary<string, int>>(waiter.Area_Order.Key, waiter.Area_Order.Value);
            //Dictionary<string, int> names_DishIndexes = waiter.Area_Order.Value;

            (MyRestaurantAreas["Kitchen"] as Kitchen).GetOrderFromWaiter(waiter.Area_Order);

            
            //waiter.Area_Order = order;
            waiter.Available = false;
            MyRestaurantAreas["Kitchen"].WaitersAtArea.Add(waiter);



            return continueLoop;
        }
        private bool ServeOrder()
        {
            bool continueLoop = true;
            if ((MyRestaurantAreas["Kitchen"] as Kitchen).FoodIsReady)
                foreach (RestaurantArea waiterScan in MyRestaurantAreas.Values)
                {
                    string waiterName;
                    if (waiterScan.WaitersAtArea.Count > 0)
                    {
                        Waiter waiterToMove = new Waiter("", 0, false, 0, 0);
                        string waitersLocation = waiterScan.Name;

                        foreach (Waiter waiter in MyRestaurantAreas[waitersLocation].WaitersAtArea)
                        {
                            if (waiter.Available)
                            {
                                waiterToMove = waiter;
                            }
                        }
                        string tableToServe = (MyRestaurantAreas["Kitchen"] as Kitchen).OrderQueueTables.Dequeue();
                        var kvp = (MyRestaurantAreas["Kitchen"] as Kitchen).OrdersToServe[tableToServe].Values;
                        Console.ReadLine();


                        break;
                    }
                }
            return continueLoop;
        }

        private bool GiveCheck()
        {
            bool continueLoop = true;

            return continueLoop;

        }

        private bool ClearTable()
        {
            bool continueLoop = true;

            return continueLoop;
        }

        //RitMetoder
        public void PrintAllAreas()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                kvp.Value.PrintMe();
            }
            Console.ReadLine();
        }
        public void EraseAllAreas()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                kvp.Value.EraseMe();
            }
        }
        public static void TimeCounter()
        {

        }
        //Initieringsmetoder
        public Dictionary<string, RestaurantArea> GenerateTables(Dictionary<string, RestaurantArea> restaurantAreas)
        {
            int fromTop = 24;
            int fromLeft = 12;

            for (int i = 0; i < 10; i++)
            {

                int seats = i < 4 ? 2 : 4;
                int quality = i == 4 ? 1 : 2;
                quality = i == 9 ? 1 : 2;

                restaurantAreas.Add("Table " + (i + 1), new Table($"Table {(i + 1)} ", fromTop, fromLeft, seats, quality, i + 1));
                fromLeft = i == 4 ? 12 : fromLeft + 30;

                fromTop = i == 4 ? fromTop + 16 : fromTop;

            }
            return restaurantAreas;
        }
        public void Draw()
        {

            foreach (var restaurantArea in MyRestaurantAreas)
            {
                Window.OurDraw(restaurantArea.Value as RestaurantArea);
            }
        }

    }
}

