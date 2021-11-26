using System.Diagnostics;

namespace Audacia.Quest.Core
{
    public class Time
    {
        private readonly static Stopwatch _stopwatch = new Stopwatch();

        public static void Start()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public static void Update()
        {
        }

        public static long TotalMiliseconds => _stopwatch.ElapsedMilliseconds;
    }
}
