namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= n - 1; i++)
            {
                var command = Console.ReadLine();
                var commandParts = command.Split(' ');

                var parentId = int.Parse(commandParts[0]);
                var childId = int.Parse(commandParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            var theRoot = FindTheRoot(nodes);
            Console.WriteLine("The root is {0}", theRoot.Value);
            Console.WriteLine("--------------------------------");
            var leaves = FindAllLeafs(nodes);
            foreach (var item in leaves)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------");

            var middleNodes = FindAllMiddleNodes(nodes);

            foreach (var item in middleNodes)
            {
                Console.Write(item.Value + " ");
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------");
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            var middle = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count > 0 && node.HasParent)
                {
                    middle.Add(node);
                }
            }

            return middle;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            var leaves = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            return leaves;
        }

        private static Node<int> FindTheRoot(Node<int>[] nodes)
        {
            var hasParents = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParents[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParents.Length; i++)
            {
                if (!hasParents[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("No root found!");
        }
    }
}
