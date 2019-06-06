namespace Entropy.AIO.Champions._Template
{
    using SDK.Events;

    class Methods
    {
        private static readonly CustomTick CustomTick = new CustomTick(2000);

        public Methods()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Tick.OnTick       += Template.OnTick;
            CustomTick.OnTick += Template.OnCustomTick;
        }
    }
}