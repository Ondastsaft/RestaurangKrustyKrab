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
            MyLobby.LobbyRun();
            while (true)
            {

                MyLobby.LoopQueue();
                
                PrintCompanies(MyLobby);
                Printtables(MyLobby);
                Console.WriteLine("-----------------------------------");
                PrintWaiters(MyLobby);
                Console.WriteLine("-----------------------------------");
                PrintChefs(MyLobby);
                Console.WriteLine("-----------------------------------");
                Console.ReadKey();
                Console.Clear();
            }
           

            static void Printtables(Lobby lobby)
            {
                

                foreach (Table table in lobby.TableList)
                {
                    Console.WriteLine("Tablenumber: " + table.TableNumber + " seats " + table.Seats + " Available? " + table.IsAvailable);
                    
                    

                }

            }
            static void PrintWaiters(Lobby lobby)
            {
                int i = 1;

                foreach (Waiter waiter in lobby.WaiterList)
                {
                    Console.WriteLine(waiter.Name);
                    i++;

                }

            }
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
                

            }





        }
    }
}