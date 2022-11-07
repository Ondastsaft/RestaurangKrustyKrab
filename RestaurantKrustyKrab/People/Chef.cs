namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal int Competence { get; set; }

        public Chef(string name, int competence, int fromTop, int fromLeft) : base(name, fromTop, fromLeft)
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
