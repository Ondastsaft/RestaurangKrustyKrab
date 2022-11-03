namespace RestaurantKrustyKrab.People
{
    public abstract class Person
    {
        public string Name { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }
        public Person(string name, int positionX, int positionY)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}

