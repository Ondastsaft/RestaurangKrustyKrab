using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantKrustyKrab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lobby MyLobby = new Lobby();
            MyLobby.Generate();
            while (true)
            {   MyLobby.Addguests();
        
                PrintCompanies(MyLobby);
                PrintWaiters(MyLobby);
                Printtables(MyLobby);
                Console.WriteLine("-----------------------------------");
                PrintChefs(MyLobby);
                Console.WriteLine("-----------------------------------");
                Console.ReadKey();
                Console.Clear();
                MyLobby.work();
            }
           

            static void Printtables(Lobby lobby)
            {

                foreach (Table table in lobby.TableList)
                {
                    Console.WriteLine("Tablenumber: " + table.TableNumber + " seats " + table.Seats + " Available? " + table.IsAvailable);
                        if (table.IsAvailable == false)
                        {
                         Console.WriteLine("Company: " );
                        }
                        foreach (Company company in table.BookedSeats)
                        {
                        foreach (Guest guest in company.Guests)
                        {
                            Console.WriteLine(guest.Name);
                        }
                        }
                        
                    Console.WriteLine();
                }

            } //Klar

            static void PrintWaiters(Lobby lobby)
            {

                foreach (Waiter waiter in lobby.WaiterList)
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

            static void PrintChefs(Lobby lobby)
            {
                int i = 1;

                foreach (Chef chef in lobby.ChefList)
                {
                    Console.WriteLine(chef.Name);
                    i++;

                }

            }

            static void PrintCompanies(Lobby lobby)
            {
                int i = 1;

                foreach (Company company in lobby.CompanyWaitingList)
                {
                  
                    Console.WriteLine("Company: " + i);
                    
                    i++;
                    for (int j = 0; j < company.Guests.Count; j++)

                        Console.WriteLine(company.Guests[j].Name);
                    Console.WriteLine("-----------------------------------");
                }
                

            } //Klar

            static void PrintKitchen()
            {

            }




        }
    }
}