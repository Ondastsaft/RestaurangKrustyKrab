namespace RestaurantKrustyKrab.Restaurant
{
    internal class Dish
    {
        internal string NameOfDish { get; set; }
        internal int Price { get; set; }
        internal int Quality { get; set; }
        internal int DestinationTable { get; set; }
        internal string NameOfGuest { get; set; }

        public Dish(string nameofdish, int price, int quality, int destinationTable, string nameOfGuest)
        {
            NameOfDish = nameofdish;
            Price = price;
            Quality = quality;
            DestinationTable = destinationTable;
            NameOfGuest = nameOfGuest;
        }

    }
}
