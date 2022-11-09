using RestaurantKrustyKrab.Restaurant;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        internal bool Busy { get; set; }
        internal int ServiceLevel { get; set; }
        internal Company CompanyProperty { get; set; }
        internal List<Dish> Orders { get; set; }
        internal int WipeTimer { get; set; }
        internal int ServingTable { get; set; }
        internal bool AT_Reception { get; set; }
        internal bool At_Kitchen { get; set; }
        internal bool Taking_order_at_table { get; set; }
        internal bool Giving_food_to_table { get; set; }
        internal bool Greeting_Guests { get; set; }
        internal bool Leading_to_table { get; set; }
        internal bool Taking_order_from_kitchen { get; set; }




        public void Work(Queue<Company> CompanyWaitingList, bool Full_Restaurant, 
                         List<Table> TableList, Kitchen Kitchen, int GlobalTimer, List<string> PaidOrders, DishStation Dishstation)
        {

            Busy = false;
            GreetGuest(CompanyWaitingList, Full_Restaurant);
            Lead_To_table(TableList);
            Take_Order();
            Give_Kitchen_Order(Kitchen);
            Take_order_from_kitchen(Kitchen);
            Give_food_to_table(TableList, GlobalTimer);
            Waiter_start_cleaning_And_Take_payment(TableList, GlobalTimer, PaidOrders, Dishstation);
            return_from_serving();

        }
        void GreetGuest(Queue<Company> CompanyWaitingList, bool Full_Restaurant)
        {
            if (Busy == false && AT_Reception == true && Full_Restaurant == false && CompanyWaitingList.Count > 0 && Greeting_Guests != true)
            {
                
                {
                    Greeting_Guests = true;
                    Busy = true;
                    CompanyProperty = CompanyWaitingList.Dequeue();
                    AT_Reception = true;
                }
            }
            
        }

        void Lead_To_table(List<Table> TableList)
            {
            if (Busy == false && Greeting_Guests == true) 
                {
                    foreach (Table table in TableList)
                    {
                    if (table.Seats >= CompanyProperty.Guests.Count && table.IsAvailable == true && Greeting_Guests == true)
                        {
                            Greeting_Guests = false;
                            Busy = true;
                            AT_Reception = false;
                            Leading_to_table = true;
                            ServingTable = table.TableNumber;
                            foreach (Guest guest in CompanyProperty.Guests)
                            {
                                guest.Satisfaction = guest.Satisfaction + table.Quality + ServiceLevel;
                                table.BookedSeats.Guests.Add(guest);
                            }
                            table.IsAvailable = false;
                            table.WaitingForFood = true;
                            break;
                        }
                    }
                }
            }
        
        void Take_Order()

        {

            GoodMethod G = new GoodMethod();
         
                if (Busy == false && Leading_to_table == true )
                {
                    Leading_to_table = false;
                    Taking_order_at_table = true;
                    foreach (Guest guest in CompanyProperty.Guests)
                    {
                        G.AddOrderTo_Table_Guest_Waiter(guest.Prefered_dish, this, guest);
                    }

                }
           
            }

        void Give_Kitchen_Order(Kitchen Kitchen)

        {
                if (Busy == false && Taking_order_at_table == true )
                {
                    Taking_order_at_table = false;
                    
                    At_Kitchen = true;

                    foreach (Dish dish in Orders)
                    {
                        Kitchen.Orders.Enqueue(dish); //kitchen.order is a list of dishes
                    }
                    Orders.Clear();
                    CompanyProperty.Guests.Clear();
                    Busy = true;
                    ServingTable = -1;

                }
            }

        void Take_order_from_kitchen(Kitchen Kitchen)
        {
                if (Kitchen.ReadyOrders.Count > 0 && Busy == false && Kitchen.FoodIsReady == true)
                {
                    Taking_order_from_kitchen = true;
                    At_Kitchen = true;
                    Busy = true;
                    AT_Reception = false;
                    Orders.Add(Kitchen.ReadyOrders.Dequeue());
                    foreach (Dish dish in Kitchen.ReadyOrders.ToList())
                {
                    if (dish.DestinationTable == Orders[0].DestinationTable)
                        Kitchen.ReadyOrders.Dequeue();
                }
                        
                    ServingTable = Orders[0].DestinationTable;

                }
        }

        void Give_food_to_table(List<Table> TableList, int GlobalTimer)

        {
            if (Busy == false && Taking_order_from_kitchen == true)
            {
                Busy = true;

                foreach (Table table in TableList)
                {
                    if (Orders[0].DestinationTable == table.TableNumber)
                    {
                        ServingTable = Orders[0].DestinationTable;
                        At_Kitchen = false;
                        Giving_food_to_table = true;
                        table.WaitingForFood = false;
                        table.RecievedOrder = true;
                        table.EatTimer = GlobalTimer;
                        table.TimeEnd = table.EatTimer + 20;
                        foreach (Dish dish in Orders)
                        {
                            foreach (Guest guest in table.BookedSeats.Guests)
                            {
                                if (dish.Guest == guest.Name)
                                {
                                    guest.Recieved_Order = true;
                                    guest.Order.Clear();
                                    guest.Order.Add(dish);
                                    guest.Satisfaction = guest.Satisfaction + dish.Quality;
                                    guest.Satisfaction = guest.Satisfaction + ServiceLevel;

                                }
                            }
                        }
                        break;
                    }
                }
            }

                
                }
            
        void return_from_serving()
        {
            if (Busy == false && Giving_food_to_table == true || At_Kitchen == true)
            {
                Reset();
            }
        }


        void Waiter_start_cleaning_And_Take_payment(List<Table> TableList, int GlobalTimer, List<string> PaidOrders, DishStation Dishstation)  //Also keeps the paidOrders List to max
        {
            if (Busy == false)
            {
                foreach (Table table in TableList)
                {
                    if (table.Finished_Eating)
                    {
                        Busy = true;
                        tableReset(table, this, PaidOrders, Dishstation);
                        table.WipeTimer = GlobalTimer;
                        table.WipeEnd = table.WipeTimer + 3;
                        table.Clean = false;
                        table.WipedBy = Name;
                        break;
                    }
                }
            }




            void tableReset(Table table, Waiter waiter, List<string> PaidOrders, DishStation Dishstation)
            {
                table.WaitingForFood = false;
                table.IsAvailable = true;
                table.RecievedOrder = false;
                table.Finished_Eating = false;
                table.EatTimer = -21;

                foreach (Guest guest in table.BookedSeats.Guests)
                {

                    if (guest.Money >= guest.Order[0].Price)
                    {
                        PaidOrders.Add(guest.Name + " ordered " + guest.Order[0].Name + " for " + guest.Order[0].Price + " and paid for it, they rate this restaurant " + guest.Satisfaction + "/12");
                    }
                    else
                    {
                        PaidOrders.Add(guest.Name + " could not afford their " + guest.Order[0].Name + " was forced to help with the dishes, they rate this restaurant " + guest.Satisfaction + "/12");
                        Dishstation.Guests.Add(guest);
                        guest.Dishing_start = GlobalTimer;
                        guest.Dishing_end = GlobalTimer + 5;
                    }
                }

                waiter.CompanyProperty.Guests.Clear();
                table.Orders.Clear();
                table.BookedSeats.Guests.Clear();
            }
        }
        
        void Reset()
        {
            CompanyProperty.Guests.Clear();
            Orders.Clear();
            WipeTimer = 0;
            ServingTable = 0;
            AT_Reception = true;
            At_Kitchen = false;
            Taking_order_at_table = false;
            Giving_food_to_table = false;
            Busy = false;
    }


        
        public Waiter(string name, int serviceLevel, bool busy, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            Busy = busy;
            Orders = new List<Dish>();
            CompanyProperty = new Company(0);
            CompanyProperty.Guests.Clear();
            WipeTimer = -4;
            
            AT_Reception = true;
            Taking_order_at_table = false;
            At_Kitchen = false;

        }

         
    }
}
