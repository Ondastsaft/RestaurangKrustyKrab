using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Collections;
using System.Xml.Linq;

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
        internal List<Chef> ChefList { get; set; }
        internal int GlobalTimer { get; set; }
        internal Kitchen Kitchen { get; set; }
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        internal WC WC { get; set; }
        public int Time { get; set; }


        public Lobby()
        {
            //MyDrawing = new string[50, 200];
            Name = "Krusty Krab";
            PositionX = 4;
            PositionY = 2;
            TableList = new List<Table>();
            Kitchen = new Kitchen(false, 3, 157);
            //DishStation = new DishStation(3, 128);
            //Reception = new Reception(3, 31);
            //WC = new WC(25, 188);
            GlobalTimer = 0;
            CompanyWaitingList = new Queue<Company>();
            WaiterList = new List<Waiter>();
            ChefList = new List<Chef>();
            Generate();
        }


        internal void LobbyRun()
        {
            Addguests();
            PrintAll();
            Work();
            GlobalTimer++;

        }

        internal void PrintAll()
        {
            PrintCompanies();
            PrintWaiters();
            PrintTables();
            PrintKitchen();
            Console.WriteLine("Time: " + GlobalTimer);
            Console.ReadKey();
            Console.Clear();
        }

        void PrintKitchen() //Börja gärna här

        {
            Console.WriteLine("KITCHEN");
            Console.WriteLine();
            Console.WriteLine("Chefs: ");

            foreach (Chef chef in this.ChefList)
            {
                Console.WriteLine("Name: " + chef.Name + " Busy? " + chef.Busy);
                    if (chef.Busy == true)
                { 
                        Console.WriteLine("Preparing: ");

                    foreach (Dish dish in chef.Preparing)
                    {
                        Console.WriteLine("Dish: " + dish.NameOfDish + "Table: " + dish.DestinationTable);
                    }
                }         
            }

            Console.WriteLine("Orders: ");
            if (this.Kitchen.Orders.Count > 0)
            {
                foreach (Dish order in this.Kitchen.Orders)
                {
                    Console.WriteLine("Guest: " + order.NameOfGuest + " Dish: " + order.NameOfDish + "Table: " + order.DestinationTable);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ready for delivery: ");
                if (this.Kitchen.ReadyOrders.Count > 0)
                {
                foreach (Dish order in this.Kitchen.ReadyOrders)
                    Console.WriteLine(order);
                }
            Console.WriteLine();
        }

        void PrintTables()
        {

            foreach (Table table in this.TableList)
            {
                Console.WriteLine("Tablenumber: " + table.TableNumber + " Seats " + table.Seats + " Available? " + table.IsAvailable + " Waiting for food? " + table.WaitingForFood);
                if (table.IsAvailable == false)
                {
                    Console.WriteLine("Company: ");
                }
                foreach (Company company in table.BookedSeats)
                {
                    foreach (Guest guest in company.Guests)
                    {
                        Console.WriteLine(guest.Name);
                    }
                }

                foreach (DictionaryEntry de in table.Orders)
                {
                    Console.WriteLine("Guest: " + de.Key + " Dish: " + de.Value);
                }

                Console.WriteLine();
            }

        } //Klar

        void PrintWaiters()
        {

            foreach (Waiter waiter in this.WaiterList)
            {
                Console.WriteLine(waiter.Name + " Busy? " + waiter.Busy);
                if (waiter.Busy == true)
                {
                    Console.WriteLine("Serving : ");

                    if (waiter.CompanyProperty.Guests.Count > 0)
                    {
                        foreach (Guest guest in waiter.CompanyProperty.Guests)
                            Console.WriteLine(guest.Name);
                    }
                    Console.WriteLine("-----------------------------------");
                }

            }

        } //Klar

        void PrintCompanies()
        {
            int i = 1;

            foreach (Company company in this.CompanyWaitingList)
            {

                Console.WriteLine("Company: " + i);

                i++;
                for (int j = 0; j < company.Guests.Count; j++)

                    Console.WriteLine(company.Guests[j].Name);
                Console.WriteLine("-----------------------------------");
            }


        } //Klar

        internal void Generate()
        {
            GenerateTable(TableList);
            GenerateWaiter();
            GenerateChefs();
        }

        internal void Addguests()
        {
            CompanyWaitingList.Enqueue(GenerateCompany());
        }

        static List<Table> GenerateTable(List<Table> tableList)
        {
            int top = 12;
            int tablenumber = 1;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 24, top, true, tablenumber, false));
                tablenumber++;
                top = top + 30;
            }
            top = 12;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(4, 0, 40, top, true, tablenumber, false));
                tablenumber++;
                top = top + 30;
            }
            return tableList;

        }

        internal Company GenerateCompany()
        {
            Company company = new Company(this.CompanyWaitingList.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
            return company;
        }

        internal void GenerateWaiter()
        {
            for (int i = 0; i < 3; i++)
            {
                string name = "Waiter " + (i + 1);
                this.WaiterList.Add(new Waiter(name, 0, false, 110, (3 + i + 1)));
            }

        }

        internal void GenerateChefs()

        {
            for (int i = 1; i < 6; i++)
                ChefList.Add(new Chef("Chef: " + i, 0, 0, 0));
        }

        internal void Work()
        {
            foreach (Waiter waiter in WaiterList)
            {
                Chef_take_Order_and_Prepare();
                if (waiter.Busy == false)
                {
                    if (CompanyWaitingList.Count > 0)
                    {
                        waiter.Busy = true;
                        greet_guest(waiter);
                        Sequence2(waiter);
                    }
                }
            }

            foreach (Chef chef in ChefList)
            {
                Chef_Order_Made(chef);
            }

            void greet_guest(Waiter waiter)
            {
                waiter.CompanyProperty = CompanyWaitingList.Dequeue();
            }

            void Sequence2(Waiter waiter)
            {
                foreach (Table table in TableList)
                {
                    if (table.Seats >= waiter.CompanyProperty.Guests.Count && table.IsAvailable == true)
                    {
                        table.BookedSeats.Add(waiter.CompanyProperty);
                        table.IsAvailable = false;
                        table.WaitingForFood = true;

                        Take_Order();
                        Give_Kitchen_Order();
                        break;
                    }
                    void Take_Order()
                    {
                        foreach (Guest guest in waiter.CompanyProperty.Guests)
                        {

                            waiter.Order.Add(new Dish("Placeholder ", 0, 0, table.TableNumber, guest.Name));
                            table.Orders.Add(guest.Name, "Placeholder");  //orders är en hashtable

                        }
                    }
                    void Give_Kitchen_Order()
                    {
                        foreach (Dish dish in waiter.Order)
                        {
                            this.Kitchen.Orders.Enqueue(dish); //kitchen.order is a list of dishes
                        }
                        waiter.Order.Clear();
                        waiter.CompanyProperty.Guests.Clear();
                        waiter.Busy = false;
                    }
                }
            }

            void Chef_Order_Made(Chef chef)
            {
                if (chef.TimeStart == (this.GlobalTimer - 10))
                {
                    foreach (Dish dish in chef.Preparing)
                    {
                        Kitchen.ReadyOrders.Enqueue(dish);

                    }
                    chef.Preparing.Clear();

                }
            }

            void Chef_take_Order_and_Prepare()
            {
                foreach (Chef chef in ChefList)
                {
                    {
                        if (chef.Busy == false)
                        {
                            if (this.Kitchen.Orders.Count > 0)
                            {
                                chef.Busy = true;

                                chef.Preparing.Add(this.Kitchen.Orders.Dequeue());
                                if (Kitchen.Orders.Count > 0)
                                {
                                    foreach (Dish dish in this.Kitchen.Orders.ToList())
                                        if (dish.DestinationTable == chef.Preparing[0].DestinationTable)
                                            this.Kitchen.Orders.Dequeue();
                                }
                                chef.TimeStart = this.GlobalTimer;
                                break;

                            }
                        }
                    }

                }
            }
        }
    }
}
    
        
    