// http://blog.johnsworkshop.net/traversing-a-tree-using-iterator-blocks/

using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTree
{
    class TreeNode
    {
        readonly List<TreeNode> _children = new List<TreeNode>();

        public string Name { get; set; }
        public List<TreeNode> Children
        {
            get { return _children; }
        }

        public IEnumerable<TreeNode> AsDepthFirst()
        {
            yield return this;

            foreach (var node1 in _children)
                foreach (var node2 in node1.AsDepthFirst())
                    yield return node2;
        }

        public IEnumerable<TreeNode> AsBreadthFirst()
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(this);

            while (q.Any())
            {
                var current = q.Dequeue();
                if (current != null)
                {
                    foreach (TreeNode childNode in current.Children)
                        q.Enqueue(childNode);

                    yield return current;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode {Name = "root"};
            root.Children.AddRange(new[] { new TreeNode { Name = "1.1" }, new TreeNode { Name = "1.2" }, new TreeNode { Name = "1.3" } });

            var tmpNode = root.AsDepthFirst().FirstOrDefault(node => node.Name == "1.1");
            if (tmpNode != null)
                tmpNode.Children.AddRange(new[] { new TreeNode { Name = "1.1.1" }, new TreeNode { Name = "1.1.2" }, new TreeNode { Name = "1.1.3" } });

            tmpNode = root.AsDepthFirst().FirstOrDefault(node => node.Name == "1.1.1");
            if (tmpNode != null)
                tmpNode.Children.AddRange(new[] { new TreeNode { Name = "1.1.1.1" }, new TreeNode { Name = "1.1.1.2" }, new TreeNode { Name = "1.1.1.3" } });

            tmpNode = root.AsDepthFirst().FirstOrDefault(node => node.Name == "1.1.2");
            if (tmpNode != null)
                tmpNode.Children.AddRange(new[] { new TreeNode { Name = "1.1.2.1" }, new TreeNode { Name = "1.1.2.2" }, new TreeNode { Name = "1.1.2.3" } });

            tmpNode = root.AsDepthFirst().FirstOrDefault(node => node.Name == "1.1.1.1");
            if (tmpNode != null)
                tmpNode.Children.AddRange(new[] { new TreeNode { Name = "1.1.1.1.1" }, new TreeNode { Name = "1.1.1.1.2" }, new TreeNode { Name = "1.1.1.1.3" } });

            foreach (var node in root.AsDepthFirst())
                Console.WriteLine(node.Name);

            Console.WriteLine();

            foreach (var node in root.AsBreadthFirst())
                Console.WriteLine(node.Name);

            Console.ReadLine();
        }
    }
}
