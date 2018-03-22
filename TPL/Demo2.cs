using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL
{
    class Demo2
    {
        public static void Run()
        {
            var items = new BufferBlock<int>();

            Task.Run(async delegate
            {
                while (true)
                {
                    int item = Produce();
                    await items.SendAsync(item);
                }
            });

            Task.Run(async delegate
            {
                while (true)
                {
                    int item = await items.ReceiveAsync();
                    Process(item);
                }
            });
        }

        static int Produce()
        {
            Thread.Sleep(1000);
            return 2;
        }

        static void Process(int i)
        {
            Thread.Sleep(500);
            Console.WriteLine(i + 2);
        }

    }
}
