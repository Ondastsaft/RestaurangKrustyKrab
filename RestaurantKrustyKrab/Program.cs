using RestaurantKrustyKrab.Restaurant;

namespace RestaurantKrustyKrab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Lobby MyLobby = new Lobby();
            MyLobby.LobbyRun();
            Console.ReadKey();
        }
    }
}