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

            EquipmentManager Equipment = new EquipmentManager();
            Hero Player = new Hero(Equipment.Startershield, Equipment.Starterhelmet, Equipment.Startersword);   //creating the player with the hero class

            bool programloop = true;
            string input;
            while (programloop)
            {
                GenerateCastles(castles, Player);
                PickCastle(castles, Player, Equipment);
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

        static int PickCastle(List<Castle> castles, Hero Player, EquipmentManager Equipment)
        {
            int selectedcastle = 0; //defines what option you currently have selected, as well as the "reroll" option
            bool selectloop = true; //bool that keeps the menu open until you select a valid option 
            while (selectloop)
            {
                for (int i = 0; i < 5; i++)     //writes all 4 options, as well as changing the color depending if the option is selected or not
                {
                    Console.Write("       ");
                    if (selectedcastle == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;   //changes background color and text color
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (i == 4)
                    { Console.Write("Dev tools"); } //writes the current castle if it isn't the last loop
                    else if (i == 3)
                    { Console.Write("Reroll"); }    //otherwise writes the reroll option
                    else
                    { Console.Write("Castle " + (i + 1)); }
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
                        if (selectedcastle == 4)
                        { selectedcastle = 0; }
                        else
                        { selectedcastle++; }
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (selectedcastle == 0)
                        { selectedcastle = 4; }
                        else
                        { selectedcastle--; }
                        break;
                    case ConsoleKey.Enter:
                        if (selectedcastle == 3)    //if the currently selected option is "reroll", reroll the current castles
                        {
                            GenerateCastles(castles, Player);
                        }
                        else if (selectedcastle == 4)
                        {
                            Console.Clear();
                            Devtools(Player, Equipment, castles);
                        }
                        else    //otherwise break the loop and return what castle was selected
                        {
                            Console.Clear();
                            Console.WriteLine("Castle " + (selectedcastle + 1) + " chosen");
                            castles[selectedcastle].PlayCastle(Player, Equipment);
                        }
                        break;
                }
                Console.Clear();
            }
            return selectedcastle;
        }

        public static void Devtools(Hero Player, EquipmentManager Equipment, List<Castle> castles)
        {
            bool devtools = true;
            string input;
            while (devtools)
            {
                Console.WriteLine("Please enter input");
                input = Console.ReadLine();
                Console.Clear();
                switch (input)  //used for testing
                {
                    case "info":
                        Player.ViewStats(); //same as pressing e in a castle
                        break;
                    case "lvl":
                        Player.LVLUp(); //levels up the player
                        break;
                    case "swordmanager":    //allows you to equip a new sword
                        Console.WriteLine("Pick what number of sword you wish to have (0-9)");
                        Console.WriteLine("WARNING! Game will crash if incorrect input is given");
                        int chosensword = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Equipment.GetSword(Player, chosensword);
                        break;
                    case "shieldmanager":   //allows you to equip a new shield
                        Console.WriteLine("Pick what number of shield you wish to have (0-9)");
                        Console.WriteLine("WARNING! Game will crash if incorrect input is given");
                        int chosenshield = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Equipment.GetShield(Player, chosenshield);
                        break;
                    case "helmetmanager":   //allows you to equip a new helmet
                        Console.WriteLine("Pick what number of helmet you wish to have (0-9)");
                        Console.WriteLine("WARNING! Game will crash if incorrect input is given");
                        int chosenhelmet = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Equipment.GetHelmet(Player, chosenhelmet);
                        break;
                    case "hellflame":   //lvls up the character and initiates the method for equipping all parts of the "hellflame" set
                        for (int i = 0; i < 10; i++)
                        {
                            Player.LVLUp();
                        }
                        Equipment.GetSword(Player, 8);
                        Equipment.GetShield(Player, 8);
                        Equipment.GetHelmet(Player, 8);
                        break;
                    case "voidwalker":   //lvls up the character and initiates the method for equipping all parts of the "voidwalker" set
                        for (int i = 0; i < 10; i++)
                        {
                            Player.LVLUp();
                        }
                        Equipment.GetSword(Player, 9);
                        Equipment.GetShield(Player, 9);
                        Equipment.GetHelmet(Player, 9);
                        break;
                    case "help":    //displays all avalible commands
                        Console.WriteLine("'info' displays info about the player");
                        Console.WriteLine("'lvl' increases the player lvl by 1");
                        Console.WriteLine("'swordmanager' allows you to equip a new sword");
                        Console.WriteLine("'shieldmanager' allows you to equip a new shield");
                        Console.WriteLine("'helmetmanager' allows you to equip a new helmet");
                        Console.WriteLine("'exit' returns you back to the castle selection meny");
                        Console.WriteLine("'hellflame' gives you 10 levels and equips the hellflame set");
                        Console.WriteLine("'voidwalker' gives you 10 levels and equips the voidwalker set");
                        Console.WriteLine("Press any key to return to dev menu");
                        Console.ReadKey();
                        break;
                    case "exit":
                        GenerateCastles(castles, Player);
                        devtools = false;
                        break;
                        //Sword sword = EquipmentManager.GetWeapons(EquipmentManager.FireSwords);   //tages ide för att hämta vapen
                }
                Console.Clear();
            }
        }

    }
}
