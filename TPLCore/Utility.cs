using System;
using System.Collections.Generic;
using System.Text;

namespace TPLCore
{
    public static class Utility
    {
        private static readonly Random r = new Random(Guid.NewGuid().GetHashCode());
        public static int RandomInt(int min = 1, int max = 100)
        {
            return r.Next(min, max);
        }
    }
}
