using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Collections;
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

            Generate();
        }


        internal void LobbyRun()
        {
            Addguests();
            PrintAll();
            Work();
        }

        internal void PrintAll()
        {
            PrintCompanies();
            PrintWaiters();
            PrintTables();
            PrintKitchen();
            PrintChefs();
            Console.ReadKey();
            Console.Clear();
        }

        void PrintKitchen() //Börja gärna här
        {

        }
        void PrintTables()
        {

            foreach (Table table in this.TableList)
            {
                Console.WriteLine("Tablenumber: " + table.TableNumber + " Seats " + table.Seats + " Available? " + table.IsAvailable+ " Waiting for food?   " + table.WaitingForFood);
                if (table.IsAvailable == false)
                {
                    Console.WriteLine("Company: ");
                }
                foreach (Company company in table.BookedSeats)
                {
                    foreach (Guest guest in company.Guests)
                    {
                        Console.WriteLine(guest.Name);
                    }
                }

                foreach (DictionaryEntry de in table.Orders)
                {
                    Console.WriteLine("Guest: " + de.Key + " Dish: " + de.Value);
                }

                Console.WriteLine();
            }

        } //Klar

        void PrintWaiters()
        {

            foreach (Waiter waiter in this.WaiterList)
            {
                Console.WriteLine(waiter.Name + " Busy? " + waiter.Busy);
                if (waiter.Busy == true)
                {
                    Console.WriteLine("Serving : ");

                    if (waiter.CompanyProperty.Guests.Count > 0)
                    {
                        foreach (Guest guest in waiter.CompanyProperty.Guests)
                            Console.WriteLine(guest.Name);
                    }
                    Console.WriteLine("-----------------------------------");
                }



            }

        } //Klar

        void PrintChefs()
        {
            foreach (Chef chef in this.ChefList)
            {
                Console.WriteLine(chef.Name);
            }

        }

        void PrintCompanies()
        {
            int i = 1;

            foreach (Company company in this.CompanyWaitingList)
            {

                Console.WriteLine("Company: " + i);

                i++;
                for (int j = 0; j < company.Guests.Count; j++)

                    Console.WriteLine(company.Guests[j].Name);
                Console.WriteLine("-----------------------------------");
            }


        } //Klar

        internal void Generate()
        {
            GenerateTable(TableList);
            GenerateWaiter();
            GenerateChefs();  
        }
   
        internal void Addguests()
        {
            CompanyWaitingList.Enqueue(GenerateCompany());
        }
          
        static List<Table> GenerateTable(List<Table> tableList)
        {
            int top = 12;
            int tablenumber = 1;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(2, 0, 24, top, true, tablenumber, false));
                tablenumber++; top = top + 30;
            }
            top = 12;
            for (int i = 0; i < 5; i++)
            {
                tableList.Add(new Table(4, 0, 40, top, true, tablenumber, false));
                tablenumber++; top = top + 30;
            }
            return tableList;

        }

        internal Company GenerateCompany()
        {
            Company company = new Company(this.CompanyWaitingList.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
            return company;
        }

        internal void GenerateWaiter()
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

        internal void Work()
        {
            foreach (Waiter waiter in WaiterList)
            {

                if (waiter.Busy == false)
                {

                    if (CompanyWaitingList.Count > 0)
                    {
                        waiter.Busy = true;
                        greet_guest(waiter);
                        Sequence2(waiter);

                    }
                }
                
            }


            void greet_guest(Waiter waiter)
            {
                waiter.CompanyProperty = CompanyWaitingList.Dequeue();

            }

            void Sequence2(Waiter waiter)
            {
                foreach (Table table in TableList)
                {
                    if (table.Seats >= waiter.CompanyProperty.Guests.Count  && table.IsAvailable == true)
                    {
                        table.BookedSeats.Add(waiter.CompanyProperty);
                        table.IsAvailable = false;
                        table.WaitingForFood = true;
                        Take_Order();
                        Give_Kitchen_Order();
                        break;
                    }
                    void Take_Order()
                    {
                        foreach (Guest guest in waiter.CompanyProperty.Guests)
                        {

                            waiter.Order.Add(new Dish("Placeholder ", 0, 0, table.TableNumber, guest.Name));
                            table.Orders.Add(guest.Name, "Placeholder");  //orders är en hashtable

                        }
                    }
                    void Give_Kitchen_Order()
                        {
                            foreach(Dish dish in waiter.Order)
                            {
                                this.Kitchen.Order.Add(dish); //kitchen.order is a list of dishes
                            }
                             
                        }
                        
                    }

                }
            }
            
        }

    }
        
    