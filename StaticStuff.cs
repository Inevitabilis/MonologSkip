using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonologSkip
{
    public static class StaticStuff
    {
        public static void CounterUpdate(ref this int counter)
        {
            if (counter > 0) counter--;
        }
        public static void CounterReset(ref this int counter)
        {
            counter = 20;
        }
    }
}
