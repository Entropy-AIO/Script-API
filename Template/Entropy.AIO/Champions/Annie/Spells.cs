namespace Entropy.AIO.Champions.Annie
{
    using Misc;
    using SDK.Enumerations;
    using SDK.Extensions.Objects;
    using SDK.Spells;
    using static Bases.ChampionBase;

    class Spells
    {
        public static Spell Flash;

        public Spells()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Q     = new Spell(SpellSlot.Q, 625f);
            W     = new Spell(SpellSlot.W, 550f);
            E     = new Spell(SpellSlot.E);
            R     = new Spell(SpellSlot.R, 600f);
            Flash = new Spell(LocalPlayer.Instance.GetSpellSlotFromName("SummonerFlash"), 400f);

            W.SetSkillshot(0.5f, 250f, float.MaxValue, SkillshotType.Cone, false);
            R.SetSkillshot(0.2f, 250f, float.MaxValue, SkillshotType.Circle, false);

            Q.SetCustomDamageCalculateFunction(Damage.QDamage);
            W.SetCustomDamageCalculateFunction(Damage.WDamage);
            E.SetCustomDamageCalculateFunction(Damage.EDamage);
            R.SetCustomDamageCalculateFunction(Damage.RDamage);
        }
    }
}