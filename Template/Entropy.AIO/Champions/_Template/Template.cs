namespace Entropy.AIO.Champions._Template
{
    using Bases;
    using Logics;
    using SDK.Enumerations;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;

    sealed class Template : ChampionBase
    {
        public Template()
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
        }
    }
}