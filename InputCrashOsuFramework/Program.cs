using osu.Framework;
using System;

namespace InputCrashOsuFramework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var host = Host.GetSuitableHost("test", true))
            {
                host.Run(new TestGame());
            }
        }
    }
}
