namespace Entropy.AIO.Champions.Xerath.Misc
{
    using SDK.Damage;
    using SDK.Extensions.Objects;
    using static Bases.ChampionBase;

    static class Damage
    {
        private static readonly float[] QBaseDamage = {0, 80, 120, 160, 200, 240};
        private static readonly float[] WBaseDamage = {0, 60, 90, 120, 150, 180};
        private static readonly float[] EBaseDamage = {0, 80, 110, 140, 170, 200};
        private static readonly float[] RBaseDamage = {0, 200, 240, 280};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;

            var qBaseDamage = QBaseDamage[qLevel] +
                              0.75f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;

            var wBaseDamage = WBaseDamage[wLevel] +
                              0.6f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, wBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;

            var eBaseDamage = EBaseDamage[eLevel] +
                              0.45f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, eBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;

            var ammoCount = rLevel == 3 ? 5 : rLevel == 2 ? 4 : 3;

            var rBaseDamage = RBaseDamage[rLevel] +
                              0.43f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, rBaseDamage) * ammoCount;
        }
    }
}