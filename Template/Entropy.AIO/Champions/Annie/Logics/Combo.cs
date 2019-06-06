using Entropy.SDK.Extensions.Objects;

namespace Entropy.AIO.Champions.Annie.Logics
{
    using SDK.TS;
    using static Bases.ChampionBase;
    using static Components.ComboMenu;

    static class Combo
    {
        public static void Execute()
        {
            if (R.Ready)
            {
                ExecuteR();
            }

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
            if (!QBool.Enabled)
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
            if (!WBool.Enabled)
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

        private static void ExecuteR()
        {
            if (!RBool.Enabled)
            {
                return;
            }

            var rTarget = TargetSelector.GetBestTarget(R.Range);

            if (rTarget == null)
            {
                return;
            }

            if (RCountBool.Enabled &&
                rTarget.EnemyHeroesCount(290) < RCountBool.Value)
            {
                return;
            }

            R.Cast(rTarget);
        }
    }
}