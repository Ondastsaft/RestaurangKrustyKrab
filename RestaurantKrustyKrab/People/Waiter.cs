namespace RestaurantKrustyKrab.People
{
    internal class Waiter : Person
    {
        private bool busy { get; set; }
        private int servicenivå { get; set; }
        public Waiter(string Namn, int Servicenivå, bool Busy) : base(Namn)
        {
            namn = Namn;
            servicenivå = Servicenivå;
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
