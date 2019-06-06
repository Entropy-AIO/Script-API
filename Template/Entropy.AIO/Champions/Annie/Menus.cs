namespace Entropy.AIO.Champions.Annie
{
    using Bases;
    using SDK.UI;
    using SDK.UI.PermaShow;
    using static Components;
    using static Bases.Components.DrawingMenu;

    class Menus
    {
        public Menus()
        {
            Initialize();
        }

        private static void Initialize()
        {
            var comboMenu = new Menu("combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.WBool,
                ComboMenu.RBool,
                ComboMenu.RCountBool
            };

            var harassMenu = new Menu("harass", "Harass")
            {
                HarassMenu.QSliderBool,
                HarassMenu.WSliderBool
            };

            HarassMenu.QWhitelist.Attach(harassMenu);
            HarassMenu.WWhitelist.Attach(harassMenu);

            var killStealMenu = new Menu("killSteal", "KillSteal")
            {
                KillStealMenu.QBool,
                KillStealMenu.WBool,
                KillStealMenu.RBool
            };

            var laneClearMenu = new Menu("LaneClear", "Lane Clear")
            {
                LaneClearMenu.QSliderBool,
                LaneClearMenu.WSliderBool,
                new Menu("customization", "Customization")
                {
                    LaneClearMenu.QKillable,
                    LaneClearMenu.WCountSliderBool
                }
            };

            var jungleClearMenu = new Menu("JungleClear", "Jungle Clear")
            {
                JungleClearMenu.QSliderBool,
                JungleClearMenu.WSliderBool,
                JungleClearMenu.ESliderBool,
                JungleClearMenu.ESaveBool
            };

            var lastHitMenu = new Menu("lastHit", "Last Hit")
            {
                LastHitMenu.QSliderBool,
                LastHitMenu.QSaveStunBool
            };

            var burstMenu = new Menu("burst", "Burst")
            {
                BurstMenu.EStackBool,
                BurstMenu.StunBool,
                BurstMenu.BurstMode.Permashow(),
                BurstMenu.BurstKey.Permashow()
            };

            var drawingMenu = MenuBase.Drawings.As<Menu>();
            {
                drawingMenu.Add(QBool);
                drawingMenu.Add(WBool);
                drawingMenu.Add(DrawsMenu.WCone);
                drawingMenu.Add(RBool);

                drawingMenu.Add(new Menu("damage", "Draw Damages")
                {
                    QDamageBool,
                    WDamageBool,
                    RDamageBool,
                    AutoDamageSliderBool
                });
                drawingMenu.Add(DrawsMenu.FlashRRangeBool);
                drawingMenu.Add(DrawsMenu.BurstableEnemiesBool);
            }

            var gapCLoserMenu = new Menu("gapClose", "GapCloser")
            {
                AntiGapCloserMenu.QBool,
                AntiGapCloserMenu.WBool,
                AntiGapCloserMenu.StunBool
            };
            AntiGapCloserMenu.AntiGapCloser.Attach(gapCLoserMenu);

            MenuBase.Gapcloser = new Menu($"{LocalPlayer.Instance.CharName.ToLower()}.antigapcloser", "Anti-Gapcloser")
            {
                gapCLoserMenu
            };

            var interrupterMenu = new Menu("interrupter", "Interrupter")
            {
                InterrupterMenu.InfoSeparator,
                InterrupterMenu.QBool,
                InterrupterMenu.WBool,
                InterrupterMenu.RBool
            };
            InterrupterMenu.Interrupter.Attach(interrupterMenu);

            MenuBase.Interrupter = new Menu($"{LocalPlayer.Instance.CharName.ToLower()}.interrupter", "Interrupter")
            {
                interrupterMenu
            };

            var menuList = new[]
            {
                comboMenu,
                harassMenu,
                killStealMenu,
                laneClearMenu,
                jungleClearMenu,
                lastHitMenu,
                burstMenu
            };

            foreach (var menu in menuList)
            {
                MenuBase.Champion.Add(menu);
            }

            MenuBase.Root.Add(MenuBase.Gapcloser);
            MenuBase.Root.Add(MenuBase.Interrupter);
        }
    }
}