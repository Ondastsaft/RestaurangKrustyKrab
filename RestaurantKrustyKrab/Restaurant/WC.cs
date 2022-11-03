namespace RestaurantKrustyKrab.Restaurant
{
    internal class WC
    {
        internal string[,] DrawWC { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }
        public WC(int positionX, int positionY)
        {
            this.DrawWC = new string[13, 12];
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
