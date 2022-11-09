using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Draw
    {

        public void draw(List<Table> TableList, Kitchen Kitchen, Reception Reception, DishStation DishStation, List<Waiter> WaiterList, 
                         Queue<Company> CompanyWaitingList, List<Chef> ChefList, int Globaltimer, List<string> PaidOrders)
        {
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.Frame);
            }
            
            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.Frame);
            Window.OurDraw("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.Frame);
            Window.OurDraw("Reception", Reception.PositionY, Reception.PositionX, Reception.Frame);
            DrawWaitersAtReception();
            DrawGuestsAtReception();
            foreach (Table table in TableList)
                {
                Draw_Guests_AT_Tables(table);
            }
            DrawWaitersAtTables();
            DrawWaitersAtKitchen();
            DrawChefsAtKitchen();
            DrawGlobalTimer(Globaltimer);
            DrawOrders();
            DrawTransactions();

            void DrawWaitersAtReception()
            {
                Console.SetCursorPosition(Reception.PositionY + 30, (Reception.PositionX));  //Y flyttar i sidled, X flyttar på höjden
                int X = 1;
                foreach (Waiter waiter in WaiterList)
                {
                    if (waiter.AT_Reception == true)
                    {
                        Console.Write(waiter.Name);
                        if (waiter.CompanyProperty.Guests.Count > 0)
                            Console.WriteLine(" " + waiter.CompanyProperty.Guests[0].Name + " + " + waiter.CompanyProperty.Guests.Count);
                        Console.SetCursorPosition(Reception.PositionY + 30, Reception.PositionX + X);
                        X++;
                    }

                    
                }
            }
            
            

            void DrawGuestsAtReception()
            {
                int Y = 1;
                Console.SetCursorPosition(Reception.PositionY + 2, Reception.PositionX + Y);
                Console.Write("Guests: ");

                foreach (Company company in CompanyWaitingList)
                {
                    Y++;
                    Console.SetCursorPosition(Reception.PositionY + 2, Reception.PositionX + Y);
                    Console.WriteLine("Company" + company.Guests[0].Name + " + " + company.Guests.Count);
                }
            }
            
            void Draw_Guests_AT_Tables(Table table)
            {
                int Z = 1;

                foreach (Guest guest in table.BookedSeats.Guests)
                {
                    Console.SetCursorPosition(table.PositionY + 1, table.PositionX + Z);
                    Console.Write(guest.Name);

                    if (guest.Order.Count > 0)
                        if (guest.Recieved_Order == true)
                            Console.Write(" has recieved " + guest.Order[0].Name);

                        else
                            Console.Write(" has ordered " + guest.Order[0].Name);
                    Z++;

                }
                        

                }
            
            void DrawWaitersAtTables()
            {
                foreach(Waiter waiter in WaiterList)
                    if (waiter.Taking_or_Giving_Order_at_table == true)
                        foreach (Table table in TableList)
                            if(waiter.ServingTable == table.TableNumber)
                            {
                                Console.SetCursorPosition(table.PositionY +1, table.PositionX - 1);
                                Console.Write(waiter.Name);
                            }
            }

            void DrawWaitersAtKitchen()  //börja här
            {
                
                int K = 5;
                foreach (Waiter waiter in WaiterList)
                {
                    if (waiter.At_Kitchen == true)
                    {
                        Console.SetCursorPosition(Kitchen.PositionY - 10, Kitchen.PositionX + K);
                        Console.WriteLine(waiter.Name);
                        K = K + 2;
                    }
                
                }
            }

            void DrawChefsAtKitchen()
            {
                int C = 2;
                foreach (Chef chef in ChefList)
                {
                    Console.SetCursorPosition(Kitchen.PositionY + 10, Kitchen.PositionX + C);
                    Console.Write(chef.Name);
                    if(chef.Cooking == true && chef.Busy == true)
                    {
                        Console.Write(" Cooking for table " + chef.Preparing[0].DestinationTable + " Ready at: " + chef.TimeEnd);
                    }
                    else if(chef.Busy == true)
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
                Console.SetCursorPosition(Kitchen.PositionY + 3, Kitchen.PositionX + 15);
                Console.Write("Unfinished Orders: ");
                if (Kitchen.Orders.Count > 0)
                
                    Console.Write(Kitchen.Orders.Count);
                

                Console.SetCursorPosition(Kitchen.PositionY + 25, Kitchen.PositionX + 15);
                Console.Write("Finished Orders: ");
                if (Kitchen.ReadyOrders.Count > 0)
                
                    Console.WriteLine("Ready Orders " + Kitchen.ReadyOrders.Count);
                
            }

            void DrawTransactions()
            {
                
                Console.SetCursorPosition(150, 60);  //Y flyttar i sidled, X flyttar på höjden
                Console.WriteLine("EventLog:");
                int X = 1;
                if (PaidOrders.Count > 0)
                {
                    foreach (string Event in PaidOrders)
                    {                        
                            Console.WriteLine(Event);
                            Console.SetCursorPosition(150, 60 + X);
                            X++;
                        }
                    }
                }
                
             

            Console.ReadKey();
            Console.Clear();
               
        }


        public Draw()
        {
           

        }



    }
}
