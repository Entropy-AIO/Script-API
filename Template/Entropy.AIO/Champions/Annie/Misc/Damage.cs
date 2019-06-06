namespace Entropy.AIO.Champions.Annie.Misc
{
    using SDK.Damage;
    using SDK.Extensions.Objects;
    using static Bases.ChampionBase;

    class Damage
    {
        private static readonly float[] QBaseDamage = {0f, 80f, 115f, 150f, 185f, 220f};
        private static readonly float[] WBaseDamage = {0f, 70f, 115f, 160f, 205f, 250f};
        private static readonly float[] EBaseDamage = {0f, 20f, 30f, 40f, 50f, 60f};
        private static readonly float[] RBaseDamage = {0f, 150f, 275f, 400f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;

            var qBaseDamage = QBaseDamage[qLevel] +
                              0.8f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;

            var wBaseDamage = WBaseDamage[wLevel] +
                              0.85f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, wBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;

            var eBaseDamage = EBaseDamage[eLevel] +
                              0.2f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, eBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;

            var rBaseDamage = RBaseDamage[rLevel] +
                              0.65f * LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
    }
}