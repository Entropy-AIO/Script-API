namespace Entropy.AIO.Champions.Annie.Misc
{
    using System.Collections.Generic;
    using Bases;
    using SDK.Extensions.Objects;

    public static class Definitions
    {
        public static AIHeroClient BurstTarget;

        public static List<AIHeroClient> BurstableEnemies = new List<AIHeroClient>();
        public static bool               HasStun => LocalPlayer.Instance.HasBuff("anniepassiveprimed");

        public static bool HasTibbers => ChampionBase.R.ToggleState == 0;
    }
}