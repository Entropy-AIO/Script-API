namespace Entropy.AIO.Champions.Xerath
{
    using SDK.Events;
    using SDK.Orbwalking;

    class Methods
    {
        public Methods()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Tick.OnTick                      += Xerath.OnTick;
            Game.OnWndProc                   += Xerath.OnWndProc;
            Orbwalker.OnPreMove              += Xerath.OnPreMove;
            Gapcloser.OnNewGapcloser         += Xerath.OnNewGapcloser;
            Spellbook.OnLocalCastSpell       += Xerath.OnLocalCastSpell;
            Interrupter.OnInterruptableSpell += Xerath.OnInterruptableSpell;
            AIBaseClient.OnProcessSpellCast  += Xerath.OnProcessCast;
            Game.OnEnd                       += OnEnd;
        }

        private static void OnEnd(GameEndEventArgs args)
        {
            Game.OnWndProc -= Xerath.OnWndProc;
        }
    }
}