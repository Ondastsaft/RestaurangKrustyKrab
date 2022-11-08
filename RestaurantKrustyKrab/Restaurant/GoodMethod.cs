using RestaurantKrustyKrab.People;
using RestaurantKrustyKrab.Restaurant.Dishes.Fish;
using RestaurantKrustyKrab.Restaurant.Dishes.Meat;
using RestaurantKrustyKrab.Restaurant.Dishes.Vegetarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class GoodMethod
    {

        internal void AddOrderTo_Table_Guest_Waiter(int menuorder, Waiter waiter, Guest guest, List<Table> TableList)
        {
            Dish dish = new Dish(waiter.ServingTable, guest.Name);


            switch (menuorder)
            {
                case 1:

                    {
                        dish = new Cod(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                    }
                    break;
                case 2:
                    {
                        dish = new SalmonPie(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                        break;
                    }
                case 3:
                    {
                        dish = new Sushi(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                    }
                    
                    break;

                case 4:
                    {
                        dish = new Curry(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                    }
                    break;

                case 5:
                    {
                        dish = new Ribs(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                    }
                    break;

                case 6:
                    {
                        dish = new Steak(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                    }
                    break;

                case 7:
                    {
                        dish = new Falafel(waiter.ServingTable, guest.Name);
                        AddOrderToAll(dish);
                    }
                    break;

                case 8:
                    dish = new Pasta(waiter.ServingTable, guest.Name);
                    AddOrderToAll(dish);
                    break;

                case 9:
                    dish = new Salad(waiter.ServingTable, guest.Name);
                    AddOrderToAll(dish);
                    break;
            }
            void AddOrderToAll(Dish dish)
            {
                waiter.Orders.Add(dish);
                TableList[(waiter.ServingTable - 1)].Orders.Add(guest.Name, dish);
                guest.Order.Add(dish);
            }



        }
    }
}
