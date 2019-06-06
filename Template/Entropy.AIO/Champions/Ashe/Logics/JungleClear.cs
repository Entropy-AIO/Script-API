namespace Entropy.AIO.Champions.Ashe.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking.EventArgs;
    using static Components;
    using static Bases.ChampionBase;

    class JungleClear
    {
        public static void ExecuteQ(OnPreAttackEventArgs args)
        {
            if (!JungleClearMenu.QSliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < JungleClearMenu.QSliderBool.Value)
            {
                return;
            }

            var minion = args.Target as AIMinionClient;

            if (minion == null || !minion.IsValid || !minion.IsJungleMinion())
            {
                return;
            }

            Q.Cast();
        }

        public static void ExecuteW()
        {
            if (!JungleClearMenu.WSliderBool.Enabled)
            {
                return;
            }

            if (LocalPlayer.Instance.MPPercent() < JungleClearMenu.WSliderBool.Value)
            {
                return;
            }

            var minion = ObjectCache.JungleMinions.FirstOrDefault(x => x.IsValidTarget(W.Range));

            if (minion == null)
            {
                return;
            }

            W.Cast(minion);
        }
    }
}