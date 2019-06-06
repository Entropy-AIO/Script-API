namespace Entropy.AIO.Champions.Annie.Logics
{
    using SDK.Events;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using static Bases.ChampionBase;
    using static Components.AntiGapCloserMenu;
    using static Misc.Definitions;
    using static SDK.Events.Gapcloser;

    static class GapCloser
    {
        public static void Execute(GapcloserArgs args)
        {
            if (StunBool.Enabled && !HasStun)
            {
                return;
            }

            if (!AntiGapCloser.IsEnabled(args.SpellName))
            {
                return;
            }

            if (W.Ready)
            {
                ExecuteW(args);
                return;
            }

            if (Q.Ready)
            {
                ExecuteQ(args);
            }
        }

        private static void ExecuteQ(GapcloserArgs args)
        {
            if (!QBool.Enabled)
            {
                return;
            }

            switch (args.Type)
            {
                case SpellType.Targeted when args.Target.IsMe():
                case SpellType.Dash when args.EndPosition.DistanceToPlayer() < Q.Range:
                    Q.Cast(args.Sender);
                    break;
            }
        }

        private static void ExecuteW(GapcloserArgs args)
        {
            if (!WBool.Enabled)
            {
                return;
            }

            switch (args.Type)
            {
                case SpellType.Targeted when args.Target.IsMe():
                case SpellType.Dash when args.EndPosition.DistanceToPlayer() < W.Range:
                    W.Cast(args.Sender);
                    break;
            }
        }
    }
}