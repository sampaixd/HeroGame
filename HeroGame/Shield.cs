namespace HeroGame
{
    class Shield
    {
        rarity shieldrarity;
        double shieldprotection;
        set shieldset;
        public Shield(rarity shieldrarity, double shieldprotection, set shieldset)
        {
            this.shieldrarity = shieldrarity;
            this.shieldprotection = shieldprotection;
            this.shieldset = shieldset;
        }
        public rarity Shieldrarity
        { get { return shieldrarity; } }

        public double Shieldprotection
        { get { return shieldprotection; } }

        public set Shieldset
        { get { return shieldset; } }
    }
}
