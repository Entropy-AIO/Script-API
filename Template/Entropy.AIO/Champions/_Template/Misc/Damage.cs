namespace Entropy.AIO.Champions._Template.Misc
{
    using SDK.Damage;
    using SDK.Extensions.Objects;
    using static Bases.ChampionBase;

    static class Damage
    {
        private static readonly float[] QBaseDamage = {0f, 57f, 120f, 165f, 210f, 255f};
        private static readonly float[] WBaseDamage = {0f, 57f, 120f, 165f, 210f, 255f};
        private static readonly float[] EBaseDamage = {0f, 57f, 120f, 165f, 210f, 255f};
        private static readonly float[] RBaseDamage = {0f, 75f, 100f, 125f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;

            var qBaseDamage = QBaseDamage[qLevel]                               +
                              0.5f * LocalPlayer.Instance.BonusPhysicalDamage() +
                              0.5f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;

            var wBaseDamage = WBaseDamage[wLevel]                               +
                              0.5f * LocalPlayer.Instance.BonusPhysicalDamage() +
                              0.5f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, wBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;

            var eBaseDamage = EBaseDamage[eLevel]                               +
                              0.5f * LocalPlayer.Instance.BonusPhysicalDamage() +
                              0.5f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, eBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;

            var rBaseDamage = RBaseDamage[rLevel]                      +
                              LocalPlayer.Instance.TotalAttackDamage() +
                              0.2f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
    }
}