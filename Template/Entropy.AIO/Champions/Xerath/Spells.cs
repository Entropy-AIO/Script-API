namespace Entropy.AIO.Champions.Xerath
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
            Q = new Spell(SpellSlot.Q, 750 + LocalPlayer.Instance.BoundingRadius * 2);
            W = new Spell(SpellSlot.W, 1000);
            E = new Spell(SpellSlot.E, 1050);
            R = new Spell(SpellSlot.R);

            Q.SetSkillshot(0.6f, 85f, float.MaxValue, collision: false);
            Q.SetCharged("XerathArcanopulseChargeUp",
                         "XerathArcanopulseChargeUp",
                         750,
                         1550,
                         1.5f);


            W.SetSkillshot(0.8f, 125f, float.MaxValue, SkillshotType.Circle, false, boundingRadiusMod: false);
            E.SetSkillshot(0.25f, 60f, 1400f);
            R.SetSkillshot(0.75f, 190f, float.MaxValue, SkillshotType.Circle, false, HitChance.Medium, false);

            Q.SetCustomDamageCalculateFunction(Damage.QDamage);
            W.SetCustomDamageCalculateFunction(Damage.WDamage);
            E.SetCustomDamageCalculateFunction(Damage.EDamage);
            R.SetCustomDamageCalculateFunction(Damage.RDamage);
        }
    }
}