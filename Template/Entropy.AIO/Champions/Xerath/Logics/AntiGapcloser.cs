namespace Entropy.AIO.Champions.Xerath.Logics
{
    using System.Collections.Generic;
    using System.Linq;
    using SDK.Events;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using SDK.Prediction;
    using SharpDX;
    using static Components;
    using static Bases.ChampionBase;

    static class AntiGapcloser
    {
        public static void ExecuteE(Gapcloser.GapcloserArgs args)
        {
            if (!GapCloserMenu.EGapcloser.IsEnabled(args.SpellName))
            {
                return;
            }

            if (args.EndPosition.DistanceToPlayer() > args.StartPosition.DistanceToPlayer())
            {
                return;
            }

            var Input = new OKTWPrediction.PredictionInput
            {
                Aoe       = false,
                Collision = E.Collision,
                Speed     = E.Speed,
                Delay     = E.Delay,
                Range     = E.Range,
                From      = LocalPlayer.Instance.Position,
                Radius    = E.Width,
                Unit      = args.Sender,
                Type      = OKTWPrediction.SkillshotType.SkillshotLine
            };

            var list = new List<Vector3>();
            list.Add(LocalPlayer.Instance.Position);
            list.Add(args.EndPosition);
            switch (args.Type)
            {
                case SpellType.Targeted when args.Target.IsMe():
                case SpellType.Dash when args.EndPosition.DistanceToPlayer() <= LocalPlayer.Instance.GetAutoAttackRange():
                    if (!OKTWPrediction.Collision.GetCollision(list, Input).Any())
                    {
                        return;
                    }

                    E.Cast(args.EndPosition);
                    break;
            }
        }
    }
}