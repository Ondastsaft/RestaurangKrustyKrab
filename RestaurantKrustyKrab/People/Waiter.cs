using RestaurantKrustyKrab.Restaurant;
using RestaurantKrustyKrab.Restaurant.Dishes.Fish;
using RestaurantKrustyKrab.Restaurant.Dishes.Meat;
using RestaurantKrustyKrab.Restaurant.Dishes.Vegetarian;
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
        internal string Activity { get; set;}
        internal string Location { get; set; }




        public void Work(Queue<Company> CompanyWaitingList, bool Full_Restaurant, 
                         List<Table> TableList, Kitchen Kitchen, int GlobalTimer, List<string> PaidOrders, DishStation Dishstation)
        {

            Busy = false;

            if (Busy == false && Activity == "Waiting" && Location == "Reception")
                Waiter_start_cleaning_And_Take_payment(TableList, GlobalTimer, PaidOrders, Dishstation);

            GreetGuest(CompanyWaitingList, Full_Restaurant);
            if (Busy == false && Activity == "Greeting guests")
                Lead_To_table(TableList);
            if (Busy == false && Activity == "Leading to table" )
                Take_Order();
            if (Busy == false && Activity == "Taking order")
                Give_Kitchen_Order(Kitchen);
            if (Busy == false && Activity == "Giving kitchen order" || Busy == false && Activity == "Waiting")
                Take_order_from_kitchen(Kitchen);
            if (Busy == false && Activity == "Taking order from kitchen")
                Give_food_to_table(TableList, GlobalTimer);
            if (Busy == false && Activity == "Giving food to table")
                return_from_serving();
            


        }
        void GreetGuest(Queue<Company> CompanyWaitingList, bool Full_Restaurant)
        {
            if (Busy == false && Full_Restaurant == false && CompanyWaitingList.Count > 0 && Activity == "Waiting")
            {
                
                    Activity = "Greeting guests";
                    Busy = true;
                    CompanyProperty = CompanyWaitingList.Dequeue();
                    Location = "Reception";
            }
            
        }

        void Lead_To_table(List<Table> TableList)
        {
            foreach (Table table in TableList)
            {
                if (Busy == false && Activity == "Greeting guests")
                {

                    if (table.Seats >= CompanyProperty.Guests.Count && table.IsAvailable == true && Activity == "Greeting guests")
                    {
                        Activity = "Leading to table";
                        Busy = true;
                        ServingTable = table.TableNumber;
                        foreach (Guest guest in CompanyProperty.Guests)
                        {
                            guest.Satisfaction = guest.Satisfaction + table.Quality + ServiceLevel;
                            table.BookedSeats.Guests.Add(guest);
                        }
                        table.IsAvailable = false;
                        table.WaitingForFood = true;
                        Location = "Tables";
                    }
                }
            }
        }
        
        void Take_Order()

        {
                if (Busy == false && Activity == "Leading to table")
                {
                    foreach (Guest guest in CompanyProperty.Guests)
                {
                    Dish dish = new Dish(ServingTable, guest.Name);

                    switch (guest.Prefered_dish)
                    {
                        case 1:

                            {
                                dish = new Cod(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                            }
                            break;
                        case 2:
                            {
                                dish = new SalmonPie(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                                break;
                            }
                        case 3:
                            {
                                dish = new Sushi(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                            }

                            break;

                        case 4:
                            {
                                dish = new Curry(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                            }
                            break;

                        case 5:
                            {
                                dish = new Ribs(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                            }
                            break;

                        case 6:
                            {
                                dish = new Steak(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                            }
                            break;

                        case 7:
                            {
                                dish = new Falafel(ServingTable, guest.Name);
                                AddOrderToAll(dish);
                            }
                            break;

                        case 8:
                            dish = new Pasta(ServingTable, guest.Name);
                            AddOrderToAll(dish);
                            break;

                        case 9:
                            dish = new Salad(ServingTable, guest.Name);
                            AddOrderToAll(dish);
                            break;
                    }

                    void AddOrderToAll(Dish dish)
                    {
                        Orders.Add(dish);
                        guest.Order.Add(dish);
                    }
                
                    }
                }
            Busy = true;
            Activity = "Taking order";

           
            }

        void Give_Kitchen_Order(Kitchen Kitchen)

        {
                if (Activity == "Taking order")
                {
                    
                    foreach (Dish dish in Orders)
                    {
                        Kitchen.Orders.Enqueue(dish); //kitchen.order is a list of dishes
                    }
                    Orders.Clear();
                    CompanyProperty.Guests.Clear();
                    Busy = true;
                    ServingTable = -1;
                Activity = "Giving kitchen order";
                Location = "Kitchen";

                }
            }


        void Take_order_from_kitchen(Kitchen Kitchen)
        {
            if (Kitchen.ReadyOrders.Count > 0 && Busy == false)
            {
                Busy = true;
                Activity = "Taking order from kitchen";
                Location = "Kitchen";
                Orders.Clear();
                Orders.Add(Kitchen.ReadyOrders.Dequeue());
                foreach (Dish dish in Kitchen.ReadyOrders.ToList())
                {
                    if (dish.DestinationTable == Orders[0].DestinationTable)
                        Kitchen.ReadyOrders.Dequeue();
                }
                ServingTable = Orders[0].DestinationTable;

            }
            else
            {
                Busy = true;
                Activity = "Waiting";
                Location = "Reception";
             
            }
                

        }

        void Give_food_to_table(List<Table> TableList, int GlobalTimer)

        {
            if (Busy == false && Activity == "Taking order from kitchen" == true && Orders.Count > 0)
            {
                Activity = "Giving food to table";
                Location = "Tables";
                Busy = true;

                foreach (Table table in TableList)
                    foreach (Dish dish in Orders)
                    {
                        if (dish.DestinationTable == table.TableNumber)
                        {
                            table.WaitingForFood = false;
                            table.RecievedOrder = true;
                            table.EatTimer = GlobalTimer;
                            table.TimeEnd = table.EatTimer + 20;
                            foreach (Guest guest in table.BookedSeats.Guests)
                            {
                                {
                                    guest.Recieved_Order = true;
                                    guest.Satisfaction = guest.Satisfaction + Orders[0].Quality;
                                    guest.Satisfaction = guest.Satisfaction + ServiceLevel;

                                }
                            }
                        }
                        break;
                    }
                    
            }
                
        }
            



        void return_from_serving()
        {
            if (Busy == false && Location == "Tables" && Activity == "Giving food to table")
            {
                Reset();
            }
        }


        void Waiter_start_cleaning_And_Take_payment(List<Table> TableList, int GlobalTimer, List<string> PaidOrders, DishStation Dishstation)  //Also keeps the paidOrders List to max
        {
            if (Busy == false && Activity == "Waiting" && Location == "Reception")
            {

                foreach (Table table in TableList)
                {
                    if (table.Finished_Eating == true)
                    {
                        Busy = true;
                        tableReset(table, this, PaidOrders, Dishstation);
                        table.WipeTimer = GlobalTimer;
                        table.WipeEnd = table.WipeTimer + 3;
                        table.Clean = false;
                        table.WipedBy = Name;
                        Location = "Tables";
                        break;
                    }
                    else
                        Busy = false;
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
            Orders.Clear();
            CompanyProperty.Guests.Clear();
            Busy = true;
            Location = "Reception";
            Activity = "Waiting";
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
            Activity = "Waiting";
            Location = "Reception";

        }

         
    }
}
