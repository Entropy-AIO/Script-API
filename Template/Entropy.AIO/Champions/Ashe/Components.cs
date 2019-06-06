namespace Entropy.AIO.Champions.Ashe
{
    using SDK.UI.Components;
    using SDK.UI.CustomComponents;

    public static class Components
    {
        public static class ComboMenu
        {
            public static readonly MenuBool QBool = new MenuBool("comboQ", "Use Q");
            public static readonly MenuBool WBool = new MenuBool("comboW", "Use W");

            public static readonly MenuKeyBind RSemiAutoKeyBind =
                new MenuKeyBind("rsemiautomatic", "R Semi-Automatic Cast", WindowMessageWParam.T, KeybindType.Hold);

            public static readonly MenuWhitelist RWhitelist = new MenuWhitelist("R Whitelist", MenuWhitelistType.Enemies, true);
        }

        public static class HarassMenu
        {
            public static readonly MenuSliderBool QSliderBool = new MenuSliderBool("harassQ", "Use Q | If Mana >= x%", true, 50);
            public static readonly MenuSliderBool WSliderBool = new MenuSliderBool("harassW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuWhitelist QWhitelist = new MenuWhitelist("Q Whitelist", MenuWhitelistType.Enemies, true);
            public static readonly MenuWhitelist WWhitelist = new MenuWhitelist("W Whitelist", MenuWhitelistType.Enemies, true);
        }

        public static class KillstealMenu
        {
            public static readonly MenuBool WBool = new MenuBool("killstealW", "Use W");
            public static readonly MenuBool RBool = new MenuBool("killstealR", "Use R");
        }

        public static class JungleClearMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("JungleClearQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("JungleClearW", "Use W | If Mana >= x%", true, 50);
        }

        public static class LaneClearMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("LaneClearQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("LaneClearW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool QCountSliderBool =
                new MenuSliderBool("LaneClearQCount", "Use Q | If Minions around >= x", true, 2, 1, 6);
        }

        public static class LastHitMenu
        {
            public static readonly MenuSliderBool WSliderBool = new MenuSliderBool("lastHitW", "Use W | If Mana >= x%", true, 50);
        }

        public static class AutomaticMenu
        {
            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("w", "Automatically use W | If Mana >= x%", true, 85);

            public static readonly MenuBool RImmobile = new MenuBool("immobile", "R on immobile targets");

            public static readonly MenuSlider RRange = new MenuSlider("range", "Custom R range", 2500, 1500, 5000);

            public static readonly MenuSliderBool RDistance =
                new MenuSliderBool("distance", "Only if distance to player >= x", true, 1200, 1200, 2000);

            public static readonly MenuWhitelist WWhitelist = new MenuWhitelist("W Whitelist", MenuWhitelistType.Enemies, true);
            public static readonly MenuWhitelist RWhitelist = new MenuWhitelist("R Whitelist", MenuWhitelistType.Enemies, true);
        }

        public static class GapCloserMenu
        {
            public static readonly MenuBool      RBool      = new MenuBool("enabled", "Enabled");
            public static readonly MenuAntiSpell RGapcloser = new MenuAntiSpell("R", MenuAntiType.Gapcloser);
        }

        public static class InterrupterMenu
        {
            public static readonly MenuBool      RBool        = new MenuBool("enabled", "Enabled");
            public static readonly MenuAntiSpell RInterrupter = new MenuAntiSpell("R", MenuAntiType.Interrupter);
        }
    }
}