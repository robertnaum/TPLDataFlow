using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL
{
    class Demo7
    {
        public static void Run()
        {
            ConcurrentExclusiveSchedulerPair cesp = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, 4);

            var ab1 = new ActionBlock<int>(i =>
            {
                //access shared state by writing to it
            }, new ExecutionDataflowBlockOptions () {TaskScheduler = cesp.ExclusiveScheduler});


            var ab2 = new ActionBlock<int>(i =>
            {
                //access shared state by writing to it
            }, new ExecutionDataflowBlockOptions() { TaskScheduler = cesp.ExclusiveScheduler });

            var ab3 = new ActionBlock<int>(i =>
            {
                //read shared state
            }, new ExecutionDataflowBlockOptions() { TaskScheduler = cesp.ConcurrentScheduler, MaxDegreeOfParallelism=5 });

        }

    }
}
