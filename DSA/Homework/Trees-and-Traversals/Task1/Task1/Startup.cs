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

            var longestPath = FindLongestPathInTree(FindTheRoot(nodes));
            Console.WriteLine("Longest path in the tree is {0}", longestPath);

            Console.WriteLine();
            Console.WriteLine("--------------------------------");

            var sumPath = FindSum(theRoot, 8, new List<Node<int>>());
        }

        private static List<Node<int>> FindSum(Node<int> node, int sum, List<Node<int>> result)
        {
            int currentSum = 0;
            result.Add(node);

            foreach (var item in result)
            {
                currentSum += item.Value;
            }

            if (currentSum == sum)
            {
                return result;
            }

            var len = node.Children.Count;
            var childs = node.Children;
            for (var i = 0; i < len; i++)
            {
                currentSum += childs[i].Value;

                if (currentSum == sum)
                {
                    result.Add(childs[i]);
                    return result;
                }
                else if (currentSum > sum)
                {
                    if (i == len - 1)
                    {
                        continue;
                    }
                    else
                    {
                        result.RemoveAt(result.Count - 1);
                        FindSum(node, sum, result);
                    }                  
                }
                else
                {
                    FindSum(childs[i], sum, result);
                }
            }

            if (currentSum == sum)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("No matching path sum!");

            }
            
        }

        private static int FindLongestPathInTree(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            var maxPath = 0;
            foreach (var child in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPathInTree(child));
            }

            return maxPath + 1;
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
