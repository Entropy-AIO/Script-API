namespace Entropy.AIO.Champions._Template.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Objects;
    using Utility;
    using static Bases.ChampionBase;
    using static Components.LastHitMenu;

    static class LastHit
    {
        public static void Execute()
        {
            ExecuteQ();
            ExecuteW();
            ExecuteE();
        }

        private static void ExecuteQ()
        {
            if (!QSliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < ManaManager.GetNeededMana(Q.Slot, QSliderBool))
            {
                return;
            }

            var qTarget = ObjectCache.EnemyLaneMinions.FirstOrDefault(x => x.IsValidTarget(Q.Range));

            if (qTarget == null)
            {
                return;
            }

            if (!Q.CanExecute(qTarget))
            {
                return;
            }

            Q.Cast(qTarget);
        }

        private static void ExecuteW()
        {
            if (!WSliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < ManaManager.GetNeededMana(W.Slot, WSliderBool))
            {
                return;
            }

            var wTarget = ObjectCache.EnemyLaneMinions.FirstOrDefault(x => x.IsValidTarget(W.Range));

            if (wTarget == null)
            {
                return;
            }

            if (!W.CanExecute(wTarget))
            {
                return;
            }

            W.Cast(wTarget);
        }

        private static void ExecuteE()
        {
            if (!ESliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < ManaManager.GetNeededMana(E.Slot, ESliderBool))
            {
                return;
            }

            var eTarget = ObjectCache.EnemyLaneMinions.FirstOrDefault(x => x.IsValidTarget(E.Range));

            if (eTarget == null)
            {
                return;
            }

            if (!E.CanExecute(eTarget))
            {
                return;
            }

            E.Cast(eTarget);
        }
    }
}