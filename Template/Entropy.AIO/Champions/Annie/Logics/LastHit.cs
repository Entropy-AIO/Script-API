namespace Entropy.AIO.Champions.Annie.Logics
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
            if (Q.Ready)
            {
                ExecuteQ();
            }
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

            //TODO Better calcs with HP Pred
            if (!Q.CanExecute(qTarget))
            {
                return;
            }

            Q.Cast(qTarget);
        }
    }
}