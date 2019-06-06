namespace Entropy.AIO.Champions._Template.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Extensions.Objects;
    using static Bases.ChampionBase;
    using static Components.KillStealMenu;

    static class KillSteal
    {
        public static void Execute()
        {
            if (Q.Ready)
            {
                ExecuteQ();
            }

            if (W.Ready)
            {
                ExecuteW();
            }

            if (E.Ready)
            {
                ExecuteE();
            }
        }

        private static void ExecuteQ()
        {
            if (!QBool.Enabled)
            {
                return;
            }

            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     Q.CanExecute(t)          &&
                                                                     t.IsValidTarget(Q.Range) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: Q.GetDamage(t))))
            {
                Q.Cast(target);
                return;
            }
        }

        private static void ExecuteW()
        {
            if (!WBool.Enabled)
            {
                return;
            }

            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     W.CanExecute(t)          &&
                                                                     t.IsValidTarget(W.Range) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: W.GetDamage(t))))
            {
                W.Cast(target);
                return;
            }
        }

        private static void ExecuteE()
        {
            if (!EBool.Enabled)
            {
                return;
            }

            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     E.CanExecute(t)          &&
                                                                     t.IsValidTarget(E.Range) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: E.GetDamage(t))))
            {
                E.Cast(target);
                return;
            }
        }
    }
}