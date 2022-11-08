using RestaurantKrustyKrab.People;
using System.Collections;
using System.Xml.Linq;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table : RestaurantArea
    {

        internal int Seats { get; set; }
        internal int Quality { get; set; }
        internal Company Company { get; set; }

        internal bool IsAvailable = true;
        internal int TableNumber { get; set; }
        internal Hashtable Dishes { get; set; }


        public Table(string name, int fromTop, int fromLeft, int seats, int quality, int tableNumber) : base(name, fromTop, fromLeft)
        {
            Frame = new string[4, 20];
            Seats = seats;
            Quality = quality;
            FromTop = fromTop;
            FromLeft = fromLeft;
            TableNumber = tableNumber;

            Dishes = new Hashtable();
            Dishes.Add(1,"Wagyu beef");
            Dishes.Add(2,"Pasta Bolgonese");
            Dishes.Add(3,"Hot Hund");
            Dishes.Add(4,"Fisk o' Chips");
            Dishes.Add(5,"Fisk grataine");
            Dishes.Add(6,"Fisk sticks");
            Dishes.Add(7,"Halloumi salad");
            Dishes.Add(8,"Falafel");
            Dishes.Add(9,"Wok");
        }


    }
}
