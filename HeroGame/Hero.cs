using System;

namespace HeroGame
{
    class Hero
    {
        int maxhp;
        int hp;
        int lvl;
        int xp;
        double dmg;
        setbonus bonuseffect;
        double armor;
        Shield shield;
        Helmet helmet;
        Sword sword;
        double armormodifier;
        public Hero(Shield shield, Helmet helmet, Sword sword)
        {
            this.maxhp = 100;
            this.hp = 100;
            this.lvl = 1;
            this.xp = 0;
            this.shield = shield;
            this.helmet = helmet;
            this.sword = sword;
            this.bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset);
            armormodifier = Armormodifier(shield.Shieldset, helmet.Helmetset);
            this.armor = ((shield.Shieldprotection + helmet.Helmetprotection) * armormodifier);
            this.dmg = sword.Dmg;
        }

        public int LVL
        { get { return lvl; } }
        public setbonus Checkforsets(set shieldset, set helmetset, set swordset)
        {

            if (shieldset == helmetset && helmetset == swordset)
            {
                switch (shieldset)
                {
                    case set.hellflame:
                        return setbonus.firedmg;
                    case set.voidwalker:
                        return setbonus.stun;
                    case set.none:
                        return setbonus.none;
                }
            }
            return setbonus.none;

        }

        public double Armormodifier(set shieldset, set helmetset)
        {
            if (shieldset == helmetset)
            {
                switch (shieldset)
                {
                    case set.hellflame:
                        return 1.30;
                    case set.voidwalker:
                        return 1.15;
                    case set.none:
                        return 1;
                }
            }
            return 1;
        }

        public void Killedenemy(int gainedxp)
        {
            xp += gainedxp;
            if (xp >= lvl * 100)
            {
                xp -= lvl * 100;
                LVLUp();
            }
        }

        public void ChangeHelmet(Helmet newHelmet)
        {
            helmet = newHelmet;
            bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset);
            armormodifier = Armormodifier(shield.Shieldset, helmet.Helmetset);
            armor = ((shield.Shieldprotection + helmet.Helmetprotection) * armormodifier);
        }

        public void ChangeShield(Shield newShield)
        {
            shield = newShield;
            bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset);
            armormodifier = Armormodifier(shield.Shieldset, helmet.Helmetset);
            armor = ((shield.Shieldprotection + helmet.Helmetprotection) * armormodifier);
        }

        public void ChangeSword(Sword newSword)
        {
            sword = newSword;
            bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset);
            dmg = sword.Dmg * ((lvl / 10.0) + 0.9);
        }

        public void LVLUp()
        {
            lvl += 1;
            maxhp += 100;
            hp = maxhp;
            //double dmgmultiplier = (lvl / 10.0) + 0.9;
            dmg = sword.Dmg * ((lvl / 10.0) + 0.9);
        }

        public void ViewStats()
        {
            Console.WriteLine("Player level: " + lvl);
            Console.WriteLine("Player hp: " + hp + "/" + maxhp);
            Console.WriteLine();
            Console.WriteLine("Sword data:");
            Console.Write("Rarity: ");
            RarityColor(sword.Swordrarity);
            Console.WriteLine("Damage: " + sword.Dmg);
            Console.Write("Set: ");
            SetColor(sword.Swordset);
            Console.WriteLine();
            Console.WriteLine("Shield data: ");
            Console.Write("Rarity: ");
            RarityColor(shield.Shieldrarity);
            Console.WriteLine("Protection: " + shield.Shieldprotection);
            Console.Write("Set: ");
            SetColor(shield.Shieldset);
            Console.WriteLine();
            Console.WriteLine("Helmet data:");
            Console.Write("Rarity: ");
            RarityColor(helmet.Helmetrarity);
            Console.WriteLine("Protection: " + helmet.Helmetprotection);
            Console.Write("Set: ");
            SetColor(helmet.Helmetset);
            Console.WriteLine();
            Console.WriteLine("Set armor modifier: " + ((armormodifier * 100) - 100) + "% more effective");
            Console.WriteLine("Total armor: " + armor);
            Console.WriteLine("Total dmg: " + dmg);
            Console.Write("Full set modifier: ");
            SetBonusColor(bonuseffect);
            Console.WriteLine();

            Console.WriteLine("Press any key to continue");

            Console.ReadKey();
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

        public void SetBonusColor(setbonus Setbonus)
        {
            switch (Setbonus)
            {
                case setbonus.firedmg:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case setbonus.stun:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            Console.WriteLine(Setbonus);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
