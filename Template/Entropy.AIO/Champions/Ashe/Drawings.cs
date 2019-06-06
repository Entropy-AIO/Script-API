namespace Entropy.AIO.Champions.Ashe
{
    using Bases;
    using SDK.Spells;

    class Drawings : DrawingBase
    {
        public Drawings(params Spell[] spells)
        {
            this.Spells = spells;
        }
    }
}