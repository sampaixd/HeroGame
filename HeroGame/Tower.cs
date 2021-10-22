using System;
using System.Collections.Generic;
using System.Threading;

namespace HeroGame
{
    class Tower
    {
        int towerlvl;
        int rooms;
        List<Enemy> enemies = new List<Enemy>();
        public Tower(int castlelvl, int rooms)
        {
            this.towerlvl = castlelvl;
            this.rooms = rooms;
            GenerateEnemies();
        }
        public Tower(int castlelvl)
        {
            this.rooms = 4;
            enemies.Add(new Enemy((castlelvl * 2), 0, 5));
        }

        public void InTower(Hero Player)
        {
            bool programloop = true;    //keeps the program alive
            int currentroom = rooms - 1;    //looks at what room you are currently in
            int currentrooms = rooms;   //int to only display the current rooms, as updating what rooms were displayed all the time made it look as you made noprogression
            int currentroompos = 0; //where you are in the current room
            int enemynumber = 0;
            bool combatcontinue = false;
            while (programloop)
            {
                combatcontinue = false;
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
                        Console.Clear();
                        Combat(Player, enemynumber, enemies);
                        combatcontinue = true;
                        break;
                    }
                    enemynumber++;
                }
                if (combatcontinue == true)
                { continue; }
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
                    case ConsoleKey.E:
                        Console.Clear();
                        Player.ViewStats();
                        break;
                }
                Console.Clear();
            }
        }

        void InTowerBlankSpaces(int currentrooms, int rooms)     //method that writes blank spaces before the tower in order to get a better
        {                                                               //feeling of progression
            for (int i = rooms; i > currentrooms; i -= 2)
            {
                Console.Write("          ");
            }
        }

        void GenerateEnemies()   //generates enemies for the tower based on the ammount of rooms
        {
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
                            enemies.Add(new Enemy(towerlvl, i, x));     //towerlvl = strength of the enemy, i = what room the enemy will be
                            enemiescreated++;                           // x = where in the room the enemy will be
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
        }

        void Combat(Hero Player, int enemynumber, List<Enemy> enemies)
        {
            int selectedoption = 0;
            bool incombat = true;
            bool yourturn = true;
            while (incombat)
            {
                Console.WriteLine("Player hp: " + Player.HP + "/" + Player.MaxHP + "          " +
                    "Enemy hp: " + enemies[enemynumber].HP + "/" + enemies[enemynumber].LVL * 50);
                if (yourturn)
                {
                    Console.WriteLine("Your turn");
                    Console.WriteLine("\n\n\nSelect what action you wish to do");
                    Console.WriteLine();
                    if (selectedoption == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write("Swift attack");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("          ");
                    if (selectedoption == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write("Heavy attack");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("          ");
                    if (selectedoption == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine("Armor piercing attack");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\n");
                    if (selectedoption == 0)
                    {
                        Console.WriteLine("A swift attack has a higher chance to hit, as well as \n" +
                            "a higher chance to deal critical damage");
                        Console.WriteLine("\n");
                        Console.WriteLine("Damage: " + Player.Dmg + "   Chance to hit: 95%   Chance to crit: 20%");
                    }
                    else if (selectedoption == 1)
                    {
                        Console.WriteLine("A heavy attack deals more damage to the opponent, \n" +
                            "but has a higher chance to miss as well as a lower chance to deal critical damage");
                        Console.WriteLine("\n");
                        Console.WriteLine("Damage: " + Player.Dmg * 1.5 + "   Chance to hit: 80%   Chance to crit: 10%");
                    }
                    else
                    {
                        Console.WriteLine("A armor piercing attack has both the same damage as a swift attack \n" +
                            "well as the critical chance as a heavy attack, however it ignores armor");
                        Console.WriteLine("\n");
                        Console.WriteLine("Damage: " + Player.Dmg + "   Chance to hit: 80%   Chance to crit: 10%");
                    }
                    Console.WriteLine("\n\n\n");
                    if (Player.Bonuseffect == setbonus.firedmg)
                    {
                        Console.Write("Set bonus: ");
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("FIRE DAMAGE");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("All attacks sets the enemy on fire, dealing 10% of their max hp \n" +
                            "over 3 turns. The effect stacks for each attack");
                    }
                    else if (Player.Bonuseffect == setbonus.stun)
                    {
                        Console.Write("Set bonus: ");
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("STUN");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Your attacks have a 50% chance to stun the enemy, making them unable \n" +
                            "to perform any actions on their next turn.");
                    }
                    ConsoleKeyInfo button = Console.ReadKey();
                    switch (button.Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (selectedoption == 0)
                            { selectedoption = 2; }
                            else
                            { selectedoption--; }
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (selectedoption == 2)
                            { selectedoption = 0; }
                            else
                            { selectedoption++; }
                            break;
                        case ConsoleKey.Enter:
                            enemies[enemynumber].Attackenemy(Player, selectedoption, Player.Bonuseffect);
                            Console.ReadKey();
                            yourturn = false;
                            break;
                        case ConsoleKey.E:
                            Console.Clear();
                            Player.ViewStats();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enemy turn");
                    enemies[enemynumber].Takefiredmg();
                    Random rng = new Random();
                    int enemyattack = rng.Next(2);
                    Player.Attackhero(enemyattack, enemies[enemynumber].Dmg, enemies[enemynumber].Stunned);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    yourturn = true;
                }
                if (enemies[enemynumber].HP <= 0)   //if the enemy dies
                {
                    Console.Clear();
                    Console.WriteLine("Enemy killed!");
                    Console.WriteLine(enemies[enemynumber].LVL * 5 + " xp gained!");
                    Console.WriteLine("Your health has been restored");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Player.Killedenemy(enemies[enemynumber].LVL * 5);
                    enemies.RemoveAt(enemynumber);
                    incombat = false;
                }
                else if (Player.HP <= 0)    //if the player health falls below 0, you die and the program will end
                {
                    Console.Clear();
                    Console.WriteLine("You died");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                    Console.Clear();
                }
                Console.Clear();
            }
        }
    }
}

