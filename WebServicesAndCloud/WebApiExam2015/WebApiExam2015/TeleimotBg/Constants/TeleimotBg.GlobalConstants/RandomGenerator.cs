namespace TeleimotBg.GlobalConstants
{
    using System;
    using System.Linq;

    public static class RandomGenerator
    {
        private static Random random = new Random();

        public static int GetRandomNumber(int bottom, int top)
        {
            return random.Next(bottom, top + 1);
        }
    }
}
