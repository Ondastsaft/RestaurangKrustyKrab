namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal int Competence { get; set; }

        public Chef(string name, int competence, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            Competence = competence;
        }


        internal void work()
        {
            void taEmotBeställning()
            {

            }

            void lagaMat()
            {

            }
        }

    }
}
