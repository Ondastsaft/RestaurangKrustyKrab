using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Draw
    {

        public void draw(List<Table> TableList, Kitchen Kitchen, Reception Reception, DishStation DishStation, List<Waiter> WaiterList, Queue<Company> CompanyWaitingList)
        {
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.Frame);
            }
            
            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.Frame);
            Window.OurDraw("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.Frame);
            Window.OurDraw("Reception", Reception.PositionY, Reception.PositionX, Reception.Frame);

            Console.SetCursorPosition(Reception.PositionY + 30, (Reception.PositionX));  //Y flyttar i sidled, X flyttar på höjden
            int X = 1;
            foreach (Waiter waiter in WaiterList)
            {
                Console.WriteLine(waiter.Name); 
                Console.SetCursorPosition(Reception.PositionY + 30, Reception.PositionX + X);
                X++;
            }

            int Y = 1;
            Console.SetCursorPosition(Reception.PositionY + 2, Reception.PositionX + Y);
            Console.Write("Guests: ");

            foreach (Company company in CompanyWaitingList)
            {
                Y++;
                Console.SetCursorPosition(Reception.PositionY + 2, Reception.PositionX + Y);
                Console.WriteLine("Company" + company.Guests[0].Name + " + " + company.Guests.Count);
            }
                
           
            Console.ReadKey();
            Console.Clear();
                
                

            
               
        }


        public Draw()
        {
           

        }



    }
}
