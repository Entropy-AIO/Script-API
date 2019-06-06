namespace Entropy.AIO.Champions.Ashe
{
    using Bases;
    using Logics;
    using Misc;
    using SDK.Damage;
    using SDK.Enumerations;
    using SDK.Events;
    using SDK.Extensions.Objects;
    using SDK.Orbwalking;
    using SDK.Orbwalking.EventArgs;
    using static Components;

    sealed class Ashe : ChampionBase
    {
        public Ashe()
        {
            new Spells();
            new Menus();
            new Methods();
            new Drawings(W);
        }

        public static void OnWndProc(GameWndProcEventArgs args)
        {
            if (args.WParam != ComboMenu.RSemiAutoKeyBind.Key)
            {
                return;
            }

            Automatic.SemiAutomaticR(args);
        }

        public static void OnTick(EntropyEventArgs args)
        {
            if (LocalPlayer.Instance.IsDead() || LocalPlayer.Instance.IsRecalling() || GameConsole.IsOpen)
            {
                return;
            }

            if (W.Ready)
            {
                Automatic.ExecuteW();
            }

            switch (Orbwalker.Mode)
            {
                case OrbwalkingMode.Combo when W.Ready:
                    Combo.ExecuteW();
                    break;
                case OrbwalkingMode.Harass when W.Ready:
                    Harass.ExecuteW();
                    break;
                case OrbwalkingMode.Laneclear when W.Ready:
                    LaneClear.ExecuteW();
                    JungleClear.ExecuteW();
                    break;
            }
        }

        public static void OnCustomTick(EntropyEventArgs args)
        {
            if (LocalPlayer.Instance.IsDead() || LocalPlayer.Instance.IsRecalling())
            {
                return;
            }

            if (W.Ready && KillstealMenu.WBool.Enabled)
            {
                Killsteal.ExecuteW();
                return;
            }

            if (R.Ready && KillstealMenu.RBool.Enabled)
            {
                Killsteal.ExecuteR();
            }
        }

        public static void OnPreAttack(OnPreAttackEventArgs args)
        {
            switch (Orbwalker.Mode)
            {
                case OrbwalkingMode.Combo when Q.Ready:
                    Combo.ExecuteQ(args);
                    break;
                case OrbwalkingMode.Laneclear when Q.Ready:
                    LaneClear.ExecuteQ();
                    JungleClear.ExecuteQ(args);
                    break;
                case OrbwalkingMode.Harass when Q.Ready:
                    Harass.ExecuteQ(args);
                    break;
            }
        }

        public static void OnNewGapcloser(Gapcloser.GapcloserArgs args)
        {
            if (!R.Ready ||
                LocalPlayer.Instance.IsDead())
            {
                return;
            }

            var sender = args.Sender;

            if (sender == null || !sender.IsValid || !sender.IsEnemy() || !sender.IsMelee)
            {
                return;
            }

            AntiGapcloser.ExecuteR(args);
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

            if (R.Ready)
            {
                OnInterruptable.ExecuteR(sender, args);
            }
        }
    }
}