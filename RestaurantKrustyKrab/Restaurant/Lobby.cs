using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Xml.Linq;

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
        internal  List<Chef> ChefList { get; set; }

    internal Kitchen Kitchen { get; set; }
        internal DishStation DishStation { get; set; }
        internal Reception Reception { get; set; }
        internal WC WC { get; set; }
        public int Time { get; set; }


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
            this.Time = 0;
            this.CompanyWaitingList = new Queue<Company>();
            this.WaiterList = new List<Waiter>();
            this.ChefList = new List<Chef>();
        }
        public void LobbyRun()
        {

            GenerateTable(TableList);
            GenerateWaiter();
            GenerateChefs();
           
         
        }
   
        public void PrintWaiters()
        {
            foreach (Waiter waiter in WaiterList)
            {
                Console.SetCursorPosition(waiter.PositionX, waiter.PositionY);
                Console.Write(waiter.Name);
            }
        }
        public void Addguests()

        {
            CompanyWaitingList.Enqueue(GenerateCompany());

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
                tableList.Add(new Table(4, 0, 40, top, true, tablenumber));
                tablenumber++; top = top + 30;
            }
            return tableList;

        }
        public Company GenerateCompany()
        {
            Company company = new Company(this.CompanyWaitingList.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
            return company;
        }
        public void GenerateWaiter()
        {
            for (int i = 0; i < 3; i++)
            {
                string name = "Waiter " + (i + 1);
                this.WaiterList.Add(new Waiter(name, 0, false, 110, (3 + i + 1)));
            }

        }

        internal void GenerateChefs()

        {
            for (int i = 1; i < 4; i++)
                this.ChefList.Add(new Chef("Chef: " + i, 0, 0,0));
        }
        internal void work()
        {
            foreach (Waiter waiter in WaiterList)
            {

                if (waiter.Busy == false)
                {

                    if (CompanyWaitingList.Count > 0)
                    {
                        waiter.Busy = true;
                        greet_guest(waiter);
                        lead_to_table(waiter);

                    }
                }
                
            }


            void greet_guest(Waiter waiter)
            {
                waiter.CompanyProperty = CompanyWaitingList.Dequeue();

            }

            void lead_to_table(Waiter waiter)
            {
                foreach (Table table in TableList)
                {
                    if (table.Seats >= waiter.CompanyProperty.Guests.Count)
                    {
                        table.Company = waiter.CompanyProperty;
                        table.IsAvailable = false;
                        break;
                    }

                }
            }
        }

       
        void ge_meny()
                {

                }

                void ta_Beställning()
                {

                }

                void hämta_mat()
                {

                }
                void servera_mat()
                {

                }
                void ta_Emot_Pengar()
                {

                }

                void duka_undan()
                {

                }
            }
        }
    