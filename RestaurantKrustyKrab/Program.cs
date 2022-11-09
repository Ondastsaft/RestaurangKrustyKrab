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
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            while (true)
                
            {
                MyLobby.LobbyRun();
            }
        


        }
    }
}