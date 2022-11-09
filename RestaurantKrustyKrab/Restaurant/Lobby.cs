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
                Console.ReadKey();
            }
        }
        public void LoopRestaurant()
        {

            CompanyArrivalRandomizer();
            Thread.Sleep(2000);
            EraseAllAreas();
            Thread.Sleep(2000);
            PrintAllAreas();
            WorkWaiter();
            Thread.Sleep(2000);
            EraseAllAreas();
            Thread.Sleep(2000);
            PrintAllAreas();

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
            for (int i = 0; i < (MyRestaurantAreas["WaiterWaitingArea"] as WaiterWaitingArea).WaitersAtArea.Count - 1; i++)
            {

                bool continueloop = true;


                if ((MyRestaurantAreas["WaiterWaitingArea"] as WaiterWaitingArea).WaitersAtArea[i].Available && (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count > 0)
                {
                    continueloop = GreetCompany("WaiterWaitingArea", i);
                }
                EraseAllAreas();
                PrintAllAreas();
                Thread.Sleep(2000);


            }
            
            for (int i = 0; i < (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count - 1; i++)
            {
                ShowTable("Reception", i);
            }

            EraseAllAreas();
            PrintAllAreas();
            Thread.Sleep(2000);

            foreach(var kvp in MyRestaurantAreas)
            {
                if(kvp.Value is Table)
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



        }

        private bool GreetCompany(string keyAreaContaingingWaiter, int indexOfWaiterInAreaWaiterList)
        {
            MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea[indexOfWaiterInAreaWaiterList].Available = false;
            MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea[indexOfWaiterInAreaWaiterList].Company =
                (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Dequeue();
            MyRestaurantAreas["Reception"].WaitersAtArea.Add(MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea[indexOfWaiterInAreaWaiterList]);
            MyRestaurantAreas[keyAreaContaingingWaiter].WaitersAtArea.RemoveAt(indexOfWaiterInAreaWaiterList);
            return false;
        }
        private bool ShowTable(string key, int index)
        {
            bool continueLoop = true;
            if (MyRestaurantAreas[key].WaitersAtArea.Count > 0)
            {
                Company company = MyRestaurantAreas[key].WaitersAtArea[index].Company;
                Waiter waiter = MyRestaurantAreas[key].WaitersAtArea[index];

                foreach (var kvp in MyRestaurantAreas)
                {
                    if (kvp.Value is Table)
                    {
                        if (company.Guests.Count < 3)
                        {
                            if ((kvp.Value as Table).IsAvailable && (kvp.Value as Table).Seats == 2 && company.SeatedAtTable == false)
                            {
                                MyRestaurantAreas[kvp.Key].CompanyAtArea = company;
                                company.SeatedAtTable = true;
                                MyRestaurantAreas[key].WaitersAtArea[index].Company = null;
                                (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable = (waiter);
                                MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
                                MyRestaurantAreas[kvp.Key].CompanyAtArea.SeatedAtTable = true;
                                EraseAllAreas();
                                PrintAllAreas();
                                continueLoop = false;
                                break;
                            }
                        }
                        else if (company.Guests.Count >= 3)
                        {
                            if ((kvp.Value as Table).IsAvailable && (kvp.Value as Table).Seats == 4 && company.SeatedAtTable == false)
                            {
                                MyRestaurantAreas[kvp.Key].CompanyAtArea = company;
                                company.SeatedAtTable = true;
                                MyRestaurantAreas[key].WaitersAtArea[index].Company = null;
                                (MyRestaurantAreas[kvp.Key] as Table).WaiterAtTable = (waiter);
                                MyRestaurantAreas[kvp.Key].WaitersAtArea.RemoveAt(index);
                                MyRestaurantAreas[kvp.Key].CompanyAtArea.SeatedAtTable = true;
                                EraseAllAreas();
                                PrintAllAreas();
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
            Dictionary<string, int> order = new Dictionary<string, int>();
            List<Guest> newGuestList = new List<Guest>();
            foreach (Guest guest in MyRestaurantAreas[areaKey].GuestsAtArea)
            {
                int orderNumber = random.Next(1, 10);
                order.Add(guest.Name, orderNumber);
                guest.Name = (guest.Name + " " + (MyRestaurantAreas[areaKey] as Table).Dishes[orderNumber]);
                guest.Activity = "Waiting for food";
                newGuestList.Add(guest);
            }
            MyRestaurantAreas[areaKey].GuestsAtArea = newGuestList;
            (MyRestaurantAreas[areaKey] as Table).WaiterAtTable.Area_Order.Add(areaKey, order);
            (MyRestaurantAreas[areaKey] as Table).HasOrdered = true;
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

                restaurantAreas.Add("Table " + i + 1, new Table($"Table {i + 1} ", fromTop, fromLeft, seats, quality, i + 1));
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
