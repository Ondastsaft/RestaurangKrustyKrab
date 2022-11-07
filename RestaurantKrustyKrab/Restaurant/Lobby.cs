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

        internal List<RestaurantArea> MyRestaurantAreas { get; set; }
        public List<Table> TableList { get; set; }
        internal List<Waiter> WaiterList { get; set; }
        internal int CounterRestaurant { get; set; }

        internal Kitchen Kitchen { get; set; }
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        internal WC WC { get; set; }
        public int Time { get; set; }
        public List<Waiter> WaitersAtReception { get; set; }

        public Lobby()
        {
            this.MyRestaurantAreas = new List<RestaurantArea>();
            MyRestaurantAreas.Add(new Kitchen(3, 157));
            MyRestaurantAreas = GenerateTables(MyRestaurantAreas);
            MyRestaurantAreas.Add(new Reception(3,31));
            MyRestaurantAreas.Add(new WC(25, 188));
            MyRestaurantAreas.Add(new WaiterWaitingArea(110, 3));
            MyRestaurantAreas.Add(new DishStation(3,128));

            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.FromTop = 4;
            this.FromLeft = 2;
            this.Time = 0;
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.FromTop, this.FromLeft, this.MyDrawing);
            //PrintAllAreas();
            Draw();
            //while (true)
            //{
            //    LoopRestaurant();
            //    Console.ReadKey();
            //}
        }
        public void LoopRestaurant()
        {
            //LoopQueue();
            PrintWaitingCompanies();
            Thread.Sleep(2000);
            PrintList(WaiterList);
            Thread.Sleep(2000);
            //work();
            Thread.Sleep(2000);
            //PrintList();
            //PrintList(WaitersAtReception as <Person>);
        }
        public void PrintAllAreas()
        {
            foreach(RestaurantArea area in MyRestaurantAreas)
            {
                PrintRestaurantArea(area);
            }
        }
        public void PrintWaiters()
        {
            foreach (Waiter waiter in WaiterList)
            {
                Console.SetCursorPosition(waiter.FromTop, waiter.FromLeft);
                if (waiter.Company != null)
                    Console.Write(waiter.Name + " " + waiter.Company.Guests[0]);
            }
        }
        private void LoopQueue()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number < 50 && Reception.CompanyWaitingQueue.Count < 10)
            {
                Reception.CompanyWaitingQueue.Enqueue(GenerateCompany());
            }
            if (number > 50 && Reception.CompanyWaitingQueue.Count > 0)   //Här någonstans kan vi ha en bool som en waiter styr när vi dequeuear
            {
                foreach (Company company in Reception.CompanyWaitingQueue)
                {
                    company.Guests[0].FromLeft = (company.Guests[0].FromLeft - 1);
                }
            }
        }

        private void work(List<Waiter> waiterList)
        {
            foreach (Waiter waiter in waiterList)
            {
                while (waiter.Busy == false)
                {
                    waiter.Busy = bemöta_gäst(waiter);





                    //void ge_meny()
                    //{

                    //}

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
                    waiter.FromTop = 110;
                    waiter.FromLeft = 3;
                    //WaiterList.Add(waiter);
                    waiter.Busy = true;
                    Console.Write(waiter.Name);
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
        private bool bemöta_gäst(Waiter waiter)
        {
            bool busy = false;

            if (Reception.CompanyWaitingQueue.Count > 0)
            {
                ErasePosition(waiter);                
                waiter.FromTop = 10;
                waiter.FromLeft = 21;
                WaitersAtReception.Add(waiter);
                Console.SetCursorPosition((waiter.FromTop), waiter.FromLeft);
                waiter.Company = Reception.CompanyWaitingQueue.Dequeue();

                busy = true;
            }
            return busy;
        }

        private bool visa_bord(Company company)
        {
            bool busy = false;
            foreach (Table table in TableList)
            {
                if (table.Seats >= company.Guests.Count())
                {

                }

            }
            return busy;

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

        public void PrintList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).FromTop, ((person as Person).FromLeft + row));
                Console.Write((person as Person).Name);
                row++;
            }
        }
        public void PrintWaitingCompanies()
        {
            int j = 0;
            foreach (Company company in Reception.CompanyWaitingQueue)
            {
                if (j < 10)
                {
                    j++;
                    Console.SetCursorPosition(company.Guests[0].FromTop, company.Guests[0].FromLeft);
                    Console.Write("                          ");   //Rensar raden innan den skriver ut sällskapet
                    if (Reception.CompanyWaitingQueue.Count > j)
                    {
                        Console.SetCursorPosition(company.Guests[0].FromTop, company.Guests[0].FromLeft);
                        if (company.Guests.Count == 1)
                        {
                            Console.Write("Company" + " " + j + ": " + company.Guests[0].Name); //Skriver endast ut sitt eget namn om sällskapet enbart är en person
                        }
                        else if (company.Guests.Count > 1)
                        {
                            Console.Write("Company" + " " + j + ": " + company.Guests[0].Name + " + " + (company.Guests.Count - 1));
                        }
                        else
                        {
                            Console.SetCursorPosition(company.Guests[0].FromTop, company.Guests[0].FromLeft);
                            Console.Write("                          ");
                        }
                    }
                }
            }

        }
        public static void TimeCounter()
        {

        }

        public List<RestaurantArea> GenerateTables (List<RestaurantArea> restaurantAreaList)
        {
            int top = 12;
            int tablenumber = 1;
            for (int i = 0; i < 5; i++)
            {
                restaurantAreaList.Add(new Table(2, 0, 24, top, tablenumber));
                tablenumber++; top = top + 30;
            }
            top = 12;
            for (int i = 0; i < 5; i++)
            {
                restaurantAreaList.Add(new Table(2, 0, 40, top, tablenumber));
                tablenumber++; top = top + 30;
            }
            return restaurantAreaList;

        }

        public void Draw()
        {
            foreach (RestaurantArea restaurantArea in MyRestaurantAreas)
            {
                Window.OurDraw(restaurantArea.Name, restaurantArea.FromLeft, restaurantArea.FromTop, restaurantArea.Frame);
            }
        }
        public Company GenerateCompany()
        {
            Company company = new Company(Reception.CompanyWaitingQueue.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
            return company;
        }
    }
}
