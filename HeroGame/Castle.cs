using System;
using System.Collections.Generic;
using System.Threading;

namespace HeroGame
{
    class Castle
    {
        int castlelvl;
        size castlesize;
        List<Tower> towers = new List<Tower>();
        public Castle(int castlelvl, size castlesize)
        {
            this.castlelvl = castlelvl;
            this.castlesize = castlesize;
            GenerateTowers();
        }
        public int Castlelvl
        { get { return castlelvl; } }

        public size Castlesize
        { get { return castlesize; } }

        public void GenerateTowers()
        {
            Random rng = new Random();
            int loop = Convert.ToInt32(castlesize) + 1;
            int rooms = 0;
            for (int i = 0; i < loop; i++)
            {
                int randomsize = rng.Next(2);
                if (randomsize == 0)
                { rooms = 4; }
                else
                { rooms = 6; }
                towers.Add(new Tower(Castlelvl, rooms));
            }
        }

        public void PlayCastle(Hero Player, EquipmentManager Equipment)
        {
            int currenttower = 1;
            foreach (var i in towers)
            {
                Console.WriteLine("Entering tower " + currenttower + "...");
                Thread.Sleep(2000);
                Console.Clear();
                i.InTower(Player);
                currenttower++;
            }
            Tower bosstower = new Tower(castlelvl); //the boss tower aka final tower
            Console.WriteLine("Entering the final tower...");
            Thread.Sleep(2000);
            Console.Clear();
            bosstower.InTower(Player);
            LootSword(Player, Equipment);
            LootShield(Player, Equipment);
            LootHelmet(Player, Equipment);
        }
        public void LootSword(Hero Player, EquipmentManager Equipment)
        {
            Random rng = new Random();
            int betterdropchance = 9 - ((Convert.ToInt32(castlesize) + 1) * 2); //used in the for loop as a "minimum value". if the randomly
            int randomnumber = 9;                                               //generated number is below the "betterdropchance" value, you
            int swordlvl = Player.LVL - 1;                                      //will recieve a weapon of that level. otherwise the weapon level
            while (randomnumber > betterdropchance)                              //will increase by 1. This makes it more rewarding to play longer
            {                                                                   //castles as the chance for better loot increases
                if (swordlvl >= 9)  //this is used either if the player lvl is too high or if you have reached the max lvl weapon
                {
                    swordlvl = 9;
                    break;
                }
                randomnumber = rng.Next(10);
                swordlvl++;
            }
            Equipment.GetSword(Player, swordlvl);
        }

        public void LootShield(Hero Player, EquipmentManager Equipment)
        {
            Random rng = new Random();
            int betterdropchance = 9 - ((Convert.ToInt32(castlesize) + 1) * 2); //used in the for loop as a "minimum value". if the randomly
            int randomnumber = 9;                                               //generated number is below the "betterdropchance" value, you
            int shieldlvl = Player.LVL - 1;                                      //will recieve a weapon of that level. otherwise the weapon level
            while (randomnumber > betterdropchance)                              //will increase by 1. This makes it more rewarding to play longer
            {                                                                   //castles as the chance for better loot increases
                if (shieldlvl >= 9)  //this is used either if the player lvl is too high or if you have reached the max lvl shield
                {
                    shieldlvl = 9;
                    break;
                }
                randomnumber = rng.Next(10);
                shieldlvl++;
            }
            Equipment.GetShield(Player, shieldlvl);
        }

        public void LootHelmet(Hero Player, EquipmentManager Equipment)
        {
            Random rng = new Random();
            int betterdropchance = 9 - ((Convert.ToInt32(castlesize) + 1) * 2); //used in the for loop as a "minimum value". if the randomly
            int randomnumber = 9;                                               //generated number is below the "betterdropchance" value, you
            int helmetlvl = Player.LVL - 1;                                     //will recieve a weapon of that level. otherwise the weapon level
            while (randomnumber > betterdropchance)                             //will increase by 1. This makes it more rewarding to play longer
            {                                                                   //castles as the chance for better loot increases
                if (helmetlvl >= 9)  //this is used either if the player lvl is too high or if you have reached the max lvl helmet
                {
                    helmetlvl = 9;
                    break;
                }
                randomnumber = rng.Next(10);
                helmetlvl++;
            }
            Equipment.GetHelmet(Player, helmetlvl);
        }
    }
}
