namespace Entropy.AIO.Champions.Ashe
{
    using SDK.Events;
    using SDK.Orbwalking;

    class Methods
    {
        private static readonly CustomTick CustomTick = new CustomTick(2000);

        public Methods()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Tick.OnTick                      += Ashe.OnTick;
            CustomTick.OnTick                += Ashe.OnCustomTick;
            Game.OnWndProc                   += Ashe.OnWndProc;
            Orbwalker.OnPreAttack            += Ashe.OnPreAttack;
            Gapcloser.OnNewGapcloser         += Ashe.OnNewGapcloser;
            Interrupter.OnInterruptableSpell += Ashe.OnInterruptableSpell;
            Game.OnEnd                       += OnEnd;
        }

        private static void OnEnd(GameEndEventArgs args)
        {
            Game.OnWndProc -= Ashe.OnWndProc;
        }
    }
}