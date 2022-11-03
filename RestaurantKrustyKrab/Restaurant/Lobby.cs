using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    {
        public string[,] MyDrawing { get; set; }
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public List<Table> TableList { get; set; }
        private List<Waiter> WaiterList { get; set; }
        private List<Company> CompanyWaitingList { get; set; }
        private int CounterRestaurant { get; set; }

        internal Kitchen Kitchen { get; set; }
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        internal WC WC { get; set; }




        public Lobby()
        {
            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.PositionX = 4;
            this.PositionY = 2;
            this.TableList = new List<Table>();
            this.Kitchen = new Kitchen(false, 3, 157);
            this.DishStation = new DishStation(3, 128);
            this.Reception = new Reception(3, 31);
            this.WC = new WC(25, 188);
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.PositionX, this.PositionY, this.MyDrawing);
            GenerateTable(TableList);
            DrawTables();
            DrawKitchen();
            DrawDishStation();
            DrawReception();
            DrawWC();
        }
        //public static void PrintMe()
        //{

        //}
        public static void Count()
        {

        }
        public static void DrawArray()
        {

        }


        public List<Table> GenerateTable(List<Table> tableList)
        {
            int top = 12;
            int tablenumber = 1;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 24, top, true, tablenumber));
                tablenumber++; top = top + 30;
            }
            top = 12;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 40, top, true, tablenumber));
                tablenumber++; top = top + 30;
            }
            return tableList;

        }

        public void DrawTables()
        {
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.DrawTable);
            }
        }
        public void DrawKitchen()
        {
            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.DrawKitchen);
        }
        public void DrawDishStation()
        {
            Window.OurDraw("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.DrawDishes);
        }
        public void DrawReception()
        {
            Window.OurDraw("Reception", Reception.PositionY, Reception.PositionX, Reception.DrawReception);
        }
        public void DrawWC()
        {
            Window.OurDraw("WC", WC.PositionY, WC.PositionX, WC.DrawWC);
        }
    }
}
