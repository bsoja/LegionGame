using System;

namespace Legion.Utils
{
    public class GlobalUtils
    {
        private static readonly Random Random = new Random();

        public static int Rand(int maxValue)
        {
            // NOTE: AMOS Rnd(x) === C# Random(x+1)
            return Random.Next(maxValue + 1);
        }
    }
}