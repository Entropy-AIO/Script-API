namespace Entropy.AIO.Champions.Annie.Logics
{
    using static Bases.ChampionBase;
    using static Components.InterrupterMenu;
    using static Misc.Definitions;
    using static SDK.Events.Interrupter;

    static class InterrupterEvent
    {
        public static void Execute(InterruptableSpellEventArgs args)
        {
            if (!HasStun)
            {
                return;
            }

            if (!Interrupter.IsEnabled(args.SpellName))
            {
                return;
            }

            if (R.Ready && RBool.Enabled)
            {
                R.Cast(args.Sender);
                return;
            }

            if (W.Ready && WBool.Enabled)
            {
                W.Cast(args.Sender);
                return;
            }

            if (Q.Ready && QBool.Enabled)
            {
                Q.Cast(args.Sender);
            }
        }
    }
}