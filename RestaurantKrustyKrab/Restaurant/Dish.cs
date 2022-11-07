namespace RestaurantKrustyKrab.Restaurant
{
    internal class Dish
    {
        internal string Name { get; set; }
        internal int Price { get; set; }
        internal int Quality { get; set; }
        internal int DestinationTable { get; set; }
        internal string Guest { get; set; }


        public Dish(int destinationTable, string guest)
        {
            Name = "";
            Quality = 0;
            DestinationTable = destinationTable;
            Guest = guest;

        }

    }
}
