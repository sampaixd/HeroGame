namespace HeroGame
{
    class Helmet
    {
        rarity helmetrarity;
        double helmetprotection;
        set helmetset;
        public Helmet(rarity helmetrarity, double helmetprotection, set helmetset)
        {
            this.helmetrarity = helmetrarity;
            this.helmetprotection = helmetprotection;
            this.helmetset = helmetset;
        }

        public rarity Helmetrarity
        { get { return helmetrarity; } }

        public double Helmetprotection
        { get { return helmetprotection; } }

        public set Helmetset
        { get { return helmetset; } }
    }
}
