namespace Entropy.AIO.Champions.Ashe.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Objects;
    using static Components;
    using static Bases.ChampionBase;

    class LaneClear
    {
        public static void ExecuteQ()
        {
            if (!LaneClearMenu.QSliderBool.Enabled || !Q.Ready)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < LaneClearMenu.QSliderBool.Value)
            {
                return;
            }

            if (LocalPlayer.Instance.EnemyMinionsCount(LocalPlayer.Instance.GetAutoAttackRange()) >=
                LaneClearMenu.QCountSliderBool.Value)
            {
                Q.Cast();
            }
        }

        public static void ExecuteW()
        {
            if (!LaneClearMenu.WSliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < LaneClearMenu.WSliderBool.Value)
            {
                return;
            }

            var minion = ObjectCache.EnemyLaneMinions.FirstOrDefault(x => x.IsValidTarget(W.Range));

            if (minion == null)
            {
                return;
            }

            W.Cast(minion);
        }
    }
}