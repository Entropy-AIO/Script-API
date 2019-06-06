namespace Entropy.AIO.Champions.Xerath.Logics
{
    using System.Linq;
    using Misc;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Extensions.Objects;
    using static Bases.ChampionBase;

    static class Killsteal
    {
        public static void ExecuteQ()
        {
            if (!Q.IsCharging)
            {
                return;
            }

            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     t.IsValidTarget(Q.ChargedMaxRange)                    &&
                                                                     Q.GetDamage(t) >= t.GetRealHealth(DamageType.Magical) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: Q.GetDamage(t))))
            {
                Definitions.QChargeCasting(target);

                break;
            }
        }

        public static void ExecuteW()
        {
            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     t.IsValidTarget(W.Range)                              &&
                                                                     W.GetDamage(t) >= t.GetRealHealth(DamageType.Magical) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: W.GetDamage(t))))
            {
                W.Cast(target);
                break;
            }
        }

        public static void ExecuteE()
        {
            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     t.IsValidTarget(E.Range)                              &&
                                                                     E.GetDamage(t) >= t.GetRealHealth(DamageType.Magical) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: E.GetDamage(t))))
            {
                E.Cast(target);
                break;
            }
        }
    }
}