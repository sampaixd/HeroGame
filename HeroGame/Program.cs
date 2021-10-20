using System;
using System.Collections.Generic;

namespace HeroGame
{
    enum rarity { common, uncommon, rare, epic, legendary }
    enum set { hellflame, voidwalker, none }
    enum setbonus { firedmg, stun, none }
    enum size { small, medium, large }
    class Program
    {
        static void Main(string[] args)
        {
            List<Castle> castles = new List<Castle>();
            /*List<Sword> swords = new List<Sword>();
            List<Shield> shields = new List<Shield>();
            List<Helmet> helmets = new List<Helmet>();
            //all equipment
            swords.Add(new Sword(10, rarity.common, set.none));
            swords.Add(new Sword(20, rarity.common, set.none));
            swords.Add(new Sword(30, rarity.uncommon, set.none));
            swords.Add(new Sword(40, rarity.uncommon, set.none));
            swords.Add(new Sword(50, rarity.rare, set.none));
            swords.Add(new Sword(60, rarity.rare, set.none));
            swords.Add(new Sword(70, rarity.epic, set.none));
            swords.Add(new Sword(80, rarity.epic, set.none));
            swords.Add(new Sword(100, rarity.legendary, set.hellflame));
            swords.Add(new Sword(100, rarity.legendary, set.voidwalker));
            helmets.Add(new Helmet(rarity.common, 3, set.none));
            helmets.Add(new Helmet(rarity.common, 7, set.none));
            helmets.Add(new Helmet(rarity.uncommon, 11, set.none));
            helmets.Add(new Helmet(rarity.uncommon, 15, set.none));
            helmets.Add(new Helmet(rarity.rare, 19, set.none));
            helmets.Add(new Helmet(rarity.rare, 23, set.none));
            helmets.Add(new Helmet(rarity.epic, 27, set.none));
            helmets.Add(new Helmet(rarity.epic, 31, set.none));
            helmets.Add(new Helmet(rarity.legendary, 35, set.hellflame));
            helmets.Add(new Helmet(rarity.legendary, 35, set.voidwalker));
            shields.Add(new Shield(rarity.common, 3, set.none));
            shields.Add(new Shield(rarity.common, 7, set.none));
            shields.Add(new Shield(rarity.uncommon, 11, set.none));
            shields.Add(new Shield(rarity.uncommon, 15, set.none));
            shields.Add(new Shield(rarity.rare, 19, set.none));
            shields.Add(new Shield(rarity.rare, 23, set.none));
            shields.Add(new Shield(rarity.epic, 27, set.none));
            shields.Add(new Shield(rarity.epic, 31, set.none));
            shields.Add(new Shield(rarity.legendary, 35, set.hellflame));
            shields.Add(new Shield(rarity.legendary, 35, set.voidwalker));*/

            EquipmentManager Equipment = new EquipmentManager();
            Hero Player = new Hero(Equipment.Startershield, Equipment.Starterhelmet, Equipment.Startersword);   //creating the player with the hero class

            bool programloop = true;
            string input;
            while (programloop)
            {
                Console.WriteLine("Please enter input");
                input = Console.ReadLine();
                Console.Clear();
                switch (input)  //used for testing
                {
                    case "info":
                        Player.ViewStats();
                        break;
                    case "lvl":
                        Player.LVLUp();
                        break;
                    case "playtest":
                        GenerateCastles(castles, Player);
                        int selectedcastle = PickCastle(castles, Player);
                        castles[selectedcastle].PlayCastle(Player, Equipment);
                        break;
                    case "swordmanager":
                        Console.WriteLine("Pick what number of sword you wish to have (0-9)");
                        Console.WriteLine("WARNING! Game will crash if incorrect input is given");
                        int chosensword = int.Parse(Console.ReadLine());
                        Equipment.GetSword(Player, chosensword);
                        break;
                    case "shieldmanager":
                        Console.WriteLine("Pick what number of shield you wish to have (0-9)");
                        Console.WriteLine("WARNING! Game will crash if incorrect input is given");
                        int chosenshield = int.Parse(Console.ReadLine());
                        Equipment.GetShield(Player, chosenshield);
                        break;
                    case "helmetmanager":
                        Console.WriteLine("Pick what number of helmet you wish to have (0-9)");
                        Console.WriteLine("WARNING! Game will crash if incorrect input is given");
                        int chosenhelmet = int.Parse(Console.ReadLine());
                        Equipment.GetHelmet(Player, chosenhelmet);
                        break;

                        //Sword sword = EquipmentManager.GetWeapons(EquipmentManager.FireSwords);   //tages ide för att hämta vapen
                }
                Console.Clear();
            }

        }
        static void GenerateCastles(List<Castle> castles, Hero Player)  //method that generates which castles can be selected
        {
            castles.Clear();    //clears the list to make sure that the castles selection pool is always correct based on player lvl
            Random rng = new Random();
            int herolvl = Player.LVL;
            int castlelvl;
            size castlesize;
            for (int i = 0; i < 3; i++)
            {
                castlelvl = rng.Next(herolvl, herolvl + 3); //randoms a lvl between the heros current lvl up to 2 lvls above
                castlesize = (size)rng.Next(3);             //randoms a size, this is relevant when deciding the ammount of towers
                castles.Add(new Castle(castlelvl, castlesize));//adds the castle to the list, 
            }
        }

