namespace HeroGame
{
    class Tower
    {
        int towerlvl;
        int rooms;
        int enemycount;
        public Tower(int castlelvl, int rooms, int enemycount)
        {
            this.towerlvl = castlelvl;
            this.rooms = rooms;
            this.enemycount = enemycount;
        }

        public int Enemycount
        { set { enemycount--; } }
    }
}
