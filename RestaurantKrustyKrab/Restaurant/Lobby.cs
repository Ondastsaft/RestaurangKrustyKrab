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
            Addguests();
            Addguests();

            Sequence();
        }

        internal void PrintAll()
        {
            Console.Clear();
            PrintCompanies();
            PrintWaiters();
            PrintTables();
            PrintKitchen();
            Console.WriteLine("Time: " + GlobalTimer);
            Console.ReadKey();
        }

        void PrintKitchen()

        {
            Console.WriteLine("KITCHEN");
            Console.WriteLine();
            Console.WriteLine("Chefs: ");
            Console.WriteLine();

            foreach (Chef chef in ChefList)
            {
                Console.WriteLine("Name: " + chef.Name + " Busy? " + chef.Busy);
                if (chef.Busy == true)
                {
                    Console.WriteLine("Preparing: ");
                    foreach (Dish dish in chef.Preparing)
                    {
                        Console.WriteLine("Dish: " + dish.NameOfDish + "Table: " + dish.DestinationTable);
                    }
                    if (chef.TimeStart > 0)
                    {
                        Console.WriteLine("Time:" + chef.TimeStart);
                        Console.WriteLine("TimeEnd: " + chef.TimeEnd);
                    }
                        
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Orders: ");
            Console.WriteLine();
            if (Kitchen.Orders.Count > 0)
            {
                foreach (Dish order in Kitchen.Orders)
                {
                    Console.WriteLine("Guest: " + order.NameOfGuest + " Dish: " + order.NameOfDish + "Table: " + order.DestinationTable);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ready for delivery: ");
            if (Kitchen.ReadyOrders.Count > 0)
            {
                foreach (Dish order in Kitchen.ReadyOrders)
                    Console.WriteLine("Dish: " + order.NameOfDish + "Table: " + order.DestinationTable + " Guest Name: " + order.NameOfGuest);
            }
            Console.WriteLine();
        } //Chefs are here

        void PrintTables()
        {

            foreach (Table table in TableList)
            {
                Console.Write("Tablenumber: " + table.TableNumber + " Seats " + table.Seats + " Available? " + table.IsAvailable + " Waiting for food? " + table.WaitingForFood);
                Console.WriteLine(" Finished eating? " + table.Finished_Eating);


                if (table.EatTimer == (GlobalTimer - 20))
                    table.Finished_Eating = true;

                if (table.RecievedOrder == true)
                {
                    foreach (DictionaryEntry de in table.Orders)
                    {
                        Console.WriteLine("Guest: " + de.Key + " Dish: " + de.Value);
                    }
                }
                else
                {
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
            }
        }

        void PrintWaiters()
        {

            foreach (Waiter waiter in WaiterList)
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
                Console.WriteLine();
            }
        }

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
        }

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

        internal void Sequence() // resten finns i program
        {

            
            void background_methods()
            {
                ChefTimer();
                GlobalTimer++;
                Check_if_food_is_ready();
                Check_if_food_is_eaten();
                Check_if_table_has_been_wiped();
                PrintAll();

            }

            GreetGuest();
            background_methods();

            Lead_To_table();
            background_methods();

            Take_Order();
            background_methods();

            Give_Kitchen_Order();
            background_methods();

            Chef_take_order();
            background_methods();

            Chef_Prepare();
            background_methods();

            Take_order_from_kitchen();
            background_methods();

            Give_food_to_table();
            background_methods();

            //waiter take payment

            Waiter_start_cleaning();
            background_methods();

        }

        internal void Check_if_food_is_eaten()
        {
            foreach (Table table in TableList)
            {
                if (table.EatTimer == (GlobalTimer - 20))
                {
                    table.Finished_Eating = true;
                }
            }
        }

        void GreetGuest()
        {
            foreach (Waiter waiter in WaiterList)
                if (waiter.Busy == false)
                {
                    if (CompanyWaitingList.Count > 0)
                    {
                        waiter.Busy = true;
                        waiter.CompanyProperty = CompanyWaitingList.Dequeue();
                    }
                }
        }

        void Lead_To_table()

        {
            foreach (Waiter waiter in WaiterList)
            {
                if (waiter.Busy == true && waiter.CompanyProperty.Guests.Count > 0)
                {
                    foreach (Table table in TableList)
                    {
                        if (table.Seats >= waiter.CompanyProperty.Guests.Count && table.IsAvailable == true && waiter.CompanyProperty.Guests.Count > 0)
                        {
                            waiter.ServingTable = table.TableNumber;
                            table.BookedSeats.Add(waiter.CompanyProperty);
                            table.IsAvailable = false;
                            table.WaitingForFood = true;
                            break;
                        }
                    }
                }
            }
        }

        void Take_Order()

        {
            foreach (Waiter waiter in WaiterList)
            {
                if (waiter.Busy == true && waiter.CompanyProperty.Guests.Count > 0)
                {
                    foreach (Guest guest in waiter.CompanyProperty.Guests)
                    {
                        waiter.Order.Add(new Dish("Placeholder ", 0, 0, waiter.ServingTable, guest.Name));
                        TableList[(waiter.ServingTable - 1)].Orders.Add(guest.Name, "Placeholder");  //orders är en hashtable
                    }


                }
            }
        }

        void Give_Kitchen_Order()

        {
            foreach (Waiter waiter in WaiterList)
            {
                if (waiter.Order.Count > 0)
                {
                    foreach (Dish dish in waiter.Order)
                    {
                        Kitchen.Orders.Enqueue(dish); //kitchen.order is a list of dishes
                    }
                    waiter.Order.Clear();
                    waiter.CompanyProperty.Guests.Clear();
                    waiter.Busy = false;
                }

            }

        }

        void Chef_take_order()

        {
            foreach (Chef chef in ChefList)
            {
                if (chef.Busy == false && Kitchen.Orders.Count > 0)
                {
                    chef.Busy = true;
                    chef.Preparing.Add(Kitchen.Orders.Dequeue());

                    if (Kitchen.Orders.Count > 0)
                    {
                        foreach (Dish dish in Kitchen.Orders.ToList())
                            if (dish.DestinationTable == chef.Preparing[0].DestinationTable)
                                chef.Preparing.Add(Kitchen.Orders.Dequeue());
                    }
                }
            }

        }

        void Chef_Prepare()
        {
            
            foreach (Chef chef in ChefList)
            {
                if (chef.Preparing.Count > 0 && chef.Busy == true && chef.Cooking == false)
                {
                    chef.TimeStart = GlobalTimer;
                    chef.TimeEnd = chef.TimeStart + 10;
                    chef.Cooking = true;
                }
                    
            }


        }

        void Take_order_from_kitchen()
        {
            foreach (Waiter waiter in WaiterList)

                if (Kitchen.ReadyOrders.Count > 0 && waiter.Busy == false)
                {
                    waiter.Busy = true;
                    waiter.Order.Add(Kitchen.ReadyOrders.Dequeue());
                    foreach (Dish dish in Kitchen.ReadyOrders.ToList())
                        if (dish.DestinationTable == waiter.Order[0].DestinationTable)
                            Kitchen.Orders.Dequeue();
                }
        }
        void Give_food_to_table()

        {
            foreach (Waiter waiter in WaiterList)
            {
                foreach (Table table in TableList)
                {
                    if (waiter.Busy == true && waiter.Order.Count > 0)
                    {
                        if (waiter.Order[0].DestinationTable == table.TableNumber)
                        {
                            table.RecievedOrder = true;
                            waiter.Order.Clear();
                            waiter.Busy = false;
                            table.EatTimer = GlobalTimer;
                            break;
                        }
                    }
                }
            }
        }

        internal void Check_if_food_is_ready()

        {
            foreach (Chef chef in ChefList)
            {
                if (chef.TimeStart == chef.TimeEnd)
                {
                    foreach (Dish dish in chef.Preparing)
                    {
                        Kitchen.ReadyOrders.Enqueue(dish);
                    }
                    chef.Preparing.Clear();
                    chef.Busy = false;
                    
                }
            }
        }

        internal void ChefTimer ()
        {
            foreach (Chef chef in ChefList)
            {
                if (chef.Preparing.Count > 0 && chef.Busy == true)
                {
                    chef.TimeStart++;
                }
            }
        }

        internal void Check_if_table_has_been_wiped()
        {
            foreach (Table table in TableList)
            {
                if (table.WipeTimer == (GlobalTimer - 3))
                {
                    table.Clean = true;
                    WaiterList.Add(table.WipedBy[0]);
                    table.WipedBy.Clear();
                }

            }
        } //deletes the waiter from table and adds it back to waiterlist

        internal void Waiter_start_cleaning()  //not done
        {
            foreach (Waiter waiter in WaiterList)
            {
                if (waiter.Busy == false)
                {
                    waiter.Busy = true;
                    foreach (Table table in TableList)

                        if (table.Finished_Eating == true)
                        {
                            tableReset(table);
                            waiter.WipeTimer = GlobalTimer;
                            table.Clean = false;
                            table.WipedBy.Add(waiter);
                            WaiterList.Remove(waiter);
                            break;
                        }
                }
            }



            static void tableReset(Table table)
            {
                table.WaitingForFood = false;
                table.IsAvailable = true;
                table.EatTimer = -21;
                table.Orders.Clear();
            }
        }
    }
}








