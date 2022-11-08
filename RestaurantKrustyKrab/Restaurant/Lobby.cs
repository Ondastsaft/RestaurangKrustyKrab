using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Collections;
using RestaurantKrustyKrab.Restaurant.Dishes;
using System.Xml.Linq;
using RestaurantKrustyKrab.Restaurant.Dishes.Fish;
using RestaurantKrustyKrab.Restaurant.Dishes.Meat;
using RestaurantKrustyKrab.Restaurant.Dishes.Vegetarian;
using System.Collections.Generic;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    { 
        //internal DishStation DishStation { get; set; }
        //internal Reception Reception { get; set; }
        //internal int CounterRestaurant { get; set; }
        //internal WC WC { get; set; }
        //internal string[,] MyDrawing { get; set; }
        //internal string Name { get; set; }
        //internal int PositionX { get; set; }
        //internal int PositionY { get; set; }

        public List<Table> TableList { get; set; }
        internal List<Waiter> WaiterList { get; set; }
        internal Queue<Company> CompanyWaitingList { get; set; }
        internal List<Chef> ChefList { get; set; }
        public int GlobalTimer { get; set; }
        internal Kitchen Kitchen { get; set; }
        internal List<Guest> Visited_Guests { get; set; }
        internal bool Full_Restaurant { get; set; }
        internal List<string> PaidOrders { get; set; }
       

        public Lobby()
        {
            //MyDrawing = new string[50, 200];
            //Name = "Krusty Krab";
            //PositionX = 4;
            //PositionY = 2;

            //DishStation = new DishStation(3, 128);
            //Reception = new Reception(3, 31);
            //WC = new WC(25, 188);
            TableList = new List<Table>();
            Kitchen = new Kitchen(false, 3, 157);
            GlobalTimer = 0;
            CompanyWaitingList = new Queue<Company>();
            WaiterList = new List<Waiter>();
            ChefList = new List<Chef>();
            Visited_Guests = new List<Guest>();
            Full_Restaurant = false;
            PaidOrders = new List<string>();
           

            Generate();
        }


        internal void LobbyRun()
        {
            if (Visited_Guests.Count < 80)
            {
                Addguests();
                Addguests();
                Addguests();
            }
           

            Sequence();
        }
 
        internal void Generate()
        {
            GenerateTable(TableList);
            GenerateWaiter();
            GenerateChefs();

        }

        internal void Addguests()
        {
            var company = GenerateCompany();
            CompanyWaitingList.Enqueue(company);
            
            foreach (Guest guest in company.Guests)
            Visited_Guests.Add(guest);
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
            Company company = new Company(this.CompanyWaitingList.Count);
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

        
        internal void Sequence() 

        {
            PrintMethods printMethods = new PrintMethods();
            foreach (Waiter waiter in WaiterList)
                waiter.Busy = false;

            foreach (Table table in TableList)
            {
                if (table.Finished_Eating == true)
                    Waiter_start_cleaning_And_Take_payment(table);
            }
                
               background_methods();

            if (Kitchen.ReadyOrders.Count > 0)
            {
                
                background_methods();

                Take_order_from_kitchen();
                background_methods();

                Give_food_to_table();
                background_methods();

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

          

            void background_methods()
            {
                TableTimer();
                ChefTimer();
                Wipetimer();
                GlobalTimer++;
                Chef_readies_an_order();
                Check_if_food_has_been_eaten();
                Check_if_table_has_been_wiped();
                Check_if_Restaurant_is_full();
               
                printMethods.PrintAll(CompanyWaitingList, GlobalTimer, WaiterList, TableList, ChefList, Kitchen, PaidOrders, Visited_Guests);

            }
        }

    
        void GreetGuest()
        {
            foreach (Waiter waiter in WaiterList)
                if (waiter.Busy == false)
                {
                    if (CompanyWaitingList.Count > 0 && Full_Restaurant == false)
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
                            foreach (Guest guest in waiter.CompanyProperty.Guests)
                                table.BookedSeats.Guests.Add(guest);

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
            GoodMethod G = new GoodMethod();
            foreach (Waiter waiter in WaiterList)
            {
                if (waiter.Busy == true && waiter.CompanyProperty.Guests.Count > 0)
                {
                    foreach (Guest guest in waiter.CompanyProperty.Guests)
                    {
                        G.AddOrderTo_Table_Guest_Waiter(guest.Prefered_dish, waiter,guest,TableList);

                    }


                }
            }
            }

        void Give_Kitchen_Order()

        {
            foreach (Waiter waiter in WaiterList)
            {
                if (waiter.Busy = true && waiter.Orders.Count > 0)
                {
                    foreach (Dish dish in waiter.Orders)
                    {
                        Kitchen.Orders.Enqueue(dish); //kitchen.order is a list of dishes
                    }
                    waiter.Orders.Clear();
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

                if (Kitchen.ReadyOrders.Count > 0)
                {
                    waiter.Busy = true;
                    waiter.Orders.Add(Kitchen.ReadyOrders.Dequeue());
                    foreach (Dish dish in Kitchen.ReadyOrders.ToList())
                        if (dish.DestinationTable == waiter.Orders[0].DestinationTable)
                            Kitchen.ReadyOrders.Dequeue();
                }
        }

        void Give_food_to_table()

        {
            foreach (Waiter waiter in WaiterList)
            {
                foreach (Table table in TableList)
                {
                    if (waiter.Busy == true && waiter.Orders.Count > 0)
                    {
                        
                        if (waiter.Orders[0].DestinationTable == table.TableNumber)
                        {
                            table.WaitingForFood = false;
                            table.RecievedOrder = true;
                            foreach (Dish dish in waiter.Orders)
                                foreach (Guest guest in table.BookedSeats.Guests)
                                    if (dish.Guest == guest.Name)
                                        guest.Order.Add(dish);

                            waiter.Orders.Clear();
                            waiter.Busy = false;
                            table.EatTimer = GlobalTimer;
                            table.TimeEnd = table.EatTimer + 20;
                            break;
                        }
                    }
                }
            }
        }

        internal void Wipetimer()
        {
            foreach (Table table in TableList)
            {
                if (table.Clean == false)
                    table.WipeTimer++;
            }
        }

        internal void TableTimer()
        {
            foreach (Table table in TableList)
            {
                if (table.RecievedOrder == true)
                    table.EatTimer = table.EatTimer +10;
            }

        }

        internal void ChefTimer()
        {
            foreach (Chef chef in ChefList)
            {
                if (chef.Preparing.Count > 0 && chef.Busy == true)
                {
                    chef.TimeStart = chef.TimeStart + 5;
                }
            }
        }

        internal void Chef_readies_an_order()

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
                    chef.TimeStart = -11;
                    chef.Cooking = false;
                    Kitchen.FoodIsReady = true;

                }
            }
        }

        internal void Check_if_food_has_been_eaten()
        {
            foreach (Table table in TableList)
            {
                if (table.EatTimer >= table.TimeEnd)
                    table.Finished_Eating = true;
            }
        }

        internal void Check_if_table_has_been_wiped() // also removes the waiter from table.WipedBy 
        {
            foreach (Table table in TableList)
                if (table.Clean == false)
                    {
                        if (table.WipeTimer >= table.WipeEnd)
                        {
                            table.Clean = true;
                            WaiterList.Add(table.WipedBy[0]);
                            table.WipedBy.Clear();
                        }
                    }
        }

        internal void Check_if_Restaurant_is_full()
        {
            int tablecounter = 0;
            foreach(Table table in TableList)
            {
                if (table.IsAvailable == false)
                {
                    tablecounter++;
                }
            }
            if (tablecounter == 9)
                Full_Restaurant = true;
            else
                Full_Restaurant = false;

        }


        internal void Waiter_start_cleaning_And_Take_payment(Table table)  //not done
        {
                {
                    foreach (Waiter waiter in WaiterList)
                    {
                        if (waiter.Busy == false)
                        {
                            
                            waiter.Busy = true;
                            tableReset(table, waiter);
                            table.WipeTimer = GlobalTimer;
                            table.WipeEnd = table.WipeTimer + 3;
                            table.Clean = false;
                            table.WipedBy.Add(waiter);
                            WaiterList.Remove(waiter);
                            break;
                        }

                    }

                    void tableReset(Table table, Waiter waiter)
                    {

                        Console.Clear();
                        Console.WriteLine("Table Reset");

                        table.WaitingForFood = false;
                        table.IsAvailable = true;
                        table.RecievedOrder = false;
                        table.Finished_Eating = false;
                        table.EatTimer = -21;
                        
                        
                        foreach(Guest guest in table.BookedSeats.Guests)
                        {

                            Console.WriteLine("Name: " + guest.Name + " Orders: " + guest.Order.Count + " Order: " + guest.Order[0].Name + " Money: " +  guest.Money + "Price: " + guest.Order[0].Price);

                        if 
                            (guest.Money >= guest.Order[0].Price)
                            PaidOrders.Add(guest.Name + " ordered " + guest.Order[0].Name + " for " + guest.Order[0].Price + " and paid for it");

                        else
                        {
                            Console.WriteLine(guest.Name + " was forced to help with the dishes");
                            PaidOrders.Add(guest.Name + " could not afford their " + guest.Order[0].Name + " was forced to help with the dishes");
                        }

                    }
                    Console.ReadKey();
                    waiter.CompanyProperty.Guests.Clear();
                    table.Orders.Clear();
                    table.BookedSeats.Guests.Clear();
                    }
                }
        }
    }
}
    








