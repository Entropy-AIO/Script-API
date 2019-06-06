namespace Entropy.AIO.Champions.Ashe
{
    using Misc;
    using SDK.Enumerations;
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
            W = new Spell(SpellSlot.W, 1280f);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R, 15000);

            W.SetSkillshot(0.25f, 60f, 1290f, SkillshotType.Cone);
            R.SetSkillshot(0.25f, 130f, 1600f, SkillshotType.Line, false);
            W.SetCustomDamageCalculateFunction(Damage.W);
            R.SetCustomDamageCalculateFunction(Damage.R);
        }
    }
}