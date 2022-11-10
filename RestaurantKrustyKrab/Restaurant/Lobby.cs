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
            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.FromTop = 2;
            this.FromLeft = 2;
            this.Time = 0;
        }
        //LoopMetoder
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.FromTop, this.FromLeft, this.MyDrawing);
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
            CounterRestaurant++;
            Console.SetCursorPosition(25, 3);
            Console.Write(CounterRestaurant.ToString());
            Console.ReadLine();

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

            }

            for (int i = 0; i < (MyRestaurantAreas["WaiterWaitingArea"] as WaiterWaitingArea).WaitersAtArea.Count; i++)
            {
                bool continueloop = true;
                if ((MyRestaurantAreas["WaiterWaitingArea"] as WaiterWaitingArea).WaitersAtArea[i].Available && (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count > 0)
                {
                    continueloop = GreetCompany("WaiterWaitingArea", i);
                }


            }

            for (int i = 0; i < (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count; i++)
            {
                ShowTable("Reception", i);
            }



            foreach (var kvp in MyRestaurantAreas)
            {
                if (kvp.Value is Table && (MyRestaurantAreas[kvp.Key] as Table).CompanyAtArea.Guests.Count > 0 && (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable.Available == true && (MyRestaurantAreas[kvp.Key] as Table).HasOrdered)
                {
                    TakeOrder(kvp.Key);
                }
            }

            //TakeOrder();
            // continueLoop = (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count > 0 ? continueLoop = ShowTable(kvp.Key, i) : continueLoop;

            ////{

            ////}

            //void ta_Beställning()
            //{

            //}

            //void hämta_mat()
            //{

            //}
            //void servera_mat()
            //{

            //}
            //void ta_Emot_Pengar()
            //{

            //}

            //void duka_undan()
            //{

            //}

            //WaiterList.Add(waiter);
            foreach (var kvp in MyRestaurantAreas)
            {
                if (kvp.Value is Table && (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable.Available == false)

                    (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable.Available = true;
            }
        }
        private bool GreetCompany(string keyAreaContaingingWaiter, int indexOfWaiterInAreaWaiterList)
        {
            Waiter waiter = new Waiter("", 0, false, 0, 0);
            waiter = MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea[indexOfWaiterInAreaWaiterList];
            waiter.Available = false;
            waiter.WaitersCompany = (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Dequeue();
            string company = waiter.WaitersCompany.Name;
            MyRestaurantAreas["Reception"].WaitersAtArea.Add(waiter);
            MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea.RemoveAt(indexOfWaiterInAreaWaiterList);
            MyRestaurantAreas["WaiterWaitingArea"].EraseMe();
            MyRestaurantAreas["WaiterWaitingArea"].PrintMe();
            Console.SetCursorPosition(35, 20);
            Console.WriteLine("Greet Company " + company + " " + waiter.Name);
            MyRestaurantAreas["Reception"].EraseMe();
            MyRestaurantAreas["Reception"].PrintMe();
            return false;
        }
        private bool ShowTable(string key, int index)
        {
            bool continueLoop = true;
            if (MyRestaurantAreas[key].WaitersAtArea.Count >= 0)
            {
                Company company = MyRestaurantAreas[key].WaitersAtArea[index].WaitersCompany;
                Waiter waiter = MyRestaurantAreas[key].WaitersAtArea[index];

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
                                MyRestaurantAreas[key].WaitersAtArea[index].WaitersCompany = null;
                                (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable = (waiter);
                                MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
                                MyRestaurantAreas[key].EraseMe();
                                MyRestaurantAreas[key].PrintMe();
                                MyRestaurantAreas[kvp.Key].CompanyAtArea.SeatedAtTable = true;
                                (MyRestaurantAreas[kvp.Key] as Table).IsAvailable = false;
                                Console.SetCursorPosition(35, 21);
                                Console.WriteLine("ShowTable " + company.Name + " " + waiter.Name + MyRestaurantAreas[kvp.Key].Name);
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
                                MyRestaurantAreas[key].WaitersAtArea[index].WaitersCompany = null;
                                MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
                                MyRestaurantAreas[key].EraseMe();
                                MyRestaurantAreas[key].PrintMe();
                                Console.SetCursorPosition(35, 21);
                                Console.WriteLine("ShowTable " + company + " " + waiter + MyRestaurantAreas[kvp.Key].Name);
                                continueLoop = false;
                                break;
                            }
                        }
                    }

                }
            }
            return continueLoop;
        }
        private bool TakeOrder(string areaKey)
        {
            bool continueLoop = false;
            Random random = new Random();
            Company company = MyRestaurantAreas[areaKey].CompanyAtArea;
            Waiter waiter = (MyRestaurantAreas[areaKey] as Table).WaiterAtTable;
            int numberer = 1;
            foreach (Guest guest in company.Guests)
            {
                int orderNumber = random.Next(1, 10);
                waiter.Name_MenuIndex.Add(guest.Name + numberer, orderNumber);
                guest.Name = (guest.Name + " " + (MyRestaurantAreas[areaKey] as Table).Dishes[orderNumber]);
                guest.Activity = "Waiting for food";
                numberer++;
            }
            waiter.Area_Order = new KeyValuePair<string, Dictionary<string, int>>(areaKey, waiter.Name_MenuIndex);
            waiter.Available = false;
            MyRestaurantAreas[areaKey].CompanyAtArea = company;

            (MyRestaurantAreas[areaKey] as Table).WaiterAtTable = waiter;
            (MyRestaurantAreas[areaKey] as Table).HasOrdered = true;
            Console.SetCursorPosition(35, 22);
            Console.WriteLine("take order" + MyRestaurantAreas[areaKey].Name);
            MyRestaurantAreas[areaKey].EraseMe();
            MyRestaurantAreas[areaKey].PrintMe();
            return continueLoop;
        }
        //RitMetoder
        public void PrintAllAreas()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                kvp.Value.PrintMe();
            }
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
