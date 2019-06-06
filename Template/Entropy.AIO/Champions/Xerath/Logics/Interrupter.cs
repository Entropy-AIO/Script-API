namespace Entropy.AIO.Champions.Xerath.Logics
{
    using SDK.Events;
    using SDK.Extensions.Objects;
    using static Components;
    using static Bases.ChampionBase;

    static class OnInterruptable
    {
        public static void ExecuteE(AIBaseClient sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (!InterrupterMenu.EBool.Enabled)
            {
                return;
            }

            if (!InterrupterMenu.EInterrupter.IsEnabled(args.SpellName))
            {
                return;
            }

            if (!sender.IsValidTarget(E.Range))
            {
                return;
            }

            E.Cast(sender);
        }
    }
}