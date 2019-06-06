using Entropy.SDK.Extensions.Geometry;

namespace Entropy.AIO.Champions.Annie.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Objects;
    using Utility;
    using static Bases.ChampionBase;
    using static Components.LaneClearMenu;

    static class LaneClear
    {
        public static void Execute()
        {
            if (Q.Ready)
            {
                ExecuteQ();
            }

            if (W.Ready)
            {
                ExecuteW();
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

            var qTarget = QKillable.Enabled
                ? ObjectCache.EnemyLaneMinions.Where(x => x.IsValidTarget(Q.Range)).FirstOrDefault(x => Q.CanExecute(x))
                : ObjectCache.EnemyLaneMinions.FirstOrDefault(x => x.IsValidTarget(Q.Range));

            if (qTarget == null)
            {
                return;
            }

            Q.Cast(qTarget);
        }

        public static int GetMinionsInX(this AIBaseClient target, float range)
        {
            var count = 0;
            foreach (var minion in ObjectCache.EnemyLaneMinions.Where(x => x.IsValidTarget(W.Range - 50)))
            {
                if (target.Distance(minion) <= range)
                {
                    count++;
                }
            }

            return count;
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


            var wTarget = ObjectCache.EnemyLaneMinions.FirstOrDefault(
                x => x.IsValidTarget(W.Range) &&
                     x.GetMinionsInX(200) >= WCountSliderBool.Value);

            if (wTarget == null)
            {
                return;
            }

            W.Cast(wTarget);
        }
    }
}