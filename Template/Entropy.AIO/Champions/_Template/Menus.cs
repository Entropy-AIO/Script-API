namespace Entropy.AIO.Champions._Template
{
    using Bases;
    using SDK.UI;
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
                ComboMenu.EBool,
                ComboMenu.RBool
            };

            var harassMenu = new Menu("harass", "Harass")
            {
                HarassMenu.QSliderBool,
                HarassMenu.WSliderBool,
                HarassMenu.ESliderBool
            };

            HarassMenu.QWhitelist.Attach(harassMenu);
            HarassMenu.WWhitelist.Attach(harassMenu);
            HarassMenu.EWhitelist.Attach(harassMenu);

            var killStealMenu = new Menu("killSteal", "KillSteal")
            {
                KillStealMenu.QBool,
                KillStealMenu.WBool,
                KillStealMenu.EBool
            };

            var laneClearMenu = new Menu("LaneClear", "Lane Clear")
            {
                LaneClearMenu.QSliderBool,
                LaneClearMenu.WSliderBool,
                LaneClearMenu.ESliderBool,
                new Menu("customization", "Customization")
                {
                    LaneClearMenu.QCountSliderBool,
                    LaneClearMenu.WCountSliderBool,
                    LaneClearMenu.ECountSliderBool
                }
            };

            var jungleClearMenu = new Menu("JungleClear", "Jungle Clear")
            {
                JungleClearMenu.QSliderBool,
                JungleClearMenu.WSliderBool,
                JungleClearMenu.ESliderBool
            };

            var lastHitMenu = new Menu("lastHit", "Last Hit")
            {
                LastHitMenu.QSliderBool,
                LastHitMenu.WSliderBool,
                LastHitMenu.ESliderBool
            };

            var drawingMenu = MenuBase.Drawings.As<Menu>();
            {
                drawingMenu.Add(QBool);
                drawingMenu.Add(WBool);
                drawingMenu.Add(EBool);
                drawingMenu.Add(RBool);

                drawingMenu.Add(new Menu("damage", "Draw Damages")
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
                harassMenu,
                killStealMenu,
                laneClearMenu,
                jungleClearMenu,
                lastHitMenu
            };

            foreach (var menu in menuList)
            {
                MenuBase.Champion.Add(menu);
            }
        }
    }
}