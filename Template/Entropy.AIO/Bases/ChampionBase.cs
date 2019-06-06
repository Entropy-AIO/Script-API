namespace Entropy.AIO.Bases
{
    using SDK.Spells;

    abstract class ChampionBase
    {
        public static Spell Q { get; set; }
        public static Spell W { get; set; }
        public static Spell E { get; set; }
        public static Spell R { get; set; }

        public static Spell GetSpellFromSlot(SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.Q: return Q;
                case SpellSlot.W: return W;
                case SpellSlot.E: return E;
                case SpellSlot.R: return R;
            }

            return null;
        }
    }
}