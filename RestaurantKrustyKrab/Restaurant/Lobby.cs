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




        public Lobby()
        {
            this.MyDrawing = new string[50, 200];
            this.Name = "Krusty Krab";
            this.PositionX = 4;
            this.PositionY = 2;
            this.TableList = new List<Table>();
            this.Kitchen = new Kitchen(false, 3, 157);
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.PositionX, this.PositionY, this.MyDrawing);
            GenerateTable(TableList);
            DrawTables();
            DrawKitchen();
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
    }
}
