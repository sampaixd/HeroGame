using System;

namespace HeroGame
{
    enum rarity { common, uncommon, rare, epic, legendary }
    enum set { hellflame, voidwalker, none }
    enum setbonus { firedmg, stun, none }
    class Program
    {
        static void Main(string[] args)
        {
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

                        //Sword sword = EquipmentManager.GetWeapons(EquipmentManager.FireSwords);   //tages ide för att hämta vapen
                }
                Console.Clear();
            }

        }
    }
}
