using System;
using System.Collections.Generic;

namespace HeroGame
{
    class EquipmentManager  //experimental class, may or may not make it into the final product
    {
        List<Sword> swords = new List<Sword>();
        List<Shield> shields = new List<Shield>();
        List<Helmet> helmets = new List<Helmet>();
        public EquipmentManager()
        {
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
            shields.Add(new Shield(rarity.legendary, 35, set.voidwalker));
        }

        public Sword Startersword
        { get { return swords[0]; } }

        public Shield Startershield
        { get { return shields[0]; } }

        public Helmet Starterhelmet
        { get { return helmets[0]; } }
        public void GetSword(Hero Player, int swordnumber)
        {
            bool loop = true;   //loops the code
            bool selectedoption = true;
            while (loop)
            {
                Console.WriteLine("Sword found!");
                Console.Write("Rarity: ");
                RarityColor(swords[swordnumber].Swordrarity);
                Console.WriteLine("Damage: " + swords[swordnumber].Dmg);
                Console.Write("Set: ");
                SetColor(swords[swordnumber].Swordset);
                Console.WriteLine();
                Console.WriteLine("Do you wish to replace your old sword?");
                Console.WriteLine();
                Console.Write("          ");
                if (selectedoption == true)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write("Yes");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("          ");
                if (selectedoption == false)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("No");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                ConsoleKeyInfo button = Console.ReadKey();
                Console.Clear();
                switch (button.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.A:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        selectedoption = !selectedoption;
                        break;
                    case ConsoleKey.Enter:
                        loop = false;
                        break;
                }

            }
            if (selectedoption == true)
            {
                Player.ChangeSword(swords[swordnumber]);
            }

        }

        public void GetShield(Hero Player, int shieldnumber)
        {
            bool loop = true;   //loops the code
            bool selectedoption = true;
            while (loop)
            {
                Console.WriteLine("Shield found!");
                Console.Write("Rarity: ");
                RarityColor(shields[shieldnumber].Shieldrarity);
                Console.WriteLine("Protection: " + shields[shieldnumber].Shieldprotection);
                Console.Write("Set: ");
                SetColor(shields[shieldnumber].Shieldset);
                Console.WriteLine();
                Console.WriteLine("Do you wish to replace your old shield?");
                Console.WriteLine();
                Console.Write("          ");
                if (selectedoption == true)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write("Yes");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("          ");
                if (selectedoption == false)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("No");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                ConsoleKeyInfo button = Console.ReadKey();
                Console.Clear();
                switch (button.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.A:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        selectedoption = !selectedoption;
                        break;
                    case ConsoleKey.Enter:
                        loop = false;
                        break;
                }

            }
            if (selectedoption == true)
            {
                Player.ChangeShield(shields[shieldnumber]);
            }
        }

        public void GetHelmet(Hero Player, int helmetnumber)
        {
            bool loop = true;   //loops the code
            bool selectedoption = true;
            while (loop)
            {
                Console.WriteLine("Helmet found!");
                Console.Write("Rarity: ");
                RarityColor(helmets[helmetnumber].Helmetrarity);
                Console.WriteLine("Protection: " + helmets[helmetnumber].Helmetprotection);
                Console.Write("Set: ");
                SetColor(helmets[helmetnumber].Helmetset);
                Console.WriteLine();
                Console.WriteLine("Do you wish to replace your old helmet?");
                Console.WriteLine();
                Console.Write("          ");
                if (selectedoption == true)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write("Yes");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("          ");
                if (selectedoption == false)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("No");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                ConsoleKeyInfo button = Console.ReadKey();
                Console.Clear();
                switch (button.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.A:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        selectedoption = !selectedoption;
                        break;
                    case ConsoleKey.Enter:
                        loop = false;
                        break;
                }

            }
            if (selectedoption == true)
            {
                Player.ChangeHelmet(helmets[helmetnumber]);
            }
        }

        public void RarityColor(rarity Rarity)
        {
            switch (Rarity)
            {
                case rarity.common:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case rarity.uncommon:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case rarity.rare:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case rarity.epic:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case rarity.legendary:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.WriteLine(Rarity);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SetColor(set Set)
        {
            switch (Set)
            {
                case set.hellflame:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case set.voidwalker:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            Console.WriteLine(Set);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
