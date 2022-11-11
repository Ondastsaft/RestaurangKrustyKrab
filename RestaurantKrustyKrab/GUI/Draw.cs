using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant;
using RestaurantKrustyKrab.Restaurant.Dishes;
using RestaurantKrustyKrab.Stations;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.GUI
{
    internal class Draw
    {
        public void draw(List<Table> TableList, Kitchen Kitchen, Reception Reception, DishStation DishStation, List<Waiter> WaiterList,
                         Queue<Company> CompanyWaitingList, List<Chef> ChefList, int Globaltimer, List<string> PaidOrders, List<Guest> Visited_Guests)
        {
            Console.Clear();
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.Frame);
            }

            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.Frame);
            Window.OurDrawBottomLess("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.Frame);
            Window.OurDrawBottomLess("Reception", Reception.PositionY, Reception.PositionX, Reception.Frame);
            
            DrawGuestsAtReception();
            DrawTables();
            Draw_Waiters();

            DrawChefsAtKitchen();
            DrawGlobalTimer(Globaltimer);
            DrawOrders();
            DrawTransactions();
            Draw_Total_Number_Of_Guests();
            Draw_Dishers(DishStation);

            void DrawGuestsAtReception()
            {
                int Y = 1;
                Console.SetCursorPosition(Reception.PositionY + 2, Reception.PositionX + Y);
                Console.Write("Guests: ");

                foreach (Company company in CompanyWaitingList)
                {
                    if (CompanyWaitingList.Count > 0)
                    {
                        Y++;
                        Console.SetCursorPosition(Reception.PositionY + 2, Reception.PositionX + Y);
                        try
                        {
                            Console.Write("Company " + company.Guests[0].Name);
                            if ((company.Guests.Count) > 1)
                                Console.Write(" + " + (company.Guests.Count - 1));
                        }

                        catch (ArgumentOutOfRangeException)
                        {
                            //Console.Clear();
                            //Console.WriteLine("Buggen");    //känd bug solved :)
                            //Console.ReadKey();
                            Console.WriteLine("Ghost");
                            continue;
                        }

                    }

                }
            }

            void Draw_Waiters()
                {
                DrawWaitersAtReception();
                DrawWaitersAtTables();
                DrawWaitersAtKitchen();


                void DrawWaitersAtReception()
            {
                Console.SetCursorPosition(Reception.PositionY + 30, Reception.PositionX);  //Y flyttar i sidled, X flyttar på höjden
                int X = 1;
                foreach (Waiter waiter in WaiterList)
                {
                    if (waiter.Location == "Reception")
                    {
                        Console.Write(waiter.Name + " " + waiter.Activity);
                        if (waiter.CompanyProperty.Guests.Count >= 1)
                        {
                                Console.Write(" " + waiter.CompanyProperty.Guests[0].Name);
                                if (waiter.CompanyProperty.Guests.Count > 1 )
                                Console.Write((" + " + (waiter.CompanyProperty.Guests.Count - 1)));
                        }
                        Console.SetCursorPosition(Reception.PositionY + 30, Reception.PositionX + X);
                        X++;
                    }
                }
            }
                
                void DrawWaitersAtTables()
            {

                foreach (Waiter waiter in WaiterList)
                {
                    foreach (Table table in TableList)

                        if (waiter.ServingTable == table.TableNumber && waiter.Location == "Tables")
                        {
                            Console.SetCursorPosition(table.PositionY + 1, table.PositionX - 1);
                            Console.Write(waiter.Name + " " + waiter.Activity);
                        }
                }

            }

                void DrawWaitersAtKitchen()
            {

                int K = 5;
                foreach (Waiter waiter in WaiterList)
                {
                    if (waiter.Location == "Kitchen")
                    {
                        Console.SetCursorPosition(Kitchen.PositionY - 10, Kitchen.PositionX + K);
                        Console.Write(waiter.Name);
                        Console.SetCursorPosition(Kitchen.PositionY - 26, Kitchen.PositionX + K + 1);
                        Console.Write(waiter.Activity);
                        K = K + 2;
                    }

                }
            }


            }

            void DrawTables()
            {
                foreach (Table table in TableList)
                {
                    Draw_Tables(table);
                }

                void Draw_Tables(Table table)
            {
                int Z = 1;

                if (table.Clean == false)
                {
                    Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z);
                    Console.Write("Being wiped by: ");
                    Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z + 1);
                    Console.Write(table.WipedBy);
                    Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z + 2);
                    Console.Write("Done at: " + table.WipeEnd);
                }


                foreach (Guest guest in table.BookedSeats.Guests)
                {
                    Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z);
                    Console.Write(guest.Name);
                        Z++;


                        if (guest.Order.Count > 0)
                    {
                        if (guest.Recieved_Order == true)
                            Console.Write(" has recieved " + guest.Order[0].Name);

                        else
                            Console.Write(" has ordered " + guest.Order[0].Name);
                           
                                             
                            }
                        }

                    if (table.Orders.Count > 0)
                    {
                        foreach (Dish dish in table.Orders)
                        {
                            Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z);
                            Console.Write(dish.Name + " " + dish.Guest);
                            Z++;
                        }
                    }

                if (table.RecievedOrder == true)
                {
                    Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z + 1);
                    Console.Write("Done eating at " + table.TimeEnd);
                }
            }
            } //Loops through all tables

            void DrawChefsAtKitchen()
            {
                int C = 2;
                foreach (Chef chef in ChefList)
                {
                    Console.SetCursorPosition(Kitchen.PositionY + 10, Kitchen.PositionX + C);
                    Console.Write(chef.Name);
                    if (chef.Cooking == true && chef.Busy == true)
                    {
                        Console.Write(" Cooking for table " + chef.Preparing[0].DestinationTable + " Ready at: " + chef.TimeEnd);
                    }
                    else if (chef.Busy == true)
                    {
                        Console.WriteLine(" Grabbing orders");
                    }

                    C = C + 2;
                }
            }

            void DrawGlobalTimer(int GlobalTimer)
            {
                Console.SetCursorPosition(200, 60);  //Y flyttar i sidled, X flyttar på höjden
                Console.Write("Timer:" + GlobalTimer);

            }

            void DrawOrders()
            {
                int Y = 1;
                Console.SetCursorPosition(Kitchen.PositionY + 3, Kitchen.PositionX + 15);
                Console.Write("Not prepared dishes: ");
                if (Kitchen.Orders.Count > 0)
                {
                    Console.Write(Kitchen.Orders.Count);
                    foreach(Dish dish in Kitchen.Orders)
                    {
                        Console.SetCursorPosition(Kitchen.PositionY + 3, Kitchen.PositionX + 15 + Y);
                        Console.Write(dish.Name + " "  + dish.Guest + " " + dish.DestinationTable);
                            Y++;
                    }
                }



                Y = 1;
                Console.SetCursorPosition(Kitchen.PositionY + 40, Kitchen.PositionX + 15);
                Console.Write("Finished Orders: ");
                if (Kitchen.ReadyOrders.Count > 0)

                    Console.WriteLine("Ready dishes " + Kitchen.ReadyOrders.Count);
                foreach (Dish dish in Kitchen.ReadyOrders)
                {
                    Console.SetCursorPosition(Kitchen.PositionY + 40 + Y, Kitchen.PositionX + 15 + Y);
                    Console.Write(dish.Name+ " " + dish.Guest + " " + dish.DestinationTable);
                    Y++;
                }
            }

            void DrawTransactions()
            {

                Console.SetCursorPosition(90, 59);  //Y flyttar i sidled, X flyttar på höjden
                Console.WriteLine("EventLog:");
                int X = 1;
                if (PaidOrders.Count > 0)
                {

                    foreach (string Event in PaidOrders.ToArray().Reverse())
                    {
                        X++;
                        Console.SetCursorPosition(90, 60 + X);
                        Console.WriteLine(Event);
                    }
                }
            }

            void Draw_Total_Number_Of_Guests()
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Total visited guests " + Visited_Guests.Count);
            }

            void Draw_Dishers(DishStation DishStation)
            {
                int X = 1;
                Console.SetCursorPosition(DishStation.PositionY + 2, DishStation.PositionX + 1);
                Console.Write("Dishers: ");
                if (DishStation.Guests.Count > 0)
                {
                    foreach (Guest guest in DishStation.Guests)
                    {
                        if (DishStation.Guests.Count > 0)
                        {
                            Console.SetCursorPosition(DishStation.PositionY + 2, DishStation.PositionX + 1 + X);
                            Console.Write(guest.Name + "Done at: " + guest.Dishing_end);
                            X++;
                        }
                        else
                            break;

                    }

                }


            }
            PrintMethods printMethods = new PrintMethods();
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar == 'p')
            {
                printMethods.PrintAll(CompanyWaitingList, Globaltimer, WaiterList, TableList, ChefList, Kitchen, PaidOrders, Visited_Guests); //readkey finns i PrintAll
            }
           



        }


        public Draw()
        {


        }



    }
}
