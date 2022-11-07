using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    {
        internal string[,] MyDrawing { get; set; }
        internal string Name { get; set; }
        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }

        internal List<RestaurantArea> MyRestaurantAreas { get; set; }

        internal int CounterRestaurant { get; set; }

        public int Time { get; set; }


        public Lobby()
        {
            this.MyRestaurantAreas = new List<RestaurantArea>();
            MyRestaurantAreas.Add(new Kitchen(3, 157));
            MyRestaurantAreas = GenerateTables(MyRestaurantAreas);
            MyRestaurantAreas.Add(new Reception(3, 31));
            MyRestaurantAreas.Add(new WC(25, 188));
            MyRestaurantAreas.Add(new WaiterWaitingArea(110, 3));
            MyRestaurantAreas.Add(new DishStation(3, 128));

            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.FromTop = 4;
            this.FromLeft = 2;
            this.Time = 0;
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.FromTop, this.FromLeft, this.MyDrawing);
            //PrintAllAreas();
            Draw();
            //while (true)
            //{
            //    LoopRestaurant();
            //    Console.ReadKey();
            //}
        }
        public void LoopRestaurant()
        {

        }
        public void PrintAllAreas()
        {
            foreach (RestaurantArea area in MyRestaurantAreas)
            {
                PrintRestaurantArea(area);
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

    public List<RestaurantArea> GenerateTables(List<RestaurantArea> restaurantAreaList)
    {
        int top = 12;
        int tablenumber = 1;
        for (int i = 0; i < 5; i++)
        {
            restaurantAreaList.Add(new Table(2, 0, 24, top, tablenumber));
            tablenumber++; top = top + 30;
        }
        top = 12;
        for (int i = 0; i < 5; i++)
        {
            restaurantAreaList.Add(new Table(2, 0, 40, top, tablenumber));
            tablenumber++; top = top + 30;
        }
        return restaurantAreaList;

    }

    public void Draw()
    {
        foreach (RestaurantArea restaurantArea in MyRestaurantAreas)
        {
            Window.OurDraw(restaurantArea.Name, restaurantArea.FromLeft, restaurantArea.FromTop, restaurantArea.Frame);
        }
    }
   
}
}
