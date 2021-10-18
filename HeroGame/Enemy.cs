namespace HeroGame
{
    class Enemy
    {
        int hp;
        double armor;
        double dmg;
        public Enemy(int castlelvl)
        {
            this.hp = hp * castlelvl;
            this.armor = (3 + (4 * castlelvl));
            this.dmg = 10 * castlelvl;
        }
    }
}
