namespace Entropy.AIO.Champions.Xerath.Logics
{
    using System.Linq;
    using Misc;
    using SDK.Caching;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using static Components;
    using static Bases.ChampionBase;

    static class LaneClear
    {
        public static void ExecuteW()
        {
            if (!LaneClearMenu.WBool.Enabled)
            {
                return;
            }

            var minions      = ObjectCache.EnemyLaneMinions.Where(m => m.IsValidTarget(W.Range));
            var farmLocation = W.GetCircularFarmLocation(minions, 250);

            if (farmLocation.MinionsHit < LaneClearMenu.hitsW.Value)
            {
                return;
            }

            W.Cast(farmLocation.Position);
        }

        public static void ExecuteQ()
        {
            if (!LaneClearMenu.QBool.Enabled)
            {
                return;
            }

            var minions      = ObjectCache.EnemyLaneMinions.Where(m => m.IsValidTarget(Q.ChargedMaxRange));
            var farmLocation = Q.GetLineFarmLocation(minions, 70);

            if (farmLocation.MinionsHit < LaneClearMenu.hitsQ.Value)
            {
                return;
            }

            Definitions.QChargeCasting(farmLocation.Position.To3D());
        }
    }
}