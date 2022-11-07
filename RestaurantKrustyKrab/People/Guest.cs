using RestaurantKrustyKrab.Restaurant;
namespace RestaurantKrustyKrab.People
{
    internal class Guest : Person
    {
        internal Dish Prefered_Dish { get; set; }
        public Guest(string name, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            Prefered_Dish = new Dish();

        }
    }
}
