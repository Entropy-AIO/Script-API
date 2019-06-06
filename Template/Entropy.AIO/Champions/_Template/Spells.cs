namespace Entropy.AIO.Champions._Template
{
    using Misc;
    using SDK.Spells;
    using static Bases.ChampionBase;

    class Spells
    {
        public Spells()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Q = new Spell(SpellSlot.Q);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R);

            Q.SetCustomDamageCalculateFunction(Damage.QDamage);
            W.SetCustomDamageCalculateFunction(Damage.WDamage);
            E.SetCustomDamageCalculateFunction(Damage.EDamage);
            R.SetCustomDamageCalculateFunction(Damage.RDamage);
        }
    }
}