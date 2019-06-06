namespace Entropy.AIO.Champions.Annie
{
    using Bases;
    using Logics;
    using SDK.Enumerations;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;
    using ToolKit;
    using static SDK.Events.Gapcloser;
    using static SDK.Events.Interrupter;

    sealed class Annie : ChampionBase
    {
        public Annie()
        {
            new Spells();
            new Menus();
            new Methods();
            new Drawings(Q, W, E, R);
        }

        public static void OnTick(EntropyEventArgs args)
        {
            if (LocalPlayer.Instance.IsDead() || LocalPlayer.Instance.IsRecalling() || GameConsole.IsOpen)
            {
                return;
            }

            switch (Orbwalker.Mode)
            {
                case OrbwalkingMode.Combo:
                    Combo.Execute();
                    break;
                case OrbwalkingMode.Harass:
                    Harass.Execute();
                    break;
                case OrbwalkingMode.Laneclear:
                    LaneClear.Execute();
                    JungleClear.Execute();
                    break;
                case OrbwalkingMode.Lasthit:
                    LastHit.Execute();
                    break;
            }
        }

        public static void OnCustomTick(EntropyEventArgs args)
        {
            KillSteal.Execute();
            Burst.Execute();
        }

        public static void OnNewGapCloser(GapcloserArgs args)
        {
            GapCloser.Execute(args);
        }

        public static void OnInterruptableSpell(AIBaseClient sender, InterruptableSpellEventArgs args)
        {
            InterrupterEvent.Execute(args);
        }

        public static void OnSlowCustomTick(EntropyEventArgs args)
        {
            Burst.CacheBurstableEnemies();
        }
    }
}