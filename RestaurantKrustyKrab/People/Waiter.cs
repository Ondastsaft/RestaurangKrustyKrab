namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        private bool Busy { get; set; }
        private int ServiceLevel { get; set; }
        public Waiter(string name, int serviceLevel, bool busy, int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            ServiceLevel = serviceLevel;
            busy = Busy;
        }

        internal void work()
        {
            void bemöta_gäst()
            {

            }

            void visa_bord()
            {

            }

            void ge_meny()
            {

            }

            void ta_Beställning()
            {

            }

            void hämta_mat()
            {

            }
            void servera_mat()
            {

            }
            void ta_Emot_Pengar()
            {

            }

            void duka_undan()
            {

            }
        }
    }
}
