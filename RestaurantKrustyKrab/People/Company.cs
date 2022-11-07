namespace RestaurantKrustyKrab.People
{
    internal class Company
    {
        internal List<Guest> Guests { get; set; }
        internal int timeWaiting { get; set; }

        static internal Random random = new Random();

        public Company()
        {
            GenerateGuests();

            void GenerateGuests()
            {
                int guests = random.Next(1, 5);

                Guests = new List<Guest>();

                for (int i = 0; i < guests; i++)

                {
                    Guests.Add(new Guest(GetName(), 32, 4 + i));
                }

               

            }

            timeWaiting = 0;
            
        }
        public string GetName()
        {
            string[] ArrayNameList = { "Mohammed", "Thom", "Bilal", "Daniel", "Erik", "Elias", "Emma", "Kenneth", "Andersson", "Johansson", "Karlssson","Nillsson", "Eriksson"
            , "Larsson","Olsson","Persson","Svensson","Gustavsson","Petterson","Johnsson","Jansson","Hansson","Bengtsson","Jönsson","Lindberg","Jakobsson","Magnusson","Lindström"
            ,"Olofsson","Lindkvist","Lindgren","Berg","Axelsson","Bergström","Lundberg","Lind","Lundgren","Lundqvist","Mattsson","Berglund","Fredriksson","Samberg","Henriksson"
            ,"Ali","Forsberg","Sjöberg","Walin","Engström","Eklund","Danielsson","Lundin","Håkansson","Björk","Bergman","Gunnarsson","Wikström","Holm","Samuelsson","Isaksson"
            ,"Fransson","Bergkvist","Nyström","Holmberg","Arvidsson","Lövgren","Söderberg","Nyberg","Ahmed","Blomqvist","Classon","Nordström","Hassan","Mårtensson","Lundström"
            ,"Viklund","Björklund","Eliasson","Berggren","Pålsson","Sandström","Nordin","Lund","Falk","Ström","Åberg","Ekström","Hermansson,Turtle, Garfield, alligator, headphones, wedding dress, violin, newspaper, raincoat, chameleon,Cardboard, Oar, Drip, Shampoo, Time Machine, Yardstick, Think, Lace, Darts, Avocado, Bleach,Curtain, Extension Cord, Dent, Birthday, Lap, Sandbox, Bruise, Fog, Sponge, Wig, Pilot, Mascot, Fireman, Zoo, Sushi, Fizz, Ceiling, Post Office, Season, Internet, Chess, Puppet, Chime, Koala, Dentist, Ping Pong, Bonnet, Sheets, Sunburn, Houseboat, Sleep, Kneel, Crust, Speakers, Cheerleader, Dust, Salmon, Cabin, Handle,Swamp, Cruise, Pharmacist,Dream,Raft,Plank,Cliff, Sweater, Safe,Picnic, Shrink, Ray, Leak,Deep, Tiptoe,Hurdle, Knight,Cloak,Bedbug Hot Tub, Firefighter, Charger, Nightmare,Coach,Sneeze,Goblin,Chef,Applause,Golden Retriever,Joke,Comedian,Cupcake,Baker,Facebook,Convertible,Giant,Garden,Diving,Hopscotch,Stingray,Song,Trip,Backbone,Bomb,Treasure,Garbage,Park,Pirate,Ski,Whistle,State,Baseball,Coal,Queen,Photograph,Computer,Hockey,Hot Dog,Salt and Pepper, iPad, Frog, Lawnmower, Mattress, Pinwheel, Cake, Circus, Battery, Mailman, Cowboy,Password,Bicycle,Skate,Electricity,Thief,Teapot,Deep,Spring,Nature,Shallow,Outside,America,Bow tie,Wax,Light Bulb,Music,Popsicle,Brain,Birthday Cake, Knee, Pineapple, Tusk, Sprinkler, Money, Pool, Lighthouse, Doormat, Face, Flute, Rug, Snowball, Purse, Owl, Gate, Suitcase, Stomach, Doghouse, Pajamas, Bathroom, Scale, Peach, Newspaper, Watering Can, Hook, School, French Fries, Beehive, Artist, Flagpole, Camera,Hair Dryer,Mushroom,TV,Quilt,Chalk,angle,ant,apple,arch,arm,army,baby,bag,ball,band,basin,basket,bath,bed,bee,bell,berry,bird,blade,board,boat,bone,book,boot,bottle,box,boy,brain,brake,branch,brick,bridge,brush,bucket,bulb,button,cake,camera,card,carriage,cart,cat,chain,cheese,chess,chin,church,circle,clock,cloud,coat,collar,comb,cord,cow,cup,curtain,cushion,dog,door,drain,drawer,dress,drop,ear,egg,engine,eye,face,farm,feather,finger,fish,flag,floor,fly,foot,fork,fowl,frame,garden,girl,glove,goat,gun,hair,hammer,hand,hat,head,heart,hook,horn,horse,hospital,house,island,jewel,kettle,key,knee,knife,knot,leaf,leg,line,lip,lock,map,match,monkey,moon,mouth,muscle,nail,neck,needle,nerve,net,nose,nut,office,orange,oven,parcel,pen,pencil,picture,pig,pin,pipe,plane,plate,plough,pocket,pot,potato,prison,pump,rail,rat,receipt,ring,rod,roof,root,sail,school,scissors,screw,seed,sheep,shelf,ship,shirt,shoe,skin,skirt,snake,sock,spade,sponge,spoon,spring,square,stamp,star,station,stem,stick,stocking,stomach,store,street,sun,table,tail,thread,throat,thumb,ticket,toe,tongue,tooth,town,train,tray,tree,trousers,umbrella,wall,watch,wheel,whip,whistle,window,wing,wire,worm,"};
            string name = ArrayNameList[random.Next(0, ArrayNameList.Length - 1)];
            return name;
        }
    }
}
