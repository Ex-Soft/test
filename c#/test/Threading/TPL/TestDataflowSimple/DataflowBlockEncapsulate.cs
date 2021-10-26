using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TestDataflowSimple
{
    public class DataflowBlockEncapsulate
    {
        public static void Run()
        {
            var source = new BufferBlock<int>();
            var target = new ActionBlock<int>(Action);
            var propagatorBlock = DataflowBlock.Encapsulate(target, source);

            //source.Post(13);
            propagatorBlock.Post(169);
        }

        public static void Action(int data)
        {
            Debug.WriteLine(data);
        }
    }
}
