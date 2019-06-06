namespace Entropy.AIO.Champions.Annie.Logics
{
    using SDK.Extensions.Objects;
    using SDK.TS;
    using Utility;
    using static Bases.ChampionBase;
    using static Components.HarassMenu;

    static class Harass
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

            var qTarget = TargetSelector.GetBestTarget(Q.Range);

            if (qTarget == null)
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

            var wTarget = TargetSelector.GetBestTarget(W.Range);

            if (wTarget == null)
            {
                return;
            }

            W.Cast(wTarget);
        }
    }
}