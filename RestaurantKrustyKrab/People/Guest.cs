﻿using RestaurantKrustyKrab.Restaurant;
namespace RestaurantKrustyKrab.People
{
    internal class Guest : Person
        {
        static internal Random random = new Random();
        internal int Prefered_dish { get; set; }
        internal int Money { get; set; }
         
        public Guest(string name, int money , int PositionX, int PositionY) : base(name, PositionX, PositionY)
        {
            Name = name;
            Money = money;

            Prefered_dish = random.Next(1, 10);
        }
    }
}
