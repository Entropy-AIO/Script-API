namespace Entropy.AIO.Champions.Xerath.Logics
{
    using System.Linq;
    using Misc;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Extensions;
    using SDK.Extensions.Objects;
    using Utility;
    using static Components;
    using static Bases.ChampionBase;

    static class JungleClear
    {
        public static void ExecuteQ()
        {
            if (!JungleClearMenu.QBool.Enabled)
            {
                return;
            }

            var target = ObjectCache.JungleMinions.Where(m => m.IsValidTarget(Q.ChargedMaxRange)).MaxBy(h => h.MaxHP);

            if (target == null)
            {
                return;
            }

            Definitions.QChargeCasting(target);
        }

        public static void ExecuteW()
        {
            if (!JungleClearMenu.WBool.Enabled)
            {
                return;
            }


            var target = Extensions.GetGenericJungleMinionsTargetsInRange(W.Range).MaxBy(h => h.MaxHP);

            if (target == null)
            {
                return;
            }

            if (target.IsValidAutoAttackRange() && target.HP <= LocalPlayer.Instance.GetAutoAttackDamage(target) * 3)
            {
                return;
            }

            W.Cast(target);
        }

        public static void ExecuteE()
        {
            if (!JungleClearMenu.EBool.Enabled)
            {
                return;
            }

            var target = ObjectCache.JungleMinions.Where(m => m.IsValidTarget(E.Range)).MaxBy(h => h.MaxHP);

            if (target == null)
            {
                return;
            }

            E.Cast(target);
        }
    }
}