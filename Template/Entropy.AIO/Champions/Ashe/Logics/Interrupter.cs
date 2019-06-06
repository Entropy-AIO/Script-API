namespace Entropy.AIO.Champions.Ashe.Logics
{
    using SDK.Events;
    using SDK.Extensions.Objects;
    using static Components;
    using static Bases.ChampionBase;

    static class OnInterruptable
    {
        public static void ExecuteR(AIBaseClient sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (!InterrupterMenu.RBool.Enabled)
            {
                return;
            }

            if (!InterrupterMenu.RInterrupter.IsEnabled(args.SpellName))
            {
                return;
            }

            if (!sender.IsValidTarget(AutomaticMenu.RRange.Value))
            {
                return;
            }

            R.Cast(sender.Position);
        }
    }
}