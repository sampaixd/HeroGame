namespace HeroGame
{
    class Sword
    {
        int dmg;
        rarity swordrarity;
        set swordset;
        public Sword(int dmg, rarity swordrarity, set swordset)
        {
            this.dmg = dmg;
            this.swordrarity = swordrarity;
            this.swordset = swordset;
        }

        public int Dmg
        { get { return dmg; } }

        public rarity Swordrarity
        { get { return swordrarity; } }

        public set Swordset
        { get { return swordset; } }
    }
}
