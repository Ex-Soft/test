using System.Collections.Generic;
using TreeLibrary.BinaryTree;

using static System.Console;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = Creator.Create();

            var queue = new Queue<Node>();

            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                WriteLine(currentNode);

                if (currentNode.NodeLeft != null)
                    queue.Enqueue(currentNode.NodeLeft);
                if (currentNode.NodeRight != null)
                    queue.Enqueue(currentNode.NodeRight);
            }

            ReadLine();
        }
    }
}
