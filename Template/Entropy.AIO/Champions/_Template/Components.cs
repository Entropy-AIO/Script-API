namespace Entropy.AIO.Champions._Template
{
    using SDK.UI.Components;
    using SDK.UI.CustomComponents;

    public static class Components
    {
        public static class ComboMenu
        {
            public static readonly MenuBool QBool = new MenuBool("comboQ", "Use Q");
            public static readonly MenuBool WBool = new MenuBool("comboW", "Use W");
            public static readonly MenuBool EBool = new MenuBool("comboE", "Use E");
            public static readonly MenuBool RBool = new MenuBool("comboR", "Use R");
        }

        public static class HarassMenu
        {
            public static readonly MenuSliderBool QSliderBool = new MenuSliderBool("harassQ", "Use Q | If Mana >= x%", true, 50);
            public static readonly MenuSliderBool WSliderBool = new MenuSliderBool("harassW", "Use W | If Mana >= x%", true, 50);
            public static readonly MenuSliderBool ESliderBool = new MenuSliderBool("harassE", "Use E | If Mana >= x%", true, 50);

            public static readonly MenuWhitelist QWhitelist = new MenuWhitelist("Q Whitelist", MenuWhitelistType.Enemies, true);
            public static readonly MenuWhitelist WWhitelist = new MenuWhitelist("W Whitelist", MenuWhitelistType.Enemies, true);
            public static readonly MenuWhitelist EWhitelist = new MenuWhitelist("E Whitelist", MenuWhitelistType.Enemies, true);
        }

        public static class KillStealMenu
        {
            public static readonly MenuBool QBool = new MenuBool("killStealQ", "Use Q");
            public static readonly MenuBool WBool = new MenuBool("killStealW", "Use W");
            public static readonly MenuBool EBool = new MenuBool("killStealE", "Use E");
        }

        public static class JungleClearMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("jungleClearQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("jungleClearW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool ESliderBool =
                new MenuSliderBool("jungleClearE", "Use E | If Mana >= x%", true, 50);
        }

        public static class LaneClearMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("laneClearQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuSlider QCountSliderBool =
                new MenuSlider("laneClearQCount", "Use Q if hittable minions >= x", 3, 1, 5);

            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("laneClearW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuSlider WCountSliderBool =
                new MenuSlider("laneClearWCount", "Use W if hittable minions >= x", 3, 1, 5);

            public static readonly MenuSliderBool ESliderBool =
                new MenuSliderBool("laneClearE", "Use E | If Mana >= x%", true, 50);

            public static readonly MenuSlider ECountSliderBool =
                new MenuSlider("laneClearECount", "Use E if hittable minions >= x", 3, 1, 5);
        }

        public static class LastHitMenu
        {
            public static readonly MenuSliderBool QSliderBool = new MenuSliderBool("lastHitQ", "Use Q | If Mana >= x%", true, 50);
            public static readonly MenuSliderBool WSliderBool = new MenuSliderBool("lastHitW", "Use W | If Mana >= x%", true, 50);
            public static readonly MenuSliderBool ESliderBool = new MenuSliderBool("lastHitE", "Use E | If Mana >= x%", true, 50);
        }
    }
}