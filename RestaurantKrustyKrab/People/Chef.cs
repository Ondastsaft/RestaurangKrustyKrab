﻿namespace RestaurantKrustyKrab.People
{
    internal class Chef : Person
    {
        internal int Competence { get; set; }

        public Chef(string name, int Competence) : base(name)
        {
            Name = name;
            Competence = Competence;
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
