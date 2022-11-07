using RestaurantKrustyKrab.GUI;
using RestaurantKrustyKrab.Restaurant;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using System;

namespace RestaurantKrustyKrab.People
{
    internal class Company
    {
        internal List<Guest> Guests { get; set; }
        internal int timeWaiting { get; set; }

        static internal Random random = new Random();

        public Company(int offSetRow)
        {
            int guests = random.Next(1, 5);   
            this.Guests = new List<Guest>();
            for(int i = 0; i < guests; i++)
            {
                
                Guests.Add(new Guest(GetName(), 32, 4+i+offSetRow));
            }
            this.timeWaiting = 0;
        }
        public string GetName()
        {
            string[] ArrayNameList = { "Mohammed", "Thom", "Bilal", "Daniel", "Erik", "Elias", "Emma", "Kenneth", "Andersson", "Johansson", "Karlssson","Nillsson", "Eriksson"
            , "Larsson","Olsson","Persson","Svensson","Gustavsson","Petterson","Johnsson","Jansson","Hansson","Bengtsson","Jönsson","Lindberg","Jakobsson","Magnusson","Lindström"
                ,"Olofsson","Lindkvist","Lindgren","Berg","Axelsson","Bergström","Lundberg","Lind","Lundgren","Lundqvist","Mattsson","Berglund","Fredriksson","Samberg","Henriksson"
                ,"Ali","Forsberg","Sjöberg","Walin","Engström","Eklund","Danielsson","Lundin","Håkansson","Björk","Bergman","Gunnarsson","Wikström","Holm","Samuelsson","Isaksson"
                ,"Fransson","Bergkvist","Nyström","Holmberg","Arvidsson","Lövgren","Söderberg","Nyberg","Ahmed","Blomqvist","Classon","Nordström","Hassan","Mårtensson","Lundström"
            ,"Viklund","Björklund","Eliasson","Berggren","Pålsson","Sandström","Nordin","Lund","Falk","Ström","Åberg","Ekström","Hermansson"};
            string name = ArrayNameList[random.Next(0, ArrayNameList.Length - 1)];
            return name;
        }
    }
}
