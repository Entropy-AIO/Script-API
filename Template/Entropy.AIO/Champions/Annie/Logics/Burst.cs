namespace Entropy.AIO.Champions.Annie.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;
    using SDK.TS;
    using static Bases.ChampionBase;
    using static Components.BurstMenu;
    using static Misc.Definitions;
    using static Spells;

    static class Burst
    {
        public static void Execute()
        {
            if (!BurstKey.Enabled)
            {
                if (BurstTarget != null)
                {
                    BurstTarget = null;
                }

                return;
            }

            Orbwalker.Move(Hud.CursorPositionClipped);

            StackE();

            if (StunBool.Enabled && !HasStun)
            {
                return;
            }

            ExecuteBurst();
        }

        public static void CacheBurstableEnemies()
        {
            BurstableEnemies = ObjectCache.EnemyHeroes.Where(x => x.IsValidTarget(Flash.Range + R.Range)).
                                           Where(x => x.HP < R.GetDamage(x) + W.GetDamage(x) + Q.GetDamage(x)).
                                           ToList();
        }

        private static void StackE()
        {
            if (!EStackBool.Enabled)
            {
                return;
            }

            if (E.Ready && !HasStun && BurstTarget == null && !HasTibbers)
            {
                E.Cast();
            }
        }

        private static void ExecuteBurst()
        {
            if (!R.Ready || !Flash.Ready || LocalPlayer.Instance.HasBuff("AnnieRController"))
            {
                return;
            }

            //Flash+ Full Combo
            if (BurstMode.Value == 0 && (!W.Ready || !Q.Ready))
            {
                return;
            }

            var targ = TargetSelector.GetBestTarget(Flash.Range + W.Range);

            if (targ == null)
            {
                return;
            }

            BurstTarget = targ;

            var castPos = R.GetPrediction(BurstTarget).CastPosition;

            if (castPos.IsZero)
            {
                return;
            }

            var flashPos =
                LocalPlayer.Instance.Position.Extend(castPos, Flash.Range);

            if (BurstTarget.DistanceToPlayer() > R.Range + BurstTarget.BoundingRadius)
            {
                Flash.Cast(flashPos);
            }

            R.Cast(castPos);
        }

        public static void OnFinishCast(AIBaseClientCastEventArgs args)
        {
            if (!args.Caster.IsMe())
            {
                return;
            }

            if (!BurstKey.Enabled || BurstMode.Value != 0)
            {
                return;
            }

            if (BurstTarget == null)
            {
                return;
            }


            switch (args.Slot)
            {
                case SpellSlot.R:
                    Q.Cast(BurstTarget);
                    break;
                case SpellSlot.Q:
                    W.Cast(BurstTarget);
                    BurstTarget = null;
                    break;
            }
        }
    }
}