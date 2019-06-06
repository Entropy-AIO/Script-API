namespace Entropy.AIO.Champions.Xerath.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Enumerations;
    using SDK.Extensions.Geometry;
    using SDK.Extensions.Objects;
    using SDK.TS;
    using static Components;
    using static Bases.ChampionBase;

    static class Combo
    {
        public static void ExecuteCombo()
        {
            var qTarget = TargetSelector.GetBestTarget(Q.ChargedMaxRange);
            var wTarget = TargetSelector.GetBestTarget(W.Range + W.Width * 0.5f);
            var eTarget = TargetSelector.GetBestTarget(E.Range);

            if (eTarget != null && ComboMenu.EBool.Enabled && E.Ready)
            {
                if (eTarget.DistanceToPlayer() < E.Range * 0.4f && ComboMenu.EWhitelist.IsWhitelisted(eTarget))
                {
                    E.Cast(eTarget);
                }
                else if (!W.Ready || !ComboMenu.WBool.Enabled)
                {
                    E.Cast(eTarget);
                }
            }

            if (ComboMenu.QBool.Enabled && Q.Ready && qTarget != null)
            {
                if (Q.IsCharging)
                {
                    var pred = Q.GetPrediction(qTarget);
                    if (
                        pred.HitChance >= HitChance.Medium)
                    {
                        Q.ShootChargedSpell(pred.CastPosition, extraRange: ComboMenu.QCharge.Value);
                    }
                }
                else if (!ComboMenu.WBool.Enabled || !W.Ready || qTarget.DistanceToPlayer() > W.Range)
                {
                    Q.StartCharging(Hud.CursorPositionUnclipped);
                }
            }

            if (wTarget != null && ComboMenu.WBool.Enabled && W.Ready)
            {
                W.Cast(wTarget);
            }
        }

        public static AIHeroClient GetTargetNearMouse(float distance)
        {
            AIHeroClient bestTarget = null;
            var          bestRatio  = 0f;

            if (TargetSelector.SelectedTarget.IsValidTarget()                                           &&
                !Invulnerable.IsInvulnerable(TargetSelector.SelectedTarget)                             &&
                Hud.CursorPositionUnclipped.Distance(TargetSelector.SelectedTarget.Position) < distance &&
                LocalPlayer.Instance.Distance(TargetSelector.SelectedTarget)                 < R.Range)
            {
                return TargetSelector.SelectedTarget;
            }

            foreach (var hero in ObjectCache.EnemyHeroes)
            {
                if (!hero.IsValidTarget(R.Range)      ||
                    Invulnerable.IsInvulnerable(hero) ||
                    Hud.CursorPositionUnclipped.Distance(hero.Position) > distance)
                {
                    continue;
                }

                var damage = LocalPlayer.Instance.CalculateDamage(hero, DamageType.Magical, 100);
                var ratio  = damage / (1 + hero.HP) * TargetSelector.OrderedTargets.IndexOf(hero) + 1;

                if (ratio > bestRatio)
                {
                    bestRatio  = ratio;
                    bestTarget = hero;
                }
            }

            return bestTarget;
        }


        public static void WhileCastingR()
        {
            if (!RSettings.RBool.Enabled)
            {
                return;
            }

            var rMode = RSettings.RMode.Value;

            var rTarget = RSettings.FocusMouse.Enabled
                ? GetTargetNearMouse(RSettings.MouseRange.Value)
                : TargetSelector.GetBestTargetsList(R.Range).OrderBy(x => x.HP).FirstOrDefault();
            if (rTarget != null)
            {
                //Wait at least 0.6f if the target is going to die or if the target is to far away
                if (rTarget.HP - R.GetDamage(rTarget) < 0)
                {
                    if (Game.TickCount - Xerath.RCharge.CastT <= 700)
                    {
                        return;
                    }
                }

                switch (rMode)
                {
                    case 0: //Normal
                        R.Cast(rTarget);
                        break;

                    case 1: //Selected delays.
                        var delay = RSettings.RDelay.Value;
                        if (Game.TickCount - Xerath.RCharge.CastT > delay)
                        {
                            R.Cast(rTarget);
                        }

                        break;

                    case 2: //On tap
                        if (RSettings.RSemiAutoKeyBind.Enabled)
                        {
                            R.Cast(rTarget);
                        }

                        break;
                }
            }
        }
    }
}