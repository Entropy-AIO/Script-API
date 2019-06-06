namespace Entropy.AIO.Champions.Annie.Logics
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
            if (R.Ready)
            {
                ExecuteR();
            }

            if (W.Ready)
            {
                ExecuteW();
            }

            if (Q.Ready)
            {
                ExecuteQ();
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

        private static void ExecuteR()
        {
            if (!RBool.Enabled)
            {
                return;
            }

            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     R.CanExecute(t)          &&
                                                                     t.IsValidTarget(R.Range) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: R.GetDamage(t))))
            {
                R.Cast(target);
                return;
            }
        }
    }
}