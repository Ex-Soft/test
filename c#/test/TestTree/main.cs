// http://blog.johnsworkshop.net/traversing-a-tree-using-iterator-blocks/

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;

namespace TestTree
{
    class TreeNode
    {
        readonly List<TreeNode> _children = new List<TreeNode>();

        public string Name { get; set; }
        public List<TreeNode> Children => _children;

        public IEnumerable<TreeNode> AsDepthFirst()
        {
            yield return this;

            foreach (var node1 in _children)
                foreach (var node2 in node1.AsDepthFirst())
                    yield return node2;
        }

        public IEnumerable<TreeNode> AsDepthFirst2()
        {
            foreach (var node1 in this.Children)
            {
                yield return node1;

                foreach (var node2 in node1.AsDepthFirst2())
                    yield return node2;
            }
        }

        public IEnumerable<TreeNode> AsDepthFirst21()
        {
            var result = new List<TreeNode>();

            foreach (var node in Children)
            {
                result.Add(node);
                result.AddRange(node.AsDepthFirst21());
            }

            return result;
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

            List<TreeNode>
                list1,
                list2,
                list3;

            foreach (var node in (list1 = root.AsDepthFirst().ToList()))
                Console.WriteLine(node.Name);

            Console.WriteLine();

            foreach (var node in (list2 = root.AsDepthFirst2().ToList()))
                Console.WriteLine(node.Name);

            Console.WriteLine();

            foreach (var node in (list3 = root.AsDepthFirst21().ToList()))
                Console.WriteLine(node.Name);

            Console.WriteLine();

            if (list1.Count > 0)
                list1.RemoveAt(0);

            Console.WriteLine($"list1.Count = {list1.Count} list2.Count = {list2.Count} list3.Count = {list3.Count}");
            if (list1.Count != list2.Count || list1.Count != list3.Count || list2.Count != list3.Count)
                Console.WriteLine("!!!");

            for (var i = 0; i < list1.Count && i < list2.Count && i < list3.Count; ++i)
            {
                Console.WriteLine($"list1[{i}].Name = \"{list1[i].Name}\" list2[{i}].Name = \"{list2[i].Name}\" list3[{i}].Name = \"{list3[i].Name}\"");
                if(list1[i].Name != list2[i].Name || list1[i].Name != list3[i].Name || list2[i].Name != list3[i].Name)
                    Console.WriteLine("!!!");
            }

            Console.WriteLine();

            foreach (var node in root.AsBreadthFirst())
                Console.WriteLine(node.Name);

            Console.ReadLine();
        }
    }
}
