namespace Entropy.AIO.Champions.Xerath.Logics
{
    using Utility;
    using static Components;
    using static Bases.ChampionBase;

    static class Automatic
    {
        public static void SemiAutomaticE()
        {
            if (!ComboMenu.EBool.Enabled)
            {
                return;
            }

            var eTarget = E.GetSemiAutoTarget(DamageType.Magical, ComboMenu.EWhitelist);
            if (eTarget == null)
            {
                return;
            }


            E.Cast(eTarget);
        }

        public static void SemiAutomaticR()
        {
            //if (!RSettings.RBool.Enabled)
            //{
            //    return;
            //}

            //if (!Definitions.IsChannellingR)
            //{
            //    return;
            //}

            //var rTarget = RSettings.FocusMouse.Enabled
            //    ? TargetSelector.GetBestTargetsList(R.Range).
            //                     OrderBy(x => x.HP).
            //                     FirstOrDefault(x => RSettings.RWhitelist.IsWhitelisted(x) &&
            //                                         x.Distance(Hud.CursorPositionUnclipped) <
            //                                         RSettings.MouseRange.Value)
            //    : R.GetSemiAutoTarget(DamageType.Magical, RSettings.RWhitelist);

            //if (rTarget != null)
            //{
            //    var Input = new AIOPredictions.PredictionInput
            //    {
            //        Aoe       = false,
            //        Collision = R.Collision,
            //        Speed     = R.Speed,
            //        Delay     = R.Delay,
            //        Range     = R.Range,
            //        From      = LocalPlayer.Instance.Position,
            //        Radius    = R.Width,
            //        Unit      = rTarget,
            //        Type      = AIOPredictions.SkillshotType.SkillshotCircle,
            //        UseBoundingRadius = false

            //    };
            //    var pred = AIOPredictions.Prediction.GetPrediction(Input);

            //    if (pred.Hitchance < AIOPredictions.HitChance.Medium)
            //    {
            //        return;
            //    }

            //    Logging.Log(pred.Input.UseBoundingRadius.ToString());
            //    R.Cast(pred.CastPosition);
            //}
        }
    }
}