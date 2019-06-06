namespace Entropy.AIO.Champions.Xerath.Logics
{
    using SDK.Enumerations;
    using SDK.Extensions.Geometry;
    using SDK.TS;
    using static Components;
    using static Bases.ChampionBase;

    static class Harass
    {
        public static void ExecuteHarass()
        {
            var qTarget = TargetSelector.GetBestTarget(Q.ChargedMaxRange);
            var wTarget = TargetSelector.GetBestTarget(W.Range + W.Width * 0.5f);
            var eTarget = TargetSelector.GetBestTarget(E.Range);


            if (ComboMenu.QBool.Enabled && Q.Ready && qTarget != null)
            {
                if (Q.IsCharging)
                {
                    var pred = Q.GetPrediction(qTarget);
                    if (
                        pred.HitChance >= HitChance.Medium)
                    {
                        Q.ShootChargedSpell(pred.CastPosition, extraRange: ComboMenu.QCharge.Value);
                    }
                }
                else if (!ComboMenu.WBool.Enabled || !W.Ready || qTarget.DistanceToPlayer() > W.Range)
                {
                    Q.StartCharging(Hud.CursorPositionUnclipped);
                }
            }

            if (wTarget != null && ComboMenu.WBool.Enabled && W.Ready)
            {
                W.Cast(wTarget);
            }
        }
    }
}