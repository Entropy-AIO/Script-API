namespace Entropy.AIO.Champions.Annie
{
    using SDK.UI.Components;
    using SDK.UI.CustomComponents;

    public static class Components
    {
        public static class ComboMenu
        {
            public static readonly MenuBool QBool = new MenuBool("comboQ", "Use Q");
            public static readonly MenuBool WBool = new MenuBool("comboW", "Use W");
            public static readonly MenuBool RBool = new MenuBool("comboR", "Use R", false);

            public static readonly MenuSliderBool RCountBool =
                new MenuSliderBool("comboRCount", "Only R if hittable enemies >= X", true, 2, 1, 5);
        }

        public static class HarassMenu
        {
            public static readonly MenuSliderBool QSliderBool = new MenuSliderBool("harassQ", "Use Q | If Mana >= x%", true, 50);
            public static readonly MenuSliderBool WSliderBool = new MenuSliderBool("harassW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuWhitelist QWhitelist = new MenuWhitelist("Q Whitelist", MenuWhitelistType.Enemies, true);
            public static readonly MenuWhitelist WWhitelist = new MenuWhitelist("W Whitelist", MenuWhitelistType.Enemies, true);
        }

        public static class KillStealMenu
        {
            public static readonly MenuBool QBool = new MenuBool("killStealQ", "Use Q");
            public static readonly MenuBool WBool = new MenuBool("killStealW", "Use W");
            public static readonly MenuBool RBool = new MenuBool("killStealR", "Use R", false);
        }

        public static class JungleClearMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("jungleClearQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("jungleClearW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuSliderBool ESliderBool =
                new MenuSliderBool("jungleClearE", "Use E | If Mana >= x%", false, 50);

            public static readonly MenuBool ESaveBool = new MenuBool("jungleClearESave", "Dont E if stun is up");
        }

        public static class LaneClearMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("laneClearQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuBool QKillable = new MenuBool("laneClearQKillable", "Only Q if Killable");

            public static readonly MenuSliderBool WSliderBool =
                new MenuSliderBool("laneClearW", "Use W | If Mana >= x%", true, 50);

            public static readonly MenuSlider WCountSliderBool =
                new MenuSlider("laneClearWCount", "Use W if hittable minions >= x", 3, 1, 5);
        }

        public static class LastHitMenu
        {
            public static readonly MenuSliderBool QSliderBool =
                new MenuSliderBool("lastHitQ", "Use Q | If Mana >= x%", true, 50);

            public static readonly MenuBool QSaveStunBool = new MenuBool("lastHitQSave", "Don't use Q if stun is up");
        }

        public static class BurstMenu
        {
            public static readonly MenuBool StunBool = new MenuBool("burstStun", "Only Burst if stun is up");

            public static readonly MenuSliderBool EStackBool =
                new MenuSliderBool("burstEStack", "Stack stun with E | If Mana >= x%", true, 50);

            public static readonly MenuKeyBind BurstKey =
                new MenuKeyBind("burstKey", "Burst Key", WindowMessageWParam.T, KeybindType.Hold);

            public static readonly MenuList BurstMode =
                new MenuList("burstMode", "Burst Mode", new[] {"Flash + Full Combo", "Flash + R"});
        }

        public static class AntiGapCloserMenu
        {
            public static readonly MenuBool QBool    = new MenuBool("gapCloserQ", "Use Q");
            public static readonly MenuBool WBool    = new MenuBool("gapCloserW", "Use W");
            public static readonly MenuBool StunBool = new MenuBool("gapCloserStun", "Only if stun is up");

            public static readonly MenuAntiSpell AntiGapCloser = new MenuAntiSpell("gapCloserOn", MenuAntiType.Gapcloser, true);
        }

        public static class InterrupterMenu
        {
            public static readonly MenuSeperator InfoSeparator = new MenuSeperator("interrupterInfo", "Priority R>>W>>Q");
            public static readonly MenuBool      QBool         = new MenuBool("interrupterQ", "Use Q");
            public static readonly MenuBool      WBool         = new MenuBool("interrupterW", "Use W");
            public static readonly MenuBool      RBool         = new MenuBool("interrupterR", "Use R");

            public static readonly MenuAntiSpell Interrupter = new MenuAntiSpell("interrupterOn", MenuAntiType.Interrupter, true);
        }

        public static class DrawsMenu
        {
            public static readonly MenuBool WCone = new MenuBool("drawsWCone", "Draw W Cone");

            public static readonly MenuBool FlashRRangeBool = new MenuBool("drawsFlashRRange", "Draw Flash + R Range");

            public static readonly MenuBool BurstableEnemiesBool =
                new MenuBool("drawsBurstableEnemies", "Draw Burstable Enemies");
        }
    }
}