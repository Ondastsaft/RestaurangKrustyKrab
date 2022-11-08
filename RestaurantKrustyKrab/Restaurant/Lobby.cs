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
                //Console.ReadKey();
            }
        }
        public void LoopRestaurant()
        {

            CompanyArrivalRandomizer();
            work();
            EraseAllAreas();
            PrintAllAreas();

        }

        private void CompanyArrivalRandomizer()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number < 50 && (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count < 10)
            {
                (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Enqueue(new Company((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count));
                PrintList((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue);
            }
        }
        //Servitörens LoopMetoder
        private void work()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                for (int i = 0; i < kvp.Value.WaitersAtArea.Count; i++)
                {
                    bool continueLoop = true;
                    if (!kvp.Value.WaitersAtArea[i].Busy)
                        while (continueLoop)
                        {

                            continueLoop = (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count > 0 ? continueLoop = GreetCompany(kvp.Key, i) : continueLoop;



                            continueLoop = (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count > 0 ? continueLoop = ShowTable(kvp.Key, i) : continueLoop;

                            //TakeOrder() - Gör om
                            continueLoop = (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count > 0 ? continueLoop = ShowTable(kvp.Key, i) : continueLoop;
                            
                            
                            
                            
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

                            continueLoop = false;
                        }
                }
            }

        }
        private bool GreetCompany(string key, int index)
        {
            bool continueLoop = true;

            int startRow = (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Count;
            foreach (Waiter waiter in (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea)
            {
                startRow = waiter.Company.Guests.Count + startRow;
                startRow++;
            }

            //Sparar Company på waitern som returneras och suddar samt skriver ut receptionen igen
            MyRestaurantAreas[key].WaitersAtArea[index].Busy = true;
            EraseList((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue);
            MyRestaurantAreas[key].WaitersAtArea[index].Company = (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Dequeue();
            PrintList((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue);

            // Lägger till Waitern som nu har Companyt med sig i listan i receptionen, tar bort den från listan den kom ifrån
            // samt suddar den printningen och skriver ut den igen

            EraseList(MyRestaurantAreas[key].WaitersAtArea);
            EraseList(MyRestaurantAreas["Reception"].WaitersAtArea);
            MyRestaurantAreas["Reception"].WaitersAtArea.Add(MyRestaurantAreas[key].WaitersAtArea[index]);
            MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
            PrintList(MyRestaurantAreas["Reception"].WaitersAtArea);

            //Skapar en offset nedåt som är lika med antalet Waiters i Receptionen + antalet gäster i samtliga Companies i receptionen

            //Skriver ut 
            Console.SetCursorPosition((MyRestaurantAreas["Reception"] as Reception).FromLeft - 15, (MyRestaurantAreas["Reception"] as Reception).FromTop + startRow);
            Console.Write(MyRestaurantAreas["Reception"].WaitersAtArea[MyRestaurantAreas["Reception"].WaitersAtArea.Count - 1].Name);

            int row = 1;
            foreach (Guest guest in MyRestaurantAreas["Reception"].WaitersAtArea[MyRestaurantAreas["Reception"].WaitersAtArea.Count - 1].Company.Guests)
            {
                Console.SetCursorPosition((MyRestaurantAreas["Reception"] as Reception).FromLeft - 15, (MyRestaurantAreas["Reception"] as Reception).FromTop + startRow + row);
                Console.Write(guest.Name);
                row++;
            }
            return false;
        }
        private bool ShowTable(string key, int index)
        {
            bool continueLoop = true;
            if (MyRestaurantAreas[key].WaitersAtArea.Count > 0 && MyRestaurantAreas[key].WaitersAtArea[MyRestaurantAreas[key].WaitersAtArea.Count].Company != null)
            {
                Company company = MyRestaurantAreas[key].WaitersAtArea[index].Company;
                Waiter waiter = MyRestaurantAreas[key].WaitersAtArea[index];
                foreach (var kvp in MyRestaurantAreas)
                {
                    if (kvp.Value is Table)
                    {
                        if (company.Guests.Count < 3)
                        {
                            if ((kvp.Value as Table).IsAvailable && (kvp.Value as Table).Seats == 2)
                            {
                                MyRestaurantAreas[kvp.Key].WaitersAtArea.Add(waiter);
                                MyRestaurantAreas[kvp.Key].CompaniesAtArea.Add(company);
                                EraseAllAreas();
                                MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
                                PrintAllAreas();
                                MyRestaurantAreas[kvp.Key].WaitersAtArea[MyRestaurantAreas[kvp.Key].WaitersAtArea.Count - 1].Company = null;
                                continueLoop = false;
                            }
                        }
                        else if (company.Guests.Count >= 3)
                        {
                            if ((kvp.Value as Table).IsAvailable && (kvp.Value as Table).Seats == 4)
                            {
                                MyRestaurantAreas[kvp.Key].WaitersAtArea.Add(waiter);
                                MyRestaurantAreas[kvp.Key].CompaniesAtArea.Add(company);
                                EraseAllAreas();
                                MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
                                PrintAllAreas();
                                MyRestaurantAreas[kvp.Key].WaitersAtArea[MyRestaurantAreas[kvp.Key].WaitersAtArea.Count - 1].Company = null;
                                continueLoop = false;
                            }
                        }
                    }
                }
            }
            return continueLoop;
        }
        private bool TakeOrder(string key, int index)
        {
            bool continueLoop = false;






            return continueLoop;
        }
        //RitMetoder
        public void PrintAllAreas()
        {
            foreach (var restaurantArea in MyRestaurantAreas)
            {
                PrintRestaurantArea(restaurantArea.Value);
            }
            try
            {
                PrintList((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue);
            }
            catch
            {
            }
        }
        public void EraseAllAreas()
        {
            foreach (var restaurantArea in MyRestaurantAreas)
            {
                EraseRestaurantArea(restaurantArea.Value as RestaurantArea);
            }
            EraseList((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue);
        }
        private void PrintRestaurantArea(RestaurantArea restaurantArea)
        {
            PrintList(restaurantArea.GuestsAtArea);
            PrintList(restaurantArea.CompaniesAtArea);
            PrintList(restaurantArea.WaitersAtArea);
            PrintList(restaurantArea.ChefsAtArea);

        }
        private void EraseRestaurantArea(RestaurantArea restaurantArea)
        {
            EraseList(restaurantArea.GuestsAtArea);
            EraseList(restaurantArea.CompaniesAtArea);
            EraseList(restaurantArea.WaitersAtArea);
            EraseList(restaurantArea.ChefsAtArea);
        }
        public void ErasePosition(Person person)
        {

            Console.SetCursorPosition(person.FromTop, person.FromLeft);
            Console.WriteLine("              ");
            Console.SetCursorPosition(person.FromTop, person.FromLeft);

        }
        public void EraseList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).FromLeft, ((person as Person).FromTop + row));
                Console.Write(new string(' ', (person as Person).Name.Length));
                row++;
            }
        }
        public void EraseList<T>(Queue<T> companyList)
        {
            int row = 0;
            foreach (T company in companyList)
            {
                Console.SetCursorPosition((company as Company).Guests[0].FromTop, ((company as Company).Guests[0].FromLeft + row));
                Console.Write((company as Company).Guests[0].Name);
                Console.Write(new string(' ', (company as Company).Guests[0].Name.Length));
                row++;
            }
        }
        public void PrintList<T>(Queue<T> companyList)
        {
            int row = 0;
            foreach (T company in companyList)
            {
                Console.SetCursorPosition((company as Company).Guests[0].FromTop, ((company as Company).Guests[0].FromLeft + row));
                Console.Write((company as Company).Guests[0].Name);
                //row++;
            }
        }
        public void PrintList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).FromLeft, ((person as Person).FromTop + row));
                Console.Write((person as Person).Name);
                row++;
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
