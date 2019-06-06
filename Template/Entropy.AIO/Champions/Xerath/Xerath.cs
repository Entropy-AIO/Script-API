namespace Entropy.AIO.Champions.Xerath
{
    using System.Linq;
    using Bases;
    using Enumerations;
    using Logics;
    using Misc;
    using SDK.Caching;
    using SDK.Damage;
    using SDK.Enumerations;
    using SDK.Events;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;
    using SDK.Orbwalking.EventArgs;
    using SDK.Prediction;
    using SharpDX;
    using static Components;

    class Xerath : ChampionBase
    {
        public Xerath()
        {
            new Spells();
            new Menus();
            new Methods();
            new Drawings(Q, W, E, R);

            //Q.Delay = MiscellaneousMenu.QDelay.Value / 1000f;
            //Q.Speed = MiscellaneousMenu.QSpeed.Value;
            //Q.Width = MiscellaneousMenu.QWidth.Value;
        }

        public static void OnWndProc(GameWndProcEventArgs args)
        {
            if (E.Ready && args.WParam == ComboMenu.ESemiAutoKeyBind.Key)
            {
                Automatic.SemiAutomaticE();
            }

            if (R.Ready && args.WParam == RSettings.RSemiAutoKeyBind.Key)
            {
                Automatic.SemiAutomaticR();
            }
        }

        public static void OnLocalCastSpell(SpellbookLocalCastSpellEventArgs args)
        {
            if (!Enumerations.SpellSlots.Contains(args.Slot))
            {
                return;
            }

            if (Q.IsCharging && args.Slot != SpellSlot.Q)
            {
                args.Execute = false;
            }
        }

        public static void KillstealUwu()
        {
            if (W.Ready && KillstealMenu.WBool.Enabled)
            {
                Killsteal.ExecuteW();
                return;
            }

            if (Q.Ready && KillstealMenu.QBool.Enabled)
            {
                Killsteal.ExecuteQ();
                return;
            }

            if (E.Ready && KillstealMenu.EBool.Enabled)
            {
                Killsteal.ExecuteE();
            }
        }

        public static void OnTick(EntropyEventArgs args)
        {
            if (PredictionMenu.PredictionMode.Value == 2)
            {
                W.Width = 250f;
                R.Width = 190f;
            }
            else
            {
                W.Width = 500f;
                R.Width = 380f;
            }

            R.Range = 1200 * R.Level + 2000;
            if (Q.IsCharging)
            {
                Orbwalker.AttackAllowed = false;
            }
            else
            {
                Orbwalker.AttackAllowed = true;
            }

            if (RSettings.FocusMouse.Enabled)
            {
                RSettings.MouseRange.Visible = true;
            }
            else
            {
                RSettings.MouseRange.Visible = false;
            }

            if (RSettings.RMode.Value == 1)
            {
                RSettings.RDelay.Visible = true;
            }
            else
            {
                RSettings.RDelay.Visible = false;
            }


            if (RSettings.RMode.Value == 2)
            {
                RSettings.RSemiAutoKeyBind.Visible = true;
            }
            else
            {
                RSettings.RSemiAutoKeyBind.Visible = false;
            }

            if (LocalPlayer.Instance.IsDead() || ItemShop.IsOpen || GameConsole.IsOpen)
            {
                return;
            }

            KillstealUwu();

            if (R.Ready && RSettings.PingOnKill.Enabled)
            {
                foreach (var enemy in ObjectCache.EnemyHeroes.Where(x => x.IsValidTarget() && R.GetDamage(x) > x.HP))
                {
                    Definitions.Ping(enemy.Position);
                }
            }

            if (Definitions.IsChannellingR)
            {
                Combo.WhileCastingR();
            }

            switch (Orbwalker.Mode)
            {
                case OrbwalkingMode.Combo:
                    Combo.ExecuteCombo();

                    break;

                case OrbwalkingMode.Harass:
                    Harass.ExecuteHarass();

                    break;

                case OrbwalkingMode.Laneclear:
                    if (W.Ready && LaneClearMenu.farmKey.Enabled)
                    {
                        LaneClear.ExecuteW();
                        JungleClear.ExecuteW();
                    }

                    if (Q.Ready && LaneClearMenu.farmKey.Enabled)
                    {
                        LaneClear.ExecuteQ();
                        JungleClear.ExecuteQ();
                    }

                    if (E.Ready && LaneClearMenu.farmKey.Enabled)
                    {
                        JungleClear.ExecuteE();
                    }

                    break;
            }
        }

        public static void OnPreMove(OnPreMoveEventArgs args)
        {
            if (!Definitions.IsChannellingR)
            {
                return;
            }

            args.Cancel = true;
        }

        public static void OnNewGapcloser(Gapcloser.GapcloserArgs args)
        {
            if (LocalPlayer.Instance.IsDead())
            {
                return;
            }

            if (!GapCloserMenu.EBool.Enabled)
            {
                return;
            }

            var sender = args.Sender;

            if (sender == null || !sender.IsValid || !sender.IsEnemy())
            {
                return;
            }

            if (Invulnerable.IsInvulnerable(sender, false))
            {
                return;
            }

            if (E.Ready)
            {
                AntiGapcloser.ExecuteE(args);
            }
        }

        public static void OnInterruptableSpell(AIBaseClient sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (LocalPlayer.Instance.IsDead())
            {
                return;
            }

            var heroSender = sender as AIHeroClient;

            if (heroSender == null || !heroSender.IsEnemy())
            {
                return;
            }

            if (Invulnerable.IsInvulnerable(heroSender, false))
            {
                return;
            }

            if (E.Ready)
            {
                OnInterruptable.ExecuteE(sender, args);
            }
        }

        public static void OnProcessCast(AIBaseClientCastEventArgs args)
        {
            if (!args.Caster.IsMe())
            {
                return;
            }

            switch (args.SpellData.Name)
            {
                case "XerathLocusOfPower2":
                    RCharge.CastT         = 0;
                    RCharge.Index         = 0;
                    RCharge.Position      = new Vector3();
                    RCharge.TapKeyPressed = false;
                    break;
                case "XerathLocusPulse":
                    RCharge.CastT = Game.TickCount;
                    RCharge.Index++;
                    RCharge.Position      = args.EndPosition;
                    RCharge.TapKeyPressed = false;
                    break;
            }
        }

        public static class RCharge
        {
            public static int     CastT;
            public static int     Index;
            public static Vector3 Position;
            public static bool    TapKeyPressed;
        }
    }
}