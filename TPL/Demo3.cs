using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL
{
    class Demo3
    {

        public static async void Run()
        {
            var ab = new ActionBlock<(int x, int y, string msg)>(i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{i.x},{i.y} {i.msg}");

            });

            var tb = new TransformBlock<int, int>(i => i*2);

            for (int i = 0; i < 10; i++)
            {
                tb.Post(i);
            }

            int item = tb.Receive();
            Console.WriteLine(item);
            if (tb.TryReceive(out item))
            {
                Console.WriteLine(item);
            }
            item = await tb.ReceiveAsync();
            Console.WriteLine(item);

            Task<int> t = tb.ReceiveAsync();
            Console.WriteLine(t.Result);
            Console.ReadLine();
        }

    }
}
