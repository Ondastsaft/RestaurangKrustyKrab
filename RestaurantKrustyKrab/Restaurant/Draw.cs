using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.People;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Draw
    {

        public void draw(List<Table> TableList, Kitchen Kitchen, Reception Reception, DishStation DishStation)
        {
            foreach (Table table in TableList)
            {
                Window.OurDraw("Bord " + table.TableNumber, table.PositionY, table.PositionX, table.Frame);
            }
            
            Window.OurDraw("Kitchen", Kitchen.PositionY, Kitchen.PositionX, Kitchen.Frame);
            Window.OurDraw("Dish Station", DishStation.PositionY, DishStation.PositionX, DishStation.Frame);
            Window.OurDraw("Reception", Reception.PositionY, Reception.PositionX, Reception.Frame);
        }


        public Draw()
        {
           

        }



    }
}
