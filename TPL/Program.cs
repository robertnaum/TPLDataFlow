﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = new ActionBlock<(int x, int y, string msg)>(i =>
            {
               // Thread.Sleep(1000);
                Console.WriteLine($"{i.x},{i.y} {i.msg}");

            }, new ExecutionDataflowBlockOptions()
                { TaskScheduler=TaskScheduler.Default,
                    MaxDegreeOfParallelism =4});
            for (int i = 0; i < 10; i++)
            {
                ab.Post((3,i, "hello"));
            }

            ab.Complete();
            Console.WriteLine("done");
            ab.Completion.Wait();
        }
    }
}
