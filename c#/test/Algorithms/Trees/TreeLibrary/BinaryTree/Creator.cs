using System.Collections.Generic;

namespace TreeLibrary.BinaryTree
{
    public class Creator
    {
        public static Node Create()
        {
            const int deep = 3;

            Node root;

            var queue = new Queue<Node>();

            queue.Enqueue(root = new Node());

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Level > deep)
                    continue;

                queue.Enqueue(AddNodeLeft(currentNode, $"{currentNode.Name}{(!string.IsNullOrWhiteSpace(currentNode.Name) ? "." : string.Empty)}1"));
                queue.Enqueue(AddNodeRight(currentNode, $"{currentNode.Name}{(!string.IsNullOrWhiteSpace(currentNode.Name) ? "." : string.Empty)}2"));
            }

            return root;
        }

        private static Node AddNodeLeft(Node parent, string name)
        {
            return parent.NodeLeft = new Node(name, parent);
        }

        private static Node AddNodeRight(Node parent, string name)
        {
            return parent.NodeRight = new Node(name, parent);
        }
    }
}