        static int PickCastle(List<Castle> castles, Hero Player)
        {
            int selectedcastle = 0; //defines what option you currently have selected, as well as the "reroll" option
            bool selectloop = true; //bool that keeps the menu open until you select a valid option 
            while (selectloop)
            {
                for (int i = 0; i < 4; i++)     //writes all 4 options, as well as changing the color depending if the option is selected or not
                {
                    Console.Write("       ");
                    if (selectedcastle == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;   //changes background color and text color
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (i != 3)
                    { Console.Write("Castle " + (i + 1)); } //writes the current castle if it isn't the last loop
                    else
                    { Console.Write("Reroll"); }    //otherwise writes the reroll option
                    Console.BackgroundColor = ConsoleColor.Black;   //reverts background color and text color to its original state
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.Write("       LVL: " + castles[0].Castlelvl);   //writes the levels of all castles
                for (int i = 1; i < 3; i++)
                {
                    if (castles[i - 1].Castlelvl > 9)   //different ammount of blank spaces depending on how many numbers, in order to make
                    { Console.Write("        "); }      //it look better
                    else
                    { Console.Write("         "); }
                    Console.Write("LVL: " + castles[i].Castlelvl);
                }
                Console.WriteLine();
                Console.Write("       Size: " + castles[0].Castlesize);
                for (int i = 1; i < 3; i++)
                {
                    if (castles[i - 1].Castlesize == size.small)    //same as with the levels, adding blank spaces for it to look better
                    { Console.Write("    "); }
                    else if (castles[i - 1].Castlesize == size.medium)
                    { Console.Write("   "); }
                    else
                    { Console.Write("    "); }
                    Console.Write("Size: " + castles[i].Castlesize);
                }
                Console.WriteLine();
                ConsoleKeyInfo button = Console.ReadKey();  //reads the input key
                switch (button.Key)
                {
                    case ConsoleKey.D:  //changes the currently selected option based on the user input
                    case ConsoleKey.RightArrow:
                        if (selectedcastle == 3)
                        { selectedcastle = 0; }
                        else
                        { selectedcastle++; }
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (selectedcastle == 0)
                        { selectedcastle = 3; }
                        else
                        { selectedcastle--; }
                        break;
                    case ConsoleKey.Enter:
                        if (selectedcastle == 3)    //if the currently selected option is "reroll", reroll the current castles
                        {
                            GenerateCastles(castles, Player);
                        }
                        else    //otherwise break the loop and return what castle was selected
                        { selectloop = false; }
                        break;
                }
                Console.Clear();
            }
            return selectedcastle;
        }

        public static void Combat(List<Enemy> enemies, int enemynumber, Hero Player)
        {
            Console.Clear();
            Console.WriteLine("Press any key to kill enemy");
            Console.ReadKey();
            int ganinedxp = enemies[enemynumber].LVL * 5;
            Player.Killedenemy(ganinedxp);
            enemies.RemoveAt(enemynumber);
        }

    }
}
