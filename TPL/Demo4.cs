using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace TPL
{
    class Demo4
    {
        public static void Run()
        {
            var ab = new ActionBlock<int>(i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            });

            var tb = new TransformBlock<int, int>(i => i * 2);

            tb.LinkTo(ab);

            for (int i = 0; i < 10; i++)
            {
                tb.Post(i);
            }

        }
    }
}
