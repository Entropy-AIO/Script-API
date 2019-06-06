namespace Entropy.AIO.Champions.Ashe.Misc
{
    using Bases;
    using SDK.Damage;
    using SDK.Extensions.Objects;

    class Damage
    {
        private static readonly float[] RBaseDamage = {0f, 200f, 400f, 600f};
        private static readonly float[] WBaseDamage = {0f, 20f, 35f, 50f, 65f, 80f};

        public static float W(AIBaseClient target)
        {
            var wLevel = ChampionBase.W.Level;

            var wBaseDamage = WBaseDamage[wLevel] +
                              LocalPlayer.Instance.TotalAttackDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Physical, wBaseDamage);
        }

        public static float R(AIBaseClient target)
        {
            var rLevel = ChampionBase.R.Level;

            var rBaseDamage = RBaseDamage[rLevel] +
                              LocalPlayer.Instance.TotalAbilityDamage();

            return LocalPlayer.Instance.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
    }
}