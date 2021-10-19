using System;

namespace HeroGame
{
    class Enemy
    {
        int lvl;
        int hp;
        int room;
        int roompos;
        double armor;
        double dmg;
        public Enemy(int castlelvl, int room, int roompos)
        {
            this.lvl = castlelvl;
            this.hp = 100 * castlelvl;
            this.room = room;
            this.roompos = roompos;
            this.armor = (3 + (4 * castlelvl));
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
            Console.Write(" armor: " + armor);
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
