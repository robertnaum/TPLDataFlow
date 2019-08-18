using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL
{
    class Demo5
    {
        public static void Run()
        {
            var ab = new ActionBlock<int>(async i =>
            {
                await Task.Delay(1000);
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
