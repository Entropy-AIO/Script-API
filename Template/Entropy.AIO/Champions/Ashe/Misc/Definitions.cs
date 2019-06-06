namespace Entropy.AIO.Champions.Ashe.Misc
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;

    class Definitions
    {
        public static bool CanAttackAnyHero
            => Orbwalker.CanAttack() && ObjectCache.EnemyHeroes.Any(x => x.IsValidAutoAttackRange());

        public static bool CanAttackAnyMinion
            => Orbwalker.CanAttack() && ObjectCache.EnemyLaneMinions.Any(x => x.IsValidAutoAttackRange());

        public static bool CanAttackTurret
            => Orbwalker.CanAttack() && ObjectCache.EnemyTurrets.Any(x => x.IsValidAutoAttackRange());
    }
}