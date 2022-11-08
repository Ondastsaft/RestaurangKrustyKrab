namespace RestaurantKrustyKrab.Restaurant
{
    internal class Dish
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }
        public int DestinationTable { get; set; }

        public Dish(string name, int price, int quality, int destinationTable)
        {
            Name = name;
            Price = price;
            Quality = quality;
            DestinationTable = destinationTable;
        }

    }
}
