namespace Entropy.AIO.Champions._Template.Logics
{
    using SDK.TS;
    using static Bases.ChampionBase;
    using static Components.ComboMenu;

    static class Combo
    {
        public static void Execute()
        {
            ExecuteQ();
            ExecuteW();
            ExecuteE();
            ExecuteR();
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

        private static void ExecuteE()
        {
            if (!EBool.Enabled)
            {
                return;
            }

            var eTarget = TargetSelector.GetBestTarget(E.Range);

            if (eTarget == null)
            {
                return;
            }

            E.Cast(eTarget);
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

            R.Cast(rTarget);
        }
    }
}