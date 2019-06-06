using Entropy.SDK.Enumerations;

namespace Entropy.AIO.Champions.Ashe.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Extensions.Objects;
    using static Components;
    using static Bases.ChampionBase;

    public static class Killsteal
    {
        public static void ExecuteR()
        {
            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     t.IsValidTarget(AutomaticMenu.RRange.Value)           &&
                                                                     R.GetDamage(t) >= t.GetRealHealth(DamageType.Magical) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: R.GetDamage(t))))
            {
                R.Cast(target);
                return;
            }
        }

        public static void ExecuteW()
        {
            foreach (var target in ObjectCache.EnemyHeroes.Where(t =>
                                                                     t.IsValidTarget(W.Range)                               &&
                                                                     W.GetDamage(t) >= t.GetRealHealth(DamageType.Physical) &&
                                                                     !Invulnerable.IsInvulnerable(t, damage: W.GetDamage(t))))
            {
                var pred = W.GetPrediction(target);
                if (pred.HitChance < HitChance.Low)
                {
                    return;
                }

                W.Cast(pred.CastPosition);
            }
        }
    }
}