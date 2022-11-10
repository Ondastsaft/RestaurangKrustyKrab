using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Collections;
using RestaurantKrustyKrab.Restaurant.Dishes;
using System.Xml.Linq;
using RestaurantKrustyKrab.Restaurant.Dishes.Fish;
using RestaurantKrustyKrab.Restaurant.Dishes.Meat;
using RestaurantKrustyKrab.Restaurant.Dishes.Vegetarian;
using System.Collections.Generic;
using RestaurantKrustyKrab.Restaurant;

namespace RestaurantKrustyKrab.Stations
{
    internal class Lobby
    {
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        internal string[,] MyDrawing { get; set; }
        internal string Name { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }

        private static Random random = new Random();
        private List<Table> TableList { get; set; }
        private List<Waiter> WaiterList { get; set; }
        private Queue<Company> CompanyWaitingList { get; set; }
        private List<Chef> ChefList { get; set; }
        private int GlobalTimer { get; set; }
        private Kitchen Kitchen { get; set; }
        private List<Guest> Visited_Guests { get; set; }
        private bool Full_Restaurant { get; set; }
        private List<string> PaidOrders { get; set; }
        private int LargeTables { get; set; }
        private List<Guest> Dishers { get; set; }


        public Lobby()
        {
            MyDrawing = new string[70, 305];
            Name = "Krusty Krab";
            PositionX = 4;
            PositionY = 2;

            DishStation = new DishStation(3, 115);
            Reception = new Reception(55, 31);
            TableList = new List<Table>();
            Kitchen = new Kitchen(false, 3, 180);
            GlobalTimer = 0;
            CompanyWaitingList = new Queue<Company>();
            WaiterList = new List<Waiter>();
            ChefList = new List<Chef>();
            Visited_Guests = new List<Guest>();
            Full_Restaurant = false;
            PaidOrders = new List<string>(new string[5]);
            Dishers = new List<Guest>();
            Dishers.Clear();
            LargeTables = 4;

            Generate();
        }


        internal void LobbyRun()  //sitter i en while loop

        {

            if (Visited_Guests.Count < 80)
            {
                for (int i = 0; i < random.Next(0, 4); i++)
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
                tableList.Add(new Table(2, random.Next(0, 4), 24, top, true, tablenumber, false, 4, 30));
                tablenumber++;
                top = top + 33;
            }
            top = 12;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(4, random.Next(0, 4), 40, top, true, tablenumber, false, 8, 30));
                tablenumber++;
                top = top + 33;
            }
            return tableList;

        }

        internal Company GenerateCompany()
        {
            Company company = new Company(CompanyWaitingList.Count);
            return company;
        }

        internal void GenerateWaiter()
        {
            for (int i = 0; i < 3; i++)
            {
                string name = "Waiter " + (i + 1);
                WaiterList.Add(new Waiter(name, random.Next(0, 4), false, 110, 3 + i + 1));
            }

        }

        internal void GenerateChefs()

        {
            for (int i = 1; i < 6; i++)
                ChefList.Add(new Chef("Chef: " + i, random.Next(0, 4), 0, 0));
        }

        internal void Sequence()

        {

            PrintMethods printMethods = new PrintMethods();
            Draw draw = new Draw();

            foreach (Waiter waiter in WaiterList)
            {
                waiter.Work(CompanyWaitingList, Full_Restaurant, TableList, Kitchen, GlobalTimer, PaidOrders, DishStation, LargeTables);

            }
            background_methods();

            if (Kitchen.Orders.Count > 0)
            {
                Chef_take_order();
                Chef_Prepare();
                background_methods();
            }

            void background_methods()
            {
                AllTimers();
                Chef_readies_an_order();
                Check_if_food_has_been_eaten();
                Check_if_table_has_been_wiped();
                Check_Large_tables();
                Check_if_Restaurant_is_full();
                Check_if_dishers_are_done();
                draw.draw(TableList, Kitchen, Reception, DishStation, WaiterList, CompanyWaitingList, ChefList, GlobalTimer, PaidOrders, Visited_Guests);

                //printMethods.PrintAll(CompanyWaitingList, GlobalTimer, WaiterList, TableList, ChefList, Kitchen, PaidOrders, Visited_Guests); //readkey finns i PrintAll

            }
        }

        void AllTimers()
        {
            TableTimer();
            ChefTimer();
            Wipetimer();
            GuestTimer();
            DisherTimer();
            GlobalTimer++;
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
                            {
                                chef.Preparing.Add(Kitchen.Orders.Dequeue());
                            }
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

                    foreach (Dish dish in chef.Preparing)
                        dish.Quality = chef.Competence;
                }
            }
        }

        internal void GuestTimer()
        {
            foreach (Company company in CompanyWaitingList)
            {
                company.TimeWaiting++;
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
                    table.EatTimer++;
            }

        }

        internal void ChefTimer()
        {
            foreach (Chef chef in ChefList)
            {
                if (chef.Preparing.Count > 0 && chef.Busy == true)
                {
                    chef.TimeStart++;
                }
            }
        }

        internal void DisherTimer()
        {
            foreach (Guest guest in DishStation.Guests)
            {
                guest.Dishing_start++;
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
                        table.WipedBy = "";
                        table.Clean = true;

                    }
                }
        }

   
        internal void Check_if_Restaurant_is_full()
        {
            int tablecounter = 0;
            foreach (Table table in TableList)
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

        internal void Check_Large_tables()
        {
            int largetables = 0;
            foreach (Table table in TableList)
            {
                if (table.IsAvailable && table.Seats >= 3 && table.Clean == true && table.WaitingForFood == false && table.RecievedOrder == false && table.Finished_Eating == false)
                    largetables++;
            }
            LargeTables = largetables;
        }

        internal void Check_if_dishers_are_done()
        {

            {
                if (DishStation.Guests.Count > 0)

                    foreach (Guest guest in DishStation.Guests)
                    {
                        if (guest.Dishing_start >= guest.Dishing_end)
                        {
                            DishStation.Guests.Clear();
                            break;
                        }
                    }
            }
        }

    }
}











