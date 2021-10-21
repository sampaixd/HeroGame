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
                        //Combat(enemynumber, Player);
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

            /*for (int i = 0; i < enemycount; i++)                //for example: if the ammount of rooms is 6, create a number between 6 and 12 (6*2)
            {
                enemies.Add(new Enemy(towerlvl));
            }*/
        }
    }
}
