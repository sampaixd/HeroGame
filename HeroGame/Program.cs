﻿using System;
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
                switch (input)
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
                        Player.LVLUp(0);
                        break;
                    case "pick":
                        GenerateCastles(castles, Player);
                        int test = PickCastle(castles, Player);
                        break;

                        //Sword sword = EquipmentManager.GetWeapons(EquipmentManager.FireSwords);   //tages ide för att hämta vapen
                }
                Console.Clear();
            }

        }
        static void GenerateCastles(List<Castle> castles, Hero Player)
        {
            castles.Clear();
            Random rng = new Random();
            int herolvl = Player.LVL;
            int castlelvl;
            size castlesize;
            for (int i = 0; i < 3; i++)
            {
                castlelvl = rng.Next(herolvl, herolvl + 3);
                castlesize = (size)rng.Next(2);
                castles.Add(new Castle(castlelvl, castlesize));
            }
        }

        static int PickCastle(List<Castle> castles, Hero Player)
        {
            int selectedcastle = 0; //defines what option you currently have selected, as well as the "reroll" option
            bool selectloop = true;
            while (selectloop)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("       ");
                    if (selectedcastle == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (i != 3)
                    { Console.Write("Castle " + (i + 1)); }
                    else
                    { Console.Write("Reroll"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.Write("       LVL: " + castles[0].Castlelvl);
                for (int i = 1; i < 3; i++)
                {
                    if (castles[i - 1].Castlelvl > 9)
                    { Console.Write("        "); }
                    else
                    { Console.Write("         "); }
                    Console.Write("LVL: " + castles[i].Castlelvl);
                }
                Console.WriteLine();
                // + "         LVL: " + castles[1].Castlelvl + "         LVL: " + castles[2].Castlelvl
                Console.Write("       Size: " + castles[0].Castlesize);
                for (int i = 1; i < 3; i++)
                {
                    if (castles[i - 1].Castlesize == size.small)
                    { Console.Write("    "); }
                    else if (castles[i - 1].Castlesize == size.medium)
                    { Console.Write("   "); }
                    else
                    { Console.Write("      "); }
                    Console.Write("Size: " + castles[i].Castlesize);
                }
                Console.WriteLine();
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.D:
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
                        if (selectedcastle == 3)
                        {
                            castles.Clear();
                            GenerateCastles(castles, Player);
                        }
                        else
                        { selectloop = false; }
                        break;
                }
                Console.Clear();
            }
            return 1;
        }
    }
}
