namespace Entropy.AIO.Enumerations
{
    using System.Collections.Generic;
    using SDK.Enumerations;

    static class Enumerations
    {
        #region Static Fields

        /// <summary>
        ///     Gets the spellslots.
        /// </summary>
        public static readonly SpellSlot[] SpellSlots =
        {
            SpellSlot.Q,
            SpellSlot.W,
            SpellSlot.E,
            SpellSlot.R
        };

        /// <summary>
        ///     Gets the Hydras.
        /// </summary>
        public static readonly ItemID[] Hydras =
        {
            ItemID.TitanicHydra,
            ItemID.RavenousHydra,
            ItemID.Tiamat
        };

        public static readonly string[] ADCs =
        {
            "Ashe",
            "Caitlyn",
            "Corki",
            "Draven",
            "Ezreal",
            "Graves",
            "Jhin",
            "Jinx",
            "Kaisa",
            "Kalista",
            "Kindred",
            "KogMaw",
            "Lucian",
            "MissFortune",
            "Quinn",
            "Sivir",
            "Teemo",
            "Tristana",
            "Twitch",
            "Varus",
            "Vayne",
            "Xayah"
        };

        /// <key>
        ///     Champion Name
        /// </key>
        /// <value>
        ///     Spell Name
        /// </value>
        public static readonly Dictionary<string, string[]> ScripterSpells = new Dictionary<string, string[]>
        {
            {"Ashe", new[] {"AsheQ"}},
            {"Kaisa", new[] {"KaisaE"}},
            {"KogMaw", new[] {"KogMawBioArcaneBarrage"}},
            {"Lucian", new[] {"LucianE"}},
            {"MissFortune", new[] {"MissFortuneViciousStrikes"}},
            {"Sivir", new[] {"SivirR"}},
            {"Tristana", new[] {"TristanaQ", "TristanaE"}},
            {"Twitch", new[] {"TwitchFullAutomatic"}},
            {"Vayne", new[] {"VayneInquisition"}},
            {"Xayah", new[] {"XayahW"}}
        };

        /// <key>
        ///     Champion Name
        /// </key>
        /// <value>
        ///     Buff Name
        /// </value>
        public static readonly Dictionary<string, string[]> ScripterBuffs = new Dictionary<string, string[]>
        {
            {"Ashe", new[] {"AsheQAttack"}},
            {"Kaisa", new[] {"kaisaestealth"}},
            {"KogMaw", new[] {"KogMawBioArcaneBarrage"}},
            {"MissFortune", new[] {"MissFortuneViciousStrikes"}},
            {"Sivir", new[] {"SivirR"}},
            {"Tristana", new[] {"TristanaQ", "TristanaECharge"}},
            {"Twitch", new[] {"twitchhideinshadowsbuff", "TwitchFullAutomatic"}},
            {"Vayne", new[] {"VayneInquisition"}},
            {"Xayah", new[] {"XayahW"}}
        };

        public enum DrawingModes
        {
            Riot,
            SharpDX
        }

        #endregion
    }
}