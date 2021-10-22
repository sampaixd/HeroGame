using System;

namespace HeroGame
{
    class Hero
    {
        double maxhp;
        double hp;
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
        public double MaxHP
        { get { return maxhp; } }
        public double HP
        { get { return hp; } }
        public setbonus Bonuseffect
        { get { return bonuseffect; } }
        public double Dmg
        { get { return dmg; } }


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
            hp = maxhp;
        }

        public void ChangeHelmet(Helmet newHelmet)
        {
            helmet = newHelmet;
            bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset); //checks if the requirements for a set bonus are met
            armormodifier = Armormodifier(shield.Shieldset, helmet.Helmetset);  //checks if the requirements for a armor bonus are met
            armor = ((shield.Shieldprotection + helmet.Helmetprotection) * armormodifier);  //changes the armor value
        }

        public void ChangeShield(Shield newShield)  //refer to ChangeHelmet method
        {
            shield = newShield;
            bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset);
            armormodifier = Armormodifier(shield.Shieldset, helmet.Helmetset);
            armor = ((shield.Shieldprotection + helmet.Helmetprotection) * armormodifier);
        }

        public void ChangeSword(Sword newSword) //same as the other 2, but without the armor modifier and changes dmg instead
        {
            sword = newSword;
            bonuseffect = Checkforsets(shield.Shieldset, helmet.Helmetset, sword.Swordset);
            dmg = sword.Dmg * ((lvl / 10.0) + 0.9);
        }

        public void LVLUp()     //increases the stats
        {
            Console.WriteLine("LVL up!");
            Console.WriteLine("Health and damage increased!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            lvl += 1;
            maxhp += 100;
            hp = maxhp;
            dmg = sword.Dmg * ((lvl / 10.0) + 0.9);
        }

        public void ViewStats()     //displays the stats
        {
            Console.WriteLine("Player level: " + lvl);
            Console.WriteLine("Player xp: " + xp + "/" + lvl * 100);
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

        public void RarityColor(rarity Rarity)  //changes color based on rarity
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

        public void SetColor(set Set)   //changes color based on set
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

        public void SetBonusColor(setbonus Setbonus)    //changes color based on setbonus
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

        public void Attackhero(int enemyattack, double enemydmg, bool stunned)  //when the enemy attacks the hero
        {
            Random rng = new Random();
            int hitrng;     //used to roll a dice to see if the attack will hit or miss
            int critrng;    //used to roll a dice to see if the attack will deal critical damage
            if (!stunned)   //if the enemy is stunned, they will be unable to perform any actions on their turn
            {

                if (enemyattack == 0)
                {
                    hitrng = rng.Next(20);
                    if (hitrng != 0)
                    {
                        critrng = rng.Next(5);
                        if (critrng == 0)
                        {
                            Console.WriteLine("Enemy used swift attack! critical hit! " + enemydmg * 2 + "dmg");
                            Console.WriteLine("Your armor blocks " + armor + " dmg");
                            if (armor > enemydmg * 2)   //if the armor value is bigger than the damage, the damage is by default 0 (instead of
                            { Console.WriteLine("0 dmg taken!"); }//dealing negative damage and therefore healing the player)
                            else
                            {
                                Console.WriteLine((enemydmg * 2) - armor + " dmg taken!");
                                hp -= ((enemydmg * 2) - armor);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enemy used swift attack! " + enemydmg + " dmg");
                            Console.WriteLine("Your armor blocks " + armor + " dmg");
                            if (armor > enemydmg)
                            { Console.WriteLine("0 dmg taken!"); }
                            else
                            {
                                Console.WriteLine(enemydmg - armor + " dmg taken!");
                                hp -= (enemydmg - armor);
                            }
                        }
                    }
                }
                else
                {
                    hitrng = rng.Next(5);
                    if (hitrng != 0)
                    {
                        critrng = rng.Next(10);
                        if (critrng == 0)
                        {
                            Console.WriteLine("Enemy used heavy attack! critical hit! " + enemydmg * 3 + " dmg");
                            Console.WriteLine("Your armor blocks " + armor + " dmg");
                            if (armor > enemydmg * 3)
                            { Console.WriteLine("0 dmg taken!"); }
                            else
                            {
                                Console.WriteLine((enemydmg * 3) - armor + " dmg taken!");
                                hp -= ((enemydmg * 3) - armor);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enemy used heavy attack! " + enemydmg * 1.5 + " dmg");
                            Console.WriteLine("Your armor blocks " + armor + " dmg");
                            if (armor > enemydmg * 1.5)
                            { Console.WriteLine("0 dmg taken!"); }
                            else
                            {
                                Console.WriteLine((enemydmg * 1.5) - armor + " dmg taken!");
                                hp -= ((enemydmg * 1.5) - armor);
                            }

                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Enemy stunned, passing turn...");
            }
        }
    }
}
