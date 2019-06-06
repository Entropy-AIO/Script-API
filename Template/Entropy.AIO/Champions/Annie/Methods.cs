namespace Entropy.AIO.Champions.Annie
{
    using Logics;
    using SDK.Events;

    class Methods
    {
        private static readonly CustomTick CustomTick     = new CustomTick(200f);
        private static readonly CustomTick SlowCustomTick = new CustomTick(2000f);

        public Methods()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Tick.OnTick                      += Annie.OnTick;
            CustomTick.OnTick                += Annie.OnCustomTick;
            SlowCustomTick.OnTick            += Annie.OnSlowCustomTick;
            Gapcloser.OnNewGapcloser         += Annie.OnNewGapCloser;
            Interrupter.OnInterruptableSpell += Annie.OnInterruptableSpell;
            AIBaseClient.OnFinishCast        += Burst.OnFinishCast;
        }
    }
}