using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL
{
    class Demo6
    {
        public static void Run()
        {
            var jb = new JoinBlock<int, string>();
            jb.Target1.Post(42);
            jb.Target2.Post("43");
            var item = jb.Receive();
            Console.WriteLine(item);



        }

    }
}
