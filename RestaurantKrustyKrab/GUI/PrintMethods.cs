using RestaurantKrustyKrab.People;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantKrustyKrab.Restaurant.Dishes;
using RestaurantKrustyKrab.Stations;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class PrintMethods
    { 
           public void PrintAll(Queue<Company>CompanyWaitingList, int GlobalTimer, List<Waiter> WaiterList, 
                                List<Table> TableList, List<Chef> ChefList, Kitchen kitchen, List<String> PaidOrders, List<Guest> Visited_Guests)
            {
                Console.Clear();
                PrintCompanies(CompanyWaitingList);
                PrintWaiters(WaiterList);
                PrintTables(TableList);
                PrintKitchen(ChefList, kitchen);
                PrintTransactions(PaidOrders);
                PrintTotal_Number_Of_Visited_Guests(Visited_Guests);
                Console.WriteLine("Time: " + GlobalTimer);
                Console.ReadKey();
            }

            void PrintCompanies(Queue<Company> CompanyWaitingList)
            {
                int i = 1;
                Console.WriteLine("QUEUE");
                Console.WriteLine();

                foreach (Company company in CompanyWaitingList)
                {
                    
                    Console.WriteLine("Company: " + i);

                    i++;
                    for (int j = 0; j < company.Guests.Count; j++)
                        Console.WriteLine(company.Guests[j].Name);
                Console.WriteLine("Time waiting: " + company.TimeWaiting);
                    Console.WriteLine("-----------------------------------");
                }
            }

            void PrintWaiters(List<Waiter> WaiterList)
            {

                foreach (Waiter waiter in WaiterList)
                {
                    Console.Write(waiter.Name + "Activity: " + waiter.Activity +"\n" );

                    if (waiter.Busy == true)
                    {
                        if (waiter.CompanyProperty.Guests.Count > 0)
                        {
                            Console.Write("Company:");

                        foreach (Guest guest in waiter.CompanyProperty.Guests)
                                
                                Console.Write(" " + guest.Name);
                        }
                    if (waiter.ServingTable > 0)
                        Console.WriteLine("\nAt Table " + waiter.ServingTable);

                }
                Console.WriteLine();
                }
            Console.WriteLine();
        }

            void PrintTables(List<Table> TableList)
            {

                foreach (Table table in TableList)

                    if (table.Clean == false)
                    {
                        Console.WriteLine("Tablenumber: " + table.TableNumber + " This table is being wiped by " + table.WipedBy);
                        Console.WriteLine("Wipetimer: " + table.WipeTimer);
                        Console.WriteLine("WipeEnd: " + table.WipeEnd);
                    }

                    else
                    {

                        Console.Write("Tablenumber: " + table.TableNumber + " Seats " + table.Seats + " Available? " + table.IsAvailable + " Waiting for food? " + table.WaitingForFood + " Quality: " + table.Quality);
                        Console.WriteLine(" Finished eating? " + table.Finished_Eating);
                        Console.WriteLine();


                    if (table.RecievedOrder == true)
                    {
                        Console.WriteLine("Timer: " + table.EatTimer);
                        Console.WriteLine("Time Done eating: " + table.TimeEnd);
                    }

                    else
                    {
                        if (table.IsAvailable == false)
                        {
                            Console.Write("Company:");
                        
                        
                        foreach (Guest guest in table.BookedSeats.Guests)
                        {

                            Console.Write(" " + guest.Name);
                                if (table.WaitingForFood == true)
                                    if (guest.Order.Count> 0)
                                        Console.Write(" " + guest.Order[0].Name);
                                    
                        }

                        Console.WriteLine();
                        }
                        }
                    }
            }

            void PrintKitchen(List<Chef> ChefList, Kitchen kitchen)

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
                            Console.WriteLine("Dish: "+ dish.Name + " Table: " + dish.DestinationTable, "Guest:" + dish.Guest);
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
                Console.WriteLine("Orders: " + kitchen.Orders.Count);
                Console.WriteLine();

            if (kitchen.Orders.Count > 0)
            {
                foreach (Dish order in kitchen.Orders)
                {
                    Console.WriteLine("Guest: " + order.Guest + " Dish: " + order.Name + "Table: " + order.DestinationTable);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Orders ready for delivery: " + kitchen.ReadyOrders.Count);
            if (kitchen.ReadyOrders.Count > 0)
            {
                foreach (Dish order in kitchen.ReadyOrders)
                    Console.WriteLine("Dish: " + order.Name + "Table: " + order.DestinationTable + " Guest Name: " + order.Guest);
            }
            Console.WriteLine();
            }

            void PrintTotal_Number_Of_Visited_Guests(List<Guest> Visited_Guests)
            {
                Console.WriteLine("Visited Guests: " + Visited_Guests.Count);
                Console.WriteLine();

            }

            void PrintTransactions(List<string> PaidOrders)
            {
                Console.WriteLine("Transactions:" + PaidOrders.Count);
                foreach (string Order in PaidOrders)
                    Console.WriteLine(Order);
                Console.WriteLine();
            }
        }
        
    }

