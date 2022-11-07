namespace RestaurantKrustyKrab.People
{
    public abstract class Person
    {
        public string Name { get; set; }
        internal int FromTop { get; set; }
        internal int FromLeft { get; set; }
        public Person(string name, int fromTop, int fromLeft)
        {
            Name = name;
            FromTop = fromTop;
            FromLeft = fromLeft;
        }
    }
}

