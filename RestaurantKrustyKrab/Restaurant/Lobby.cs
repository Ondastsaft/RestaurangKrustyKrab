using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Lobby
    {
        internal string[,] MyDrawing { get; set; }
        internal string Name { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }

        public List<Table> TableList { get; set; }
        internal List<Waiter> WaiterList { get; set; }
        internal Queue<Company> CompanyWaitingList { get; set; }
        internal int CounterRestaurant { get; set; }

        internal Kitchen Kitchen { get; set; }
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        //internal WC WC { get; set; }


        public Lobby()
        {
            this.MyDrawing = new string[70, 305];
            this.Name = "Krusty Krab";
            this.PositionX = 4;
            this.PositionY = 2;
            this.TableList = new List<Table>();
            this.Kitchen = new Kitchen(false, 3, 180);
            this.DishStation = new DishStation(3, 128);
            this.Reception = new Reception(55, 31);
            //this.WC = new WC(25, 188);
            this.CompanyWaitingList = new Queue<Company>();
        }
        public void LobbyRun()
        {
            Window.OurDraw(this.Name, this.PositionX, this.PositionY, this.MyDrawing);
            GenerateTables(TableList);
            Draw();
            while (true)
            {
               
                Console.ReadKey();
            }
        }
 
        public List<Table> GenerateTables(List<Table> tableList)
        {
            int top = 12;
            int tablenumber = 1;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 24, top, true, tablenumber, 8, 25));

                tablenumber++; top = top + 40;
            }

            top = 12;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(4, 0, 40, top, true, tablenumber, 4 ,25));
                tablenumber++; top = top + 40;
            }
            return tableList;

        }

        public void Draw()  
        {
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.Frame);
            }
            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.Frame);
            Window.OurDraw("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.Frame);
            Window.OurDraw("Reception", Reception.PositionY, Reception.PositionX, Reception.Frame);
        }

    }
}
