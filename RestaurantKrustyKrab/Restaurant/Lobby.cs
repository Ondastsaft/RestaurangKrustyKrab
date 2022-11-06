using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    {
        internal string[,] MyDrawing { get; set; }
        internal string Name { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }

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
            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.PositionX = 4;
            this.PositionY = 2;
            this.TableList = new List<Table>();
            this.Kitchen = new Kitchen(false, 3, 157);
            this.DishStation = new DishStation(3, 128);
            this.Reception = new Reception(3, 31);
            this.WC = new WC(25, 188);
            this.Time = 0;
            this.WaiterList = new List<Waiter>();
            this.WaitersAtReception = new List<Waiter>();
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.PositionX, this.PositionY, this.MyDrawing);
            GenerateTable(TableList);
            GenerateWaiter();
            Draw();
            while (true)
            {
                LoopRestaurant();
                Console.ReadKey();
            }
        }
        public void LoopRestaurant()
        {
            LoopQueue();
            PrintWaitingCompanies();
            Thread.Sleep(2000);
            PrintList(WaiterList);
            Thread.Sleep(2000);
            work();
            Thread.Sleep(2000);
            //PrintList();
            //PrintList(WaitersAtReception as <Person>);
        }
        public void PrintWaiters()
        {
            foreach (Waiter waiter in WaiterList)
            {
                Console.SetCursorPosition(waiter.PositionX, waiter.PositionY);
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
                    company.Guests[0].PositionY = (company.Guests[0].PositionY - 1);
                }
            }
        }

        private void work()
        {
            foreach (Waiter waiter in WaiterList)
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
                    waiter.PositionX = 110;
                    waiter.PositionY = 3;
                    WaiterList.Add(waiter);
                    waiter.Busy = true;
                }
            }
        }
        private bool bemöta_gäst(Waiter waiter)
        {
            bool busy = false;

            if (Reception.CompanyWaitingQueue.Count > 0)
            {
                ErasePosition(waiter);                
                waiter.PositionX = 10;
                waiter.PositionY = 21;
                WaitersAtReception.Add(waiter);
                Console.SetCursorPosition((waiter.PositionX), waiter.PositionY);
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

            Console.SetCursorPosition(person.PositionX, person.PositionY);
            Console.WriteLine("              ");
            Console.SetCursorPosition(person.PositionX, person.PositionY);

        }
        public void EraseList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).PositionY, ((person as Person).PositionX + row));
                Console.Write(new string(' ', (person as Person).Name.Length));
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
                    Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY);
                    Console.Write("                          ");   //Rensar raden innan den skriver ut sällskapet
                    if (Reception.CompanyWaitingQueue.Count > j)
                    {
                        Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY);
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
                            Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY);
                            Console.Write("                          ");
                        }
                    }
                }
            }

        }
        public void PrintList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).PositionY, ((person as Person).PositionX + row));
                Console.Write((person as Person).Name);
                row++;
            }
        }
        public static void TimeCounter()
        {

        }

        public List<Table> GenerateTable(List<Table> tableList)
        {
            int top = 12;
            int tablenumber = 1;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 24, top, true, tablenumber));
                tablenumber++; top = top + 30;
            }
            top = 12;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 40, top, true, tablenumber));
                tablenumber++; top = top + 30;
            }
            return tableList;

        }

        public void Draw()
        {
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.Frame);
            }
            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.Frame);
            Window.OurDraw("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.Frame);
            Window.OurDraw("Reception", Reception.PositionY, Reception.PositionX, Reception.Frame);
            Window.OurDraw("WC", WC.PositionY, WC.PositionX, WC.Frame);
        }
        public Company GenerateCompany()
        {
            Company company = new Company(Reception.CompanyWaitingQueue.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
            return company;
        }
        public void GenerateWaiter()
        {
            for (int i = 0; i < 3; i++)
            {
                string name = "Waiter " + (i + 1);
                WaiterList.Add(new Waiter(name, 0, false, 110, 3));
            }

        }
    }
}
