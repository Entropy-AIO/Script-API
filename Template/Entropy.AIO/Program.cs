using System.Reflection;

namespace Entropy.AIO
{
    using SDK.Events;
    using SDK.Utils;

    static class Program
    {
        
        private static void Main()
        {
            var delay = Game.ClockTime > 5 ? 0f : 1750f;
            Loading.OnLoadingComplete += () =>
            {
                if (Game.IsReplay)
                {
                    return;
                }

                DelayAction.Queue(Bootstrap.Initialize, delay);
            };
        }
    }
}