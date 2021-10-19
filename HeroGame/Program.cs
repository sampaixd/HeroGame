using System;
using System.Collections.Generic;
using System.Threading;

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
            List<Enemy> enemies = new List<Enemy>();
            //all equipment
            Sword sword1 = new Sword(10, rarity.common, set.none);
            Sword sword2 = new Sword(20, rarity.common, set.none);
            Sword sword3 = new Sword(30, rarity.uncommon, set.none);
            Sword sword4 = new Sword(40, rarity.uncommon, set.none);
            Sword sword5 = new Sword(50, rarity.rare, set.none);
            Sword sword6 = new Sword(60, rarity.rare, set.none);
            Sword sword7 = new Sword(70, rarity.epic, set.none);
            Sword sword8 = new Sword(80, rarity.epic, set.none);
            Sword sword9 = new Sword(100, rarity.legendary, set.hellflame);
            Sword sword10 = new Sword(100, rarity.legendary, set.voidwalker);
            Helmet helmet1 = new Helmet(rarity.common, 3, set.none);
            Helmet helmet2 = new Helmet(rarity.common, 7, set.none);
            Helmet helmet3 = new Helmet(rarity.uncommon, 11, set.none);
            Helmet helmet4 = new Helmet(rarity.uncommon, 15, set.none);
            Helmet helmet5 = new Helmet(rarity.rare, 19, set.none);
            Helmet helmet6 = new Helmet(rarity.rare, 23, set.none);
            Helmet helmet7 = new Helmet(rarity.epic, 27, set.none);
            Helmet helmet8 = new Helmet(rarity.epic, 31, set.none);
            Helmet helmet9 = new Helmet(rarity.legendary, 35, set.hellflame);
            Helmet helmet10 = new Helmet(rarity.legendary, 35, set.voidwalker);
            Shield shield1 = new Shield(rarity.common, 3, set.none);
            Shield shield2 = new Shield(rarity.common, 7, set.none);
            Shield shield3 = new Shield(rarity.uncommon, 11, set.none);
            Shield shield4 = new Shield(rarity.uncommon, 15, set.none);
            Shield shield5 = new Shield(rarity.rare, 19, set.none);
            Shield shield6 = new Shield(rarity.rare, 23, set.none);
            Shield shield7 = new Shield(rarity.epic, 27, set.none);
            Shield shield8 = new Shield(rarity.epic, 31, set.none);
            Shield shield9 = new Shield(rarity.legendary, 35, set.hellflame);
            Shield shield10 = new Shield(rarity.legendary, 35, set.voidwalker);

            Hero Player = new Hero(shield1, helmet1, sword1);   //creating the player with the hero class

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
                    case "equip hsw":
                        Player.ChangeSword(sword9);
                        break;
                    case "equip vsw":
                        Player.ChangeSword(sword10);
                        break;
                    case "equip hsh":
                        Player.ChangeShield(shield9);
                        break;
                    case "equip vsh":
                        Player.ChangeShield(shield10);
                        break;
                    case "equip hh":
                        Player.ChangeHelmet(helmet9);
                        break;
                    case "equip vh":
                        Player.ChangeHelmet(helmet10);
                        break;
                    case "lvl":
                        Player.LVLUp();
                        break;
                    case "pick":
                        GenerateCastles(castles, Player);
                        int test = PickCastle(castles, Player);
                        break;
                    case "tower":
                        InTower(1, 6, enemies, Player);
                        break;
                    case "enemies":
                        GenerateEnemies(6, 1, enemies);
                        int number = 1;
                        foreach (var i in enemies)
                        {
                            Console.Write(number + ": ");
                            i.Info();
                            Console.WriteLine("\n");
                            number++;
                        }
                        Console.ReadLine();
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
                castlesize = (size)rng.Next(2);             //randoms a size, this is relevant when deciding the ammount of towers
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
                    { Console.Write("      "); }
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
        static void InTower(int towerlvl, int rooms, List<Enemy> enemies, Hero Player)
        {
            bool programloop = true;    //keeps the program alive
            int currentroom = rooms - 1;    //looks at what room you are currently in
            int currentrooms = rooms;   //int to only display the current rooms, as updating what rooms were displayed all the time made it look as you made noprogression
            int currentroompos = 0; //where you are in the current room
            int enemynumber = 0;
            while (programloop)
            {
                for (int i = currentrooms - 2; i < currentrooms; i++)   //the loop only draws 2 rooms to make it look better
                {
                    InTowerBlankSpaces(currentrooms, rooms);    //adds blank spaces if you have traversed the tower enough, to give
                    if (currentroom == i && currentroompos == 6)//the user a better sense of progression
                    { Console.WriteLine("     --#--"); }        //writes a "#" as the players current position, if the player is not at that position
                    else                                        //it instead writes a blank space where the player would be
                    { Console.WriteLine("     -- --"); }
                    InTowerBlankSpaces(currentrooms, rooms);
                    if (currentroom == i && currentroompos == 5)
                    { Console.WriteLine("    |  #  |"); }
                    else
                    { Console.WriteLine("    |     |"); }
                    InTowerBlankSpaces(currentrooms, rooms);
                    if (currentroom == i && currentroompos == 4)
                    { Console.WriteLine("    |  #  |"); }
                    else
                    { Console.WriteLine("    |     |"); }
                    InTowerBlankSpaces(currentrooms, rooms);
                    if (currentroom == i && currentroompos == 3)
                    { Console.WriteLine("     --#--"); }
                    else
                    { Console.WriteLine("     -- --"); }
                    InTowerBlankSpaces(currentrooms, rooms);
                    if (currentroom == i && currentroompos == 2)
                    { Console.WriteLine("      |#|"); }
                    else
                    { Console.WriteLine("      | |"); }
                    InTowerBlankSpaces(currentrooms, rooms);
                    if (currentroom == i && currentroompos == 1)
                    { Console.WriteLine("      |#|"); }
                    else
                    { Console.WriteLine("      | |"); }
                    InTowerBlankSpaces(currentrooms, rooms);
                    if (currentroom == i && currentroompos == 0)
                    { Console.WriteLine("      |#|"); }
                    else
                    { Console.WriteLine("      | |"); }
                }
                enemynumber = 0;
                foreach (var i in enemies)
                {
                    int enemyroom = i.Room;
                    int enemyroompos = i.Roompos;
                    if (enemyroom == currentroom && enemyroompos == currentroompos)
                    {
                        Console.WriteLine("Enemy located...");
                        Thread.Sleep(2000);
                        Combat(enemies, enemynumber, Player);
                        break;
                    }
                    enemynumber++;
                }
                //Console.WriteLine("currentroompos: " + currentroompos + "\ncurrentroom: " + currentroom + "\ncurrentrooms: " + currentrooms);   //used for testing
                ConsoleKeyInfo button = Console.ReadKey();  //reads user input
                switch (button.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:    //traverses the player up or down based on player input
                        if (currentroompos == 6 && currentroom == 0)    //if you have reached the end of the tower the loop stops
                        { programloop = false; }
                        else if (currentroompos >= 6)   //if you have not reached the end of the tower but instead reached the end of a room
                        {
                            if (currentrooms >= currentroom + 2)    //checks if you have traversed 2 rooms 
                            { currentrooms -= 2; }                  //if you have, change the currentrooms int to display the correct rooms in the for loop
                            currentroom--;                          //changes your current room
                            currentroompos = 0;                     //resets the current room pos
                        }
                        else
                        { currentroompos++; }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (currentroompos == 0 && currentroom == (rooms - 1))  //does nothing if you try to backtrack in the beginning
                        { }
                        else if (currentroompos == 0)   //does the same things as moving forward, only changed in order to work the other way around
                        {
                            if (currentrooms <= currentroom + 1)
                            { currentrooms += 2; }
                            currentroom++;
                            currentroompos = 6;
                        }
                        else
                        { currentroompos--; }
                        break;
                }
                Console.Clear();
            }
        }

        static void InTowerBlankSpaces(int currentrooms, int rooms)     //method that writes blank spaces before the tower in order to get a better
        {                                                               //feeling of progression
            for (int i = rooms; i > currentrooms; i -= 2)
            {
                Console.Write("          ");
            }
        }

        static void GenerateEnemies(int rooms, int towerlvl, List<Enemy> enemies)   //generates enemies for the tower based on the ammount of rooms
        {
            enemies.Clear();    //resets the list when you need to make new enemies
            Random rng = new Random();
            int enemycount = rng.Next(rooms, (rooms * 2) + 1);  //creates a random number between the ammount of room and twice the ammount of rooms
            //int enemiesleft = enemies.Count;
            for (int i = 0; i < rooms; i++)
            {                                               //depending on how many enemies have aleady been placed, the max/min ammount of enemies
                int roomenemies = enemycount / (rooms - i);//will change accordingly
                int roomenemiescount = rng.Next(roomenemies - 1, roomenemies + 1);
                int enemiescreated = 0;
                for (int x = 0; x < 6; x++)
                {
                    if (6 - x > roomenemiescount)
                    {
                        int createenemy = rng.Next(2);
                        if (createenemy == 1)
                        {
                            enemies.Add(new Enemy(towerlvl, i, x));
                            enemiescreated++;
                        }
                    }
                    else
                    {
                        enemies.Add(new Enemy(towerlvl, i, x));
                        enemiescreated++;
                    }
                    if (enemiescreated >= roomenemiescount)
                    { break; }
                }
                enemycount -= roomenemiescount;
            }

            /*for (int i = 0; i < enemycount; i++)                //for example: if the ammount of rooms is 6, create a number between 6 and 12 (6*2)
            {
                enemies.Add(new Enemy(towerlvl));
            }*/
        }

        static void EnemyPlacement(List<Enemy> enemies, int rooms)
        {
            Random rng = new Random();
            int enemiesleft = enemies.Count;
            for (int i = 0; i < rooms; i++)
            {                                               //depending on how many enemies have aleady been placed, the max/min ammount of enemies
                int roomenemies = enemiesleft / (rooms - i);//will change accordingly
                int roomenemiescount = rng.Next(roomenemies - 1, roomenemies + 1);
                for (int x = 0; x < 6; x++)
                {
                    int createenemy = rng.Next(2);
                    if (createenemy == 1)
                    { }
                }
                enemiesleft -= roomenemiescount;
            }
        }

        static void Combat(List<Enemy> enemies, int enemynumber, Hero Player)
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
