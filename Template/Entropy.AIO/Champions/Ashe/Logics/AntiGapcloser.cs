namespace Entropy.AIO.Champions.Ashe.Logics
{
    using SDK.Events;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using static Components;
    using static Bases.ChampionBase;

    class AntiGapcloser
    {
        public static void ExecuteR(Gapcloser.GapcloserArgs args)
        {
            if (!GapCloserMenu.RBool.Enabled)
            {
                return;
            }

            if (!GapCloserMenu.RGapcloser.IsEnabled(args.SpellName))
            {
                return;
            }

            if (args.EndPosition.DistanceToPlayer() > args.StartPosition.DistanceToPlayer())
            {
                return;
            }

            switch (args.Type)
            {
                case SpellType.Targeted when args.Target.IsMe():
                case SpellType.Dash when args.EndPosition.DistanceToPlayer() <= LocalPlayer.Instance.GetAutoAttackRange():
                    R.Cast(args.Sender);
                    break;
            }
        }
    }
}