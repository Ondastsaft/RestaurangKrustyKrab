using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Collections;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    {
        internal string[,] MyDrawing { get; set; }
        internal string Name { get; set; }
        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }

        internal Dictionary<string, RestaurantArea> MyRestaurantAreas { get; set; }

        internal int CounterRestaurant { get; set; }

        public int Time { get; set; }


        public Lobby()
        {
            MyRestaurantAreas = new Dictionary<string, RestaurantArea>();
            MyRestaurantAreas.Add("Kitchen", new Kitchen("Kitchen", 3, 155));
            MyRestaurantAreas = GenerateTables(MyRestaurantAreas);
            MyRestaurantAreas.Add("Reception", new Reception("Reception", 3, 31));
            MyRestaurantAreas.Add("WC", new WC("WC", 25, 188));
            MyRestaurantAreas.Add("WaiterWaitingArea", new WaiterWaitingArea("Waiters",3, 105));
            MyRestaurantAreas.Add("DishStation", new DishStation("Washing Bears", 3, 125));

            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.FromTop = 2;
            this.FromLeft = 2;
            this.Time = 0;
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.FromTop, this.FromLeft, this.MyDrawing);
            Draw();
            PrintAllAreas();
            
            //while (true)
            //{
            //    LoopRestaurant();
            Console.ReadKey();
            //}
        }
        public void LoopRestaurant()
        {

        }
        public void PrintAllAreas()
        {
            foreach (var restaurantArea in MyRestaurantAreas)
            {             
                PrintRestaurantArea(restaurantArea.Value as RestaurantArea);
            }
        }

        private void work(List<Waiter> waiterList)
        {
            foreach (Waiter waiter in waiterList)
            {
                while (waiter.Busy == false)
                {
                    waiter.Busy = bemöta_gäst(waiter);





                    //void ge_meny()
                    //{

                    //}

                    //void ta_Beställning()
                    //{

                    //}

                    //void hämta_mat()
                    //{

                    //}
                    //void servera_mat()
                    //{

                    //}
                    //void ta_Emot_Pengar()
                    //{

                    //}

                    //void duka_undan()
                    //{

                    //}
                    waiter.FromTop = 110;
                    waiter.FromLeft = 3;
                    //WaiterList.Add(waiter);
                    waiter.Busy = true;
                    Console.Write(waiter.Name);
                }
            }
        }
        private void PrintRestaurantArea(RestaurantArea restaurantArea)
        {
            PrintList(restaurantArea.GuestsAtArea);
            PrintList(restaurantArea.CompaniesAtArea);
            PrintList(restaurantArea.WaitersAtArea);
            PrintList(restaurantArea.ChefsAtArea);
        }
        private void EraseRestaurantArea(RestaurantArea restaurantArea)
        {
            EraseList(restaurantArea.GuestsAtArea);
            EraseList(restaurantArea.CompaniesAtArea);
            EraseList(restaurantArea.WaitersAtArea);
            EraseList(restaurantArea.ChefsAtArea);
        }
        private bool bemöta_gäst(Waiter waiter)
        {
            bool busy = false;


            return busy;
        }


        public void ErasePosition(Person person)
        {

            Console.SetCursorPosition(person.FromTop, person.FromLeft);
            Console.WriteLine("              ");
            Console.SetCursorPosition(person.FromTop, person.FromLeft);

        }
        public void EraseList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).FromLeft, ((person as Person).FromTop + row));
                Console.Write(new string(' ', (person as Person).Name.Length));
                row++;
            }
        }

        public void PrintList<T>(List<T> personList)
        {
            int row = 0;
            foreach (T person in personList)
            {
                Console.SetCursorPosition((person as Person).FromTop, ((person as Person).FromLeft + row));
                Console.Write((person as Person).Name);
                row++;
            }
        }



        public static void TimeCounter()
        {

        }

        public Dictionary<string, RestaurantArea> GenerateTables(Dictionary<string, RestaurantArea> restaurantAreas)
        {
            int fromTop = 24;
            int fromLeft = 12;

            for (int i = 0; i < 10; i++)
            {
                
                int seats = i < 4 ? 2 : 4;
                int quality = i == 4 ? 1 : 2;
                quality = i ==  9 ? 1 : 2;
           
                restaurantAreas.Add("Table " + i+1, new Table($"Table {i+1} ", fromTop, fromLeft, seats, quality, i+1));
                fromLeft = i == 4? 12 : fromLeft + 30;

                fromTop =  i== 4? fromTop+16: fromTop;
                
            }
            return restaurantAreas;
        }


        public void Draw()
        {

            foreach (var restaurantArea in MyRestaurantAreas)
            {
                Window.OurDraw(restaurantArea.Value as RestaurantArea);
            }
        }

    }
}
