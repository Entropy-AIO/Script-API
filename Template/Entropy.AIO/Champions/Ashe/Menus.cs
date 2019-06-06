namespace Entropy.AIO.Champions.Ashe
{
    using Bases;
    using SDK.UI;
    using SDK.UI.Components;
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
                ComboMenu.RSemiAutoKeyBind.SetToolTip("Will cast to the Killable/Selected/Nearest whitelisted target")
            };

            var harassMenu = new Menu("harass", "Harass")
            {
                HarassMenu.QSliderBool,
                HarassMenu.WSliderBool
            };

            HarassMenu.QWhitelist.Attach(harassMenu);
            HarassMenu.WWhitelist.Attach(harassMenu);

            var killStealMenu = new Menu("killsteal", "KillSteal")
            {
                KillstealMenu.WBool,
                KillstealMenu.RBool
            };

            var laneClearMenu = new Menu("LaneClear", "Lane Clear")
            {
                LaneClearMenu.QSliderBool,
                LaneClearMenu.WSliderBool,
                LaneClearMenu.QCountSliderBool
            };

            var jungleClearMenu = new Menu("JungleClear", "Jungle Clear")
            {
                JungleClearMenu.QSliderBool,
                JungleClearMenu.WSliderBool
            };

            var RGapCloserMenu = new Menu("eGapClose", "E")
            {
                GapCloserMenu.RBool,
                new MenuSeperator(string.Empty)
            };

            GapCloserMenu.RGapcloser.Attach(RGapCloserMenu);

            MenuBase.Gapcloser = new Menu($"{LocalPlayer.Instance.CharName.ToLower()}.antigapcloser", "Anti-Gapcloser")
            {
                RGapCloserMenu
            };

            var RInterrupterMenu = new Menu("r", "R")
            {
                InterrupterMenu.RBool,
                new MenuSeperator(string.Empty)
            };

            InterrupterMenu.RInterrupter.Attach(RInterrupterMenu);

            MenuBase.Interrupter = new Menu($"{LocalPlayer.Instance.CharName.ToLower()}.interrupter", "Interrupter")
            {
                RInterrupterMenu
            };

            var automaticMenu = new Menu("Automatic", "Automatic")
            {
                AutomaticMenu.WSliderBool,
                AutomaticMenu.RImmobile.SetToolTip("Only within custom R range"),

                new Menu("checks", "R Settings")
                {
                    AutomaticMenu.RRange,
                    AutomaticMenu.RDistance
                }
            };

            AutomaticMenu.WWhitelist.Attach(automaticMenu);
            AutomaticMenu.RWhitelist.Attach(automaticMenu);

            var drawingMenu = MenuBase.Drawings.As<Menu>();
            {
                drawingMenu.Add(WBool);

                drawingMenu.Add(new Menu("damage", "Draw Damages")
                {
                    WDamageBool,
                    RDamageBool,
                    AutoDamageSliderBool
                });
            }

            var menuList = new[]
            {
                comboMenu,
                harassMenu,
                killStealMenu,
                laneClearMenu,
                jungleClearMenu,
                automaticMenu
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