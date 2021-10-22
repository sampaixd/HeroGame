using System;
using System.Collections.Generic;

namespace HeroGame
{
    class Enemy
    {
        int lvl;
        double hp;
        int room;
        int roompos;
        double dmg;
        bool stunned;
        List<int> firedmg = new List<int>();
        public Enemy(int castlelvl, int room, int roompos)
        {
            this.lvl = castlelvl;
            this.hp = 50 * castlelvl;
            this.room = room;
            this.roompos = roompos;
            this.dmg = 10 * castlelvl;
            this.stunned = false;
        }
        public void Attackenemy(Hero Player, int chosenattack, setbonus debuff) //method when the player attacks a enemy
        {
            Random rng = new Random();  //very similar to the method "Attackhero" inside the Hero class, but with an additional attack as
            int hitrng;                 //well as the ability to apply special effects (stun and firedmg)
            int critrng;
            if (chosenattack == 0)
            {
                hitrng = rng.Next(20);
                if (hitrng != 0)
                {
                    critrng = rng.Next(5);
                    if (critrng == 0)
                    {
                        Console.WriteLine("Critical hit! " + Player.Dmg * 2 + " damage dealt!");
                        hp -= (Player.Dmg * 2);
                    }
                    else
                    {
                        Console.WriteLine("Hit! " + Player.Dmg + " damage dealt!");
                        hp -= Player.Dmg;
                    }
                }
                else
                {
                    Console.WriteLine("Attack missed!");
                }
            }
            else if (chosenattack == 1)
            {
                hitrng = rng.Next(5);
                if (hitrng != 0)
                {
                    critrng = rng.Next(10);
                    if (critrng == 0)
                    {
                        Console.WriteLine("Critical hit! " + Player.Dmg * 3 + " damage dealt!");
                        hp -= Player.Dmg * 3;
                    }
                    else
                    {
                        Console.WriteLine("Hit! " + Player.Dmg * 1.5 + " damage dealt!");
                        hp -= Player.Dmg * 1.5;
                    }
                }
                else
                {
                    Console.WriteLine("Attack missed!");
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
                        Console.WriteLine("Critical hit! " + Player.Dmg * 2 + " damage dealt!");
                        hp -= Player.Dmg * 2;
                    }
                    else
                    {
                        Console.WriteLine("Hit! " + Player.Dmg + " damage dealt!");
                        hp -= Player.Dmg;
                    }
                }
                else
                {
                    Console.WriteLine("Attack missed!");
                }
            }
            if (hitrng != 0)
            {
                if (debuff == setbonus.firedmg)     //the set bonuses
                {
                    firedmg.Add(3);
                    Console.WriteLine("You set the enemy on fire!");
                }
                else if (debuff == setbonus.stun)
                {
                    int stunrng = rng.Next(2);
                    if (stunrng == 0)
                    {
                        stunned = true;
                        Console.WriteLine("You stunned the enemy!");
                    }
                }
            }
        }

        public void Takefiredmg()   //method that deals fire damage for each firedmg stack applied
        {
            if (firedmg.Count != 0)
            {
                double firedmgpercentage = 0;
                for (int i = 0; i < firedmg.Count; i++)
                {
                    firedmgpercentage += 0.1;   //deals 10% of their max health for each applied firedmg
                    firedmg[i]--;
                    if (firedmg[i] <= 0)
                    { firedmg.RemoveAt(i); }
                }

                Console.WriteLine("The enemy is burning! " + (lvl * 50) * firedmgpercentage + " dmg dealt with fire");
                hp -= firedmgpercentage * 50 * lvl;
            }
        }
        /*public void Info()    //used in testing, might be useful again sometime
        {
            Console.Write("LVL: " + lvl);
            Console.Write(" HP: " + hp);
            Console.Write(" room: " + room);
            Console.Write(" roompos: " + roompos);
            Console.Write(" dmg: " + dmg);
        }*/

        public int Room
        { get { return room; } }
        public int Roompos
        { get { return roompos; } }
        public int LVL
        { get { return lvl; } }
        public double HP
        { get { return hp; } }
        public double Dmg
        { get { return dmg; } }
        public bool Stunned
        { get { return stunned; } }
    }
}
