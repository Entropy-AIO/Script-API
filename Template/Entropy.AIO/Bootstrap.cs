namespace Entropy.AIO
{
    using Bases;
    using General;

    static class Bootstrap
    {
        private static bool initialized;
        private static float injectTime;

        
        public static void Initialize()
        {
            if (!initialized)
            {
                initialized = true;

                injectTime = Game.ClockTime;
                MenuBase.Initialize();
                LogicBase.Initialize();
                ChampionLoader.Initialize();
            }
        }
    }
}