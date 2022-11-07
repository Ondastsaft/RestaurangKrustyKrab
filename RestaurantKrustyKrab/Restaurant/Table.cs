﻿using RestaurantKrustyKrab.People;
using System.Collections;

namespace RestaurantKrustyKrab.Restaurant
{
    internal class Table : Template
    {

        internal int Seats { get; set; }
        internal int Quality { get; set; }
        internal List<Company> BookedSeats { get; set; }
        internal bool IsAvailable { get; set; }
        internal int TableNumber { get; set; }
        internal Hashtable Orders { get; set; }
        internal bool WaitingForFood { get; set; }
        internal bool RecievedOrder { get; set; }
        internal int EatTimer { get; set; }
        internal bool Finished_Eating { get; set; }
        internal bool Clean { get; set; }
        internal List<Waiter> WipedBy { get; set; }
        internal int WipeTimer { get; set; }

        public Table(int seats, int quality, int positionX, int positionY, bool isAvailable, int tableNumber, bool waitingForFood)
        {
            Frame = new string[4, 20];
            Seats = seats;
            Quality = quality;
            PositionX = positionX;
            PositionY = positionY;
            IsAvailable = isAvailable;
            TableNumber = tableNumber;
            BookedSeats = new List<Company>();
            Orders = new Hashtable();
            WaitingForFood = false;
            RecievedOrder = false;
            EatTimer = -21;
            Finished_Eating = false;
            Clean = true;
            WipedBy = new List<Waiter>();
            WipeTimer = -4;
        }


    }
}
