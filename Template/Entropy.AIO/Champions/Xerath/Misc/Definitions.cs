namespace Entropy.AIO.Champions.Xerath.Misc
{
    using SDK.Enumerations;
    using SDK.Extensions.Objects;
    using SDK.Utils;
    using SharpDX;
    using static Bases.ChampionBase;

    static class Definitions
    {
        private static readonly float[] Ranges = {3020, 4340, 5660};

        public static int     LastPingT;
        public static Vector3 PingLocation;

        public static bool IsChannellingR
            => LocalPlayer.Instance.HasBuff("XerathLocusOfPower2");

        public static float GetRRange()
        {
            return Ranges[R.Level];
        }

        private static void SimplePing()
        {
            Game.ShowPing(PingLocation, PingType.Fallback, true);
        }


        public static void Ping(Vector3 position)
        {
            if (Game.TickCount - LastPingT < 30 * 1000)
            {
                return;
            }

            LastPingT    = Game.TickCount;
            PingLocation = position;
            SimplePing();

            DelayAction.Queue(SimplePing, 150);
            DelayAction.Queue(SimplePing, 300);
            DelayAction.Queue(SimplePing, 400);
            DelayAction.Queue(SimplePing, 800);
        }

        public static void QChargeCasting(AIBaseClient target)
        {
            if (!Q.IsCharging)
            {
                Q.StartCharging(Hud.CursorPositionUnclipped);
                return;
            }

            var pred = Q.GetPrediction(target);
            if (
                pred.HitChance < HitChance.Medium)
            {
                return;
            }

            Q.ShootChargedSpell(pred.CastPosition, extraRange: Components.ComboMenu.QCharge.Value);
        }

        public static void QChargeCasting(Vector3 position, bool useBonusRange = false)
        {
            if (!Q.IsCharging)
            {
                Q.StartCharging(Hud.CursorPositionUnclipped);
                return;
            }

            Q.ShootChargedSpell(position);
        }
    }
}