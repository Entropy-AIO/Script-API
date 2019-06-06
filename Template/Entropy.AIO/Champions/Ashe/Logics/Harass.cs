using Entropy.SDK.Enumerations;
using Entropy.SDK.Orbwalking;

namespace Entropy.AIO.Champions.Ashe.Logics
{
    using System.Linq;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking.EventArgs;
    using Utility;
    using static Components;
    using static Bases.ChampionBase;

    static class Harass
    {
        public static void ExecuteQ(OnPreAttackEventArgs args)
        {
            if (!HarassMenu.QSliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < ManaManager.GetNeededMana(Q.Slot, HarassMenu.QSliderBool))
            {
                return;
            }

            var heroTarget = args.Target as AIHeroClient;

            if (heroTarget == null)
            {
                return;
            }

            if (!HarassMenu.QWhitelist.IsWhitelisted(heroTarget))
            {
                return;
            }

            Q.Cast();
        }

        public static void ExecuteW()
        {
            if (!HarassMenu.WSliderBool.Enabled)
            {
                return;
            }

            if (Orbwalker.IsWindingUp)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < ManaManager.GetNeededMana(W.Slot, HarassMenu.WSliderBool))
            {
                return;
            }

            foreach (var target in Extensions.GetBestEnemyHeroesTargetsInRange(W.Range).
                                              Where(t => HarassMenu.WWhitelist.IsWhitelisted(t)))
            {
                var pred = W.GetPrediction(target);
                if (pred.HitChance < HitChance.Low)
                {
                    return;
                }

                W.Cast(pred.CastPosition);
                break;
            }
        }
    }
}