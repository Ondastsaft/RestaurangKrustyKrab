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
            EraseAllAreas();
            CompanyArrivalRandomizer();
            work();
            PrintAllAreas();
        }
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
        private void CompanyArrivalRandomizer()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number < 50 && MyRestaurantAreas["Reception"].CompaniesAtArea.Count < 10)
            {
                (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Enqueue(new Company((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count));
            }
            if (number > 50 && MyRestaurantAreas["Reception"].CompaniesAtArea.Count > 0)   //Här någonstans kan vi ha en bool som en waiter styr när vi dequeuear
            {
                foreach (Company company in MyRestaurantAreas["Reception"].CompaniesAtArea)
                {
                    company.Guests[0].FromLeft = (company.Guests[0].FromLeft - 1);
                }
            }
        }

        private void work()
        {
            foreach (var kvp in MyRestaurantAreas)
            {
                for (int i = 0; i < kvp.Value.WaitersAtArea.Count - 1; i++)
                {
                    bool continueLoop = true;
                    kvp.Value.WaitersAtArea[i].Busy = false;
                    while (continueLoop)
                    {

                        continueLoop = GreetCompany(kvp.Value.WaitersAtArea[i], kvp.Key, i);

                        //continueLoop == true? continueLoop = ge_meny(kvp.Value.WaitersAtArea[i], kvp.Key, i) : continueLoop=true;
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

                        break;
                    }
                }
            }

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
        private bool GreetCompany(Waiter waiter, string key, int index)
        {
            bool continueLoop = true;
            if ((MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Count > 0)
            {

                waiter.Company = (MyRestaurantAreas["Reception"] as Reception).CompanyWaitingQueue.Dequeue();
                (MyRestaurantAreas["Reception"] as Reception).WaitersAtArea.Add(waiter);
                waiter.Busy = true;
                waiter.FromLeft = 20;
                waiter.FromTop = 5;
                Console.SetCursorPosition(waiter.FromLeft, waiter.FromTop);
                Console.Write(waiter.Name);
                Console.SetCursorPosition(waiter.FromLeft, waiter.FromTop + 1);
                int row = 0;
                foreach (Guest guest in waiter.Company.Guests)
                {
                    Console.SetCursorPosition(waiter.FromLeft, waiter.FromTop + row);
                    Console.Write(guest.Name);
                    row++;
                }
                MyRestaurantAreas[key].WaitersAtArea.RemoveAt(index);
                continueLoop = false;
            }
            return continueLoop;
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
