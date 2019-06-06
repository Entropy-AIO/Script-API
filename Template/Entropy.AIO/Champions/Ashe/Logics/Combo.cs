using Entropy.SDK.Enumerations;
using Entropy.SDK.Orbwalking;

namespace Entropy.AIO.Champions.Ashe.Logics
{
    using SDK.Orbwalking.EventArgs;
    using SDK.TS;
    using static Components;
    using static Bases.ChampionBase;

    static class Combo
    {
        public static void ExecuteQ(OnPreAttackEventArgs args)
        {
            if (!ComboMenu.QBool.Enabled)
            {
                return;
            }

            var heroTarget = args.Target as AIHeroClient;

            if (heroTarget == null)
            {
                return;
            }

            Q.Cast();
        }

        public static void ExecuteW()
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return;
            }

            var target = TargetSelector.GetBestTarget(W.Range);

            if (target == null)
            {
                return;
            }

            if (Orbwalker.IsWindingUp)
            {
                return;
            }

            var pred = W.GetPrediction(target);
            if (pred.HitChance < HitChance.Low)
            {
                return;
            }

            W.Cast(pred.CastPosition);
        }
    }
}