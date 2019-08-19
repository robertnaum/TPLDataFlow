using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPLCore
{
    class Demo8
    {
        public async static Task Run()
        {

            var actionBlock = new ActionBlock<ComplicatedComputation>(async computation =>
                {
                    while (await computation.Countdown())
                    {

                    }
                }, new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 4
                }
            );

            foreach (var i in XDifferentIntegers(4))
            {
                actionBlock.Post(new ComplicatedComputation(i));
            }

            actionBlock.Complete();
            await actionBlock.Completion;
        }

        public static IEnumerable<int> XDifferentIntegers(int x)
        {
            return Enumerable.Range(10, 30).OrderBy(i => Guid.NewGuid()).Take(x);
        }
    }

    class ComplicatedComputation
    {
        private int _start;
        private int _current;
        private int _delay;
        private int _delaySec;
        public ComplicatedComputation(int start)
        {
            _start = start;
            _current = start;
            _delay = (Utility.RandomInt(1000, 4000) / 1000) * 1000 ;
            _delaySec = _delay / 1000;
        }

        public async Task<bool> Countdown()
        {
            string finished = string.Empty;
            if (_current > 0)
            {
                await Task.Delay(_delay);
                _current -= 1;
                if (_current == 0)
                {
                    finished = "!!!!!!!!";
                }
                Console.WriteLine($"{" ".PadLeft(_start/2)}{_start}[{_delaySec}]{":".PadRight(_start - _current, ' ')}{_current}{finished}");
                return true;
            }
            else return false;
        }
    }

}
