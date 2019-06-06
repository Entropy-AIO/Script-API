using Entropy.SDK.Orbwalking;

namespace Entropy.AIO.Champions.Ashe.Logics
{
    using System.Linq;
    using SDK.Caching;
    using SDK.Extensions.Objects;
    using SDK.TS;
    using Utility;
    using static Components;
    using static Bases.ChampionBase;

    class Automatic
    {
        public static void SemiAutomaticR(GameWndProcEventArgs args)
        {
            switch (args.Message)
            {
                case WindowMessage.KEYFIRST:
                    if (R.Ready)
                    {
                        ExecuteSemiAutomaticR();
                    }

                    break;
            }
        }

        private static void ExecuteSemiAutomaticR()
        {
            var rTarget = R.GetSemiAutoTarget(DamageType.Magical, ComboMenu.RWhitelist);
            if (rTarget == null)
            {
                return;
            }

            R.Cast(rTarget);
        }

        internal static void ExecuteW()
        {
            var WMenu = AutomaticMenu.WSliderBool;

            //Returning if execution menu is not enabled
            if (!WMenu.Enabled)
            {
                return;
            }

            //Returning if mana percent is lower or equal execution menu value
            if (ManaManager.GetNeededMana(SpellSlot.W, WMenu) > LocalPlayer.Instance.MPPercent())
            {
                return;
            }

            var wTarget = TargetSelector.GetBestTarget(W.Range);

            //Returning if target equals null
            if (wTarget == null)
            {
                return;
            }

            if (Orbwalker.IsWindingUp)
            {
                return;
            }

            //Returning if target is not whitelisted
            if (!AutomaticMenu.WWhitelist.IsWhitelisted(wTarget))
            {
                return;
            }

            W.Cast(wTarget);
        }

        internal static void OnImmobile()
        {
            //Returning if execution menu is not enabled
            if (!AutomaticMenu.RImmobile.Enabled)
            {
                return;
            }

            //Getting first target that is a valid target in R custom range + target's bounding radius who is immobile
            var target = ObjectCache.EnemyHeroes.FirstOrDefault(
                x => x.IsValidTarget(AutomaticMenu.RRange.Value + x.BoundingRadius) && x.IsImmobile());

            //Returning if target equals null
            if (target == null)
            {
                return;
            }

            //Casting R
            R.Cast(target.Position);
        }
    }
}