namespace Entropy.AIO.Champions.Xerath
{
    using Bases;
    using SDK.UI;
    using SDK.UI.Components;
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
            var comboMenu = new Menu("combo", "连招")
            {
                ComboMenu.QBool,
                ComboMenu.WBool,
                ComboMenu.EBool,
                new MenuSeperator("--", " ~~~~ "),
                ComboMenu.ESemiAutoKeyBind.SetToolTip("将会施放于 可击杀/选中的/白名单附近的目标")
            };
            var rMenu = new Menu("rMenu", "R 设置")
            {
                RSettings.RBool,
                RSettings.RMode,
                RSettings.RMode.SetToolTip("开R不要按空格"),
                RSettings.RSemiAutoKeyBind,
                RSettings.RDelay,
                RSettings.PingOnKill,
                RSettings.FocusMouse,
                RSettings.MouseRange
            };
            ComboMenu.ESemiAutoKeyBind.Permashow();
            ComboMenu.EWhitelist.Attach(comboMenu);

            var harassMenu = new Menu("harass", "骚扰")
            {
                HarassMenu.QBool,
                HarassMenu.WBool
            };


            var killStealMenu = new Menu("killsteal", "抢头")
            {
                KillstealMenu.QBool,
                KillstealMenu.WBool,
                KillstealMenu.EBool
            };


            var farmmenu = new Menu("farming", "技能清线")
            {
                LaneClearMenu.farmKey,
                new MenuSeperator("1", " ~~~~ ")
            };
            var laneMenu = new Menu("laneMenu", "清线")
            {
                LaneClearMenu.QBool,
                LaneClearMenu.hitsQ,
                LaneClearMenu.WBool,
                LaneClearMenu.hitsW
            };
            var jungleMenu = new Menu("jungleMenu", "清野")
            {
                JungleClearMenu.QBool,
                JungleClearMenu.WBool,
                JungleClearMenu.EBool
            };
            farmmenu.Add(laneMenu);
            farmmenu.Add(jungleMenu);

            var EGapCloserMenu = new Menu("e", "E")
            {
                GapCloserMenu.EBool,
                new MenuSeperator(string.Empty)
            };

            GapCloserMenu.EGapcloser.Attach(EGapCloserMenu);

            MenuBase.Gapcloser = new Menu($"{LocalPlayer.Instance.CharName.ToLower()}.antigapcloser", "反突进")
            {
                EGapCloserMenu
            };

            var EInterrupterMenu = new Menu("e", "E")
            {
                InterrupterMenu.EBool,
                new MenuSeperator(string.Empty)
            };

            InterrupterMenu.EInterrupter.Attach(EInterrupterMenu);

            MenuBase.Interrupter = new Menu($"{LocalPlayer.Instance.CharName.ToLower()}.interrupter", "技能打断")
            {
                EInterrupterMenu
            };


            var drawingMenu = MenuBase.Drawings.As<Menu>();
            {
                drawingMenu.Add(QBool);
                drawingMenu.Add(WBool);
                drawingMenu.Add(EBool);
                drawingMenu.Add(RBool);
                drawingMenu.Add(DrawingMenu.QTriangles);
                drawingMenu.Add(DrawingMenu.RMinimapRange);

                drawingMenu.Add(new Menu("damage", "显示伤害")
                {
                    QDamageBool,
                    WDamageBool,
                    EDamageBool,
                    RDamageBool,
                    AutoDamageSliderBool
                });
            }

            var menuList = new[]
            {
                comboMenu,
                rMenu,
                harassMenu,
                killStealMenu,
                farmmenu
            };

            foreach (var menu in menuList)
            {
                MenuBase.Champion.Add(menu);
            }

            MenuBase.Root.Add(MenuBase.Gapcloser);
            MenuBase.Root.Add(MenuBase.Interrupter);
            LaneClearMenu.farmKey.Permashow();
            MenuBase.Champion.Add(new MenuSeperator("--", " ~~~~ "));
            MenuBase.Champion.Add(ComboMenu.QCharge);
        }
    }
}