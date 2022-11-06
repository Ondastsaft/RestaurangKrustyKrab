﻿using RestaurantKrustyKrab.GUI;
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
            Sequence1();
            PrintAll();
            Sequence2();
            GlobalTimer++;
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

        internal void Sequence1()
        {
            foreach (Chef chef in ChefList)
            {
                Chef_take_Order_from_kitchen_and_Prepare();
            }
            foreach (Waiter waiter in WaiterList)
            {
                Lead_guest_to_table_and_take_order_and_give_it_to_kitchen(waiter);
            }

            void Lead_guest_to_table_and_take_order_and_give_it_to_kitchen(Waiter waiter)
            {
                if (waiter.Busy == false)
                {
                    if (CompanyWaitingList.Count > 0)
                    {
                        waiter.Busy = true;
                        waiter.CompanyProperty = CompanyWaitingList.Dequeue();
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
                }

            }

            void Chef_take_Order_from_kitchen_and_Prepare()
            {
                foreach (Chef chef in ChefList)
                {
                    {
                        if (chef.Busy == false && Kitchen.Orders.Count > 0)
                        {
                                chef.Busy = true;
                                chef.Preparing.Add(Kitchen.Orders.Dequeue());
                                if (Kitchen.Orders.Count > 0)
                                {
                                    foreach (Dish dish in Kitchen.Orders.ToList())
                                        if (dish.DestinationTable == chef.Preparing[0].DestinationTable)
                                            Kitchen.Orders.Dequeue();
                                }
                                chef.TimeStart = GlobalTimer;
                                break;
                        }
                    }
                }
            }
        }

        internal void Sequence2()
        {
            foreach (Chef chef in ChefList)
            {
                Chef_Order_Made(chef);
            }

            foreach (Waiter waiter in WaiterList)
            {
                Take_order_from_kitchen(waiter);
                Give_food_to_table(waiter);
            }


            void Chef_Order_Made(Chef chef)
            {
                if (chef.TimeStart == (GlobalTimer - 10))
                {
                    foreach (Dish dish in chef.Preparing)
                    {
                        Kitchen.ReadyOrders.Enqueue(dish);
                    }
                    chef.Preparing.Clear();
                    chef.Busy = false;
                    chef.TimeStart = -11;
                }
            }
            void Take_order_from_kitchen(Waiter waiter)
            {
                if (Kitchen.ReadyOrders.Count > 0)
                {
                    waiter.Order.Add(Kitchen.ReadyOrders.Dequeue());
                    foreach (Dish dish in Kitchen.ReadyOrders.ToList())
                        if (dish.DestinationTable == waiter.Order[0].DestinationTable)
                            Kitchen.Orders.Dequeue();
                }
            }
            void Give_food_to_table(Waiter waiter)
            {
                foreach(Table table in TableList)
                {
                    if (waiter.Order.Count > 0)
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

        internal void Sequence3()
        {
            foreach(Table table in TableList)
            {
                if (table.Finished_Eating == true)
                {

                }

            }
        }

    }
}


    
        
    