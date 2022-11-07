using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantKrustyKrab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lobby MyLobby = new Lobby();

            while (true)
                
            {
                MyLobby.ChefTimer();
                MyLobby.Check_if_food_is_ready();
                MyLobby.Check_if_food_is_eaten();
                MyLobby.Check_if_table_has_been_wiped();
                MyLobby.LobbyRun();
            }
        


        }
    }
}