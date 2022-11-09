using RestaurantKrustyKrab.People;
using System.Collections;

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
        internal bool HasOrdered { get; set; }
        internal Waiter WaiterAtTable { get; set; }


        public Table(string name, int fromTop, int fromLeft, int seats, int quality, int tableNumber) : base(name, fromTop, fromLeft)
        {
            Frame = new string[5, 25];
            Seats = seats;
            Quality = quality;
            FromTop = fromTop;
            FromLeft = fromLeft;
            TableNumber = tableNumber;
            HasOrdered = false;
            WaiterAtTable = new Waiter("", 0, false, 0, 0);

            Dishes = new Hashtable();
            Dishes.Add(1, "Wagyu beef");
            Dishes.Add(2, "Pasta Bolgonese");
            Dishes.Add(3, "Hot Hund");
            Dishes.Add(4, "Fisk o' Chips");
            Dishes.Add(5, "Fisk grataine");
            Dishes.Add(6, "Fisk sticks");
            Dishes.Add(7, "Halloumi salad");
            Dishes.Add(8, "Falafel");
            Dishes.Add(9, "Wok");
        }

        public override void PrintMe()
        {
            int row = 0;

            Console.SetCursorPosition(FromLeft + 1, FromTop + 8 + row);
            Console.Write(WaiterAtTable.Name);
            row++;
            foreach (var kvp in WaiterAtTable.Name_MenuIndex)
            {
                Console.SetCursorPosition(FromLeft + 8, FromTop + 8 + row);
                Console.Write(Dishes[kvp.Value]);
                row++;
            }

            row = 0;
            foreach (Guest guest in CompanyAtArea.Guests)
            {
                Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + row);
                Console.Write(guest.Name + " " + guest.Activity + " " + guest.OrderedFood);
                row++;
            }
        }

        public override void EraseMe()
        {
            Console.SetCursorPosition(FromLeft + 1, FromTop + 1);
            Console.Write(new string(' ', Frame.GetLength(1)));
            for (int i = 0; i < Frame.GetLength(0) - 1; i++)
            {
                Console.SetCursorPosition(FromLeft + 1, FromTop + 1 + i);
                Console.Write(new string(' ', Frame.GetLength(1) - 2));
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }


    }
}
