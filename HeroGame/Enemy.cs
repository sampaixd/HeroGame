using System;

namespace HeroGame
{
    class Enemy
    {
        int lvl;
        int hp;
        int room;
        int roompos;
        double dmg;
        public Enemy(int castlelvl, int room, int roompos)
        {
            this.lvl = castlelvl;
            this.hp = 50 * castlelvl;
            this.room = room;
            this.roompos = roompos;
            this.dmg = 10 * castlelvl;
        }
        public int Death()
        {
            return lvl * 5;
        }
        public void Info()
        {
            Console.Write("LVL: " + lvl);
            Console.Write(" HP: " + hp);
            Console.Write(" room: " + room);
            Console.Write(" roompos: " + roompos);
            Console.Write(" dmg: " + dmg);
        }

        public int Room
        { get { return room; } }
        public int Roompos
        { get { return roompos; } }

        public int LVL
        { get { return lvl; } }
    }
}
