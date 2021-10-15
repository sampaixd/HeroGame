namespace HeroGame
{
    class Castle
    {
        int castlelvl;
        size castlesize;
        public Castle(int castlelvl, size castlesize)
        {
            this.castlelvl = castlelvl;
            this.castlesize = castlesize;
        }
        public int Castlelvl
        { get { return castlelvl; } }

        public size Castlesize
        { get { return castlesize; } }
    }
}
