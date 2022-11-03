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
        internal Queue<Company> CompanyWaitingList { get; set; }
        internal int CounterRestaurant { get; set; }

        internal Kitchen Kitchen { get; set; }
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        internal WC WC { get; set; }
        public int Time { get; set; }


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
            this.CompanyWaitingList = new Queue<Company>();
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.PositionX, this.PositionY, this.MyDrawing);
            GenerateTable(TableList);
            Draw();
            while (true)
            {
                LoopRestaurant();
                Console.ReadKey();
            }
        }
        public void LoopRestaurant()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number < 50 && CompanyWaitingList.Count < 10)
            {
                CompanyWaitingList.Enqueue(GenerateCompany());                
            }
            if (number > 50 && CompanyWaitingList.Count > 0)   //Här någonstans kan vi ha en bool som en waiter styr när vi dequeuear
            {
                foreach(Company company in CompanyWaitingList)
                {
                    company.Guests[0].PositionY = (company.Guests[0].PositionY-1);
                }

                CompanyWaitingList.Dequeue();
            }
            PrintWaitingCompanies();

        }
        public void PrintPosition(Person person)
        {

            Console.SetCursorPosition(person.PositionX, person.PositionY);
            Console.WriteLine("              ");
            Console.SetCursorPosition(person.PositionX, person.PositionY);
            Console.WriteLine(person.Name);
        }
    
        public void PrintCompany()
        {
            foreach (Company company in CompanyWaitingList)
            {
                Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY);
                Console.WriteLine("              ");
                Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY + 1);
                Console.WriteLine("              ");
                Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY + 2);
                Console.WriteLine("              ");
                Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY + 3);
                Console.WriteLine("              ");
                foreach (Person person in company.Guests)
                {
                    PrintPosition(person);
                }
            }
        }
        public void PrintWaitingCompanies()
        {
            int j = 0;
            foreach(Company company in CompanyWaitingList)
            {
                if(j < 10)
                {
                    j++;
                    Console.SetCursorPosition(company.Guests[0].PositionX, company.Guests[0].PositionY); 
                    Console.Write("                          ");   //Rensar raden innan den skriver ut sällskapet
                    if (CompanyWaitingList.Count > j)
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
        public static void Count()
        {

        }
        public static void DrawArray()
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
            Company company = new Company(CompanyWaitingList.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
            return company;
        }

    }
}
