namespace RestaurantKrustyKrab.Restaurant
{
    internal class Dish
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }
        public string DestinationTable { get; set; }

        public Dish(string name, int price, int quality, string destinationTable)
        {
            Name = name;
            Price = price;
            Quality = quality;
            DestinationTable = destinationTable;
        }

    }
}
