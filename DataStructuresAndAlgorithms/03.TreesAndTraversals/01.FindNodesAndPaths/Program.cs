namespace _03.TreesAndTraversals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program to read the tree and:
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, Node<int>> nodes = ParseElementsToTree();

            // Find:
            // a) the root node
            Node<int> rootNode = FindRootNode(nodes);
            Console.WriteLine("Root node: {0}.", rootNode.Value);

            // b) all leaf nodes
            Console.WriteLine("Find all leaf nodes");
            List<Node<int>> leafNodes = FindLeafNodes(nodes);
            PrintNodesOnConsole(leafNodes);

            // c) all middle nodes
            Console.WriteLine("Find all middle nodes");
            List<Node<int>> middleNodes = FindMiddleNodes(nodes);
            PrintNodesOnConsole(middleNodes);

            // d) the longest path in the tree
            List<List<int>> paths = new List<List<int>>();

            List<int> currentPath = new List<int>();

            currentPath.Add(rootNode.Value);

            GetLongestPath(rootNode, paths, currentPath);
            
            Console.WriteLine("Longest path:");
            int maxLenght = 0;
            int indexOfLongestPath = 0;
            for (int i = 0; i < paths.Count; i++)
            {
                if (paths[i].Count > maxLenght)
                {
                    maxLenght = paths[i].Count;
                    indexOfLongestPath = i;
                }
            }

            Console.WriteLine(string.Join(", ", paths[indexOfLongestPath]));

            // e) * all paths in the tree with given sum S of their nodes
            Console.WriteLine("Enter searching sum");
            int sum = int.Parse(Console.ReadLine());
            var treePaths = new List<List<int>>();
            currentPath = new List<int>();
            foreach (var node in nodes)
            {
                currentPath.Add(node.Value.Value);
                FindPathWithSumS(node.Value, treePaths, currentPath, sum);
                currentPath.Clear();
            }

            Console.WriteLine("Display all paths with sum {0}:", sum);
            if (treePaths.Count > 0)
            {
                for (int i = 0; i < treePaths.Count; i++)
                {
                    Console.WriteLine(string.Join(", ", treePaths[i]));
                }
            }
            else
            {
                Console.WriteLine("There is no path with this sum.");
            }

            // f) all subtrees with given sum S of their nodes
            Console.WriteLine("Enter searching sum");
            sum = int.Parse(Console.ReadLine());
            treePaths = new List<List<int>>();
            currentPath = new List<int>();
            foreach (var node in nodes)
            {
                FindSubtreeWithSumS(node.Value, treePaths, currentPath, sum);
                currentPath.Clear();
            }

            Console.WriteLine("Display all sutree with sum {0}:", sum);
            if (treePaths.Count > 0)
            {
                for (int i = 0; i < treePaths.Count; i++)
                {
                    Console.WriteLine(string.Join(", ", treePaths[i]));
                }
            }
            else
            {
                Console.WriteLine("There is no subtree with this sum.");
            }
        }

        private static Dictionary<int, Node<int>> ParseElementsToTree()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, Node<int>> nodes = new Dictionary<int, Node<int>>();
            for (int i = 0; i < n - 1; i++)
            {
                string str = Console.ReadLine();
                string[] edgeParts = str.Split(new char[] { ' ' });

                int parent = int.Parse(edgeParts[0]);
                int child = int.Parse(edgeParts[1]);

                Node<int> parentNode;
                Node<int> childNode;
                if (nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];
                    if (nodes.ContainsKey(child))
                    {
                        childNode = nodes[child];
                        childNode.HasParent = true;
                    }
                    else
                    {
                        childNode = new Node<int>(child);
                        nodes.Add(child, childNode);
                    }
                }
                else
                {
                    parentNode = new Node<int>(parent);
                    if (nodes.ContainsKey(child))
                    {
                        childNode = nodes[child];
                        childNode.HasParent = true;
                    }
                    else
                    {
                        childNode = new Node<int>(child);
                        nodes.Add(child, childNode);
                    }

                    nodes.Add(parent, parentNode);
                }

                parentNode.AddChild(childNode);
            }

            return nodes;
        }

        private static Node<int> FindRootNode(Dictionary<int, Node<int>> nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.Value.HasParent)
                {
                    return node.Value;
                }
            }

            throw new ArgumentException("This three has no root.");
        }

        private static List<Node<int>> FindLeafNodes(Dictionary<int, Node<int>> nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();
            foreach (var node in nodes)
            {
                if (node.Value.Children.Count == 0)
                {
                    leafs.Add(node.Value);
                }
            }

            return leafs;
        }

        private static void PrintNodesOnConsole(List<Node<int>> elements)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in elements)
            {
                sb.Append(element.Value);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            Console.WriteLine(sb.ToString());
        }

        private static List<Node<int>> FindMiddleNodes(Dictionary<int, Node<int>> nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();
            foreach (var node in nodes)
            {
                if (node.Value.Children.Count != 0 && node.Value.HasParent)
                {
                    middleNodes.Add(node.Value);
                }
            }

            return middleNodes;
        }

        private static void GetLongestPath(Node<int> rootNode, List<List<int>> treePaths, List<int> currentPath)
        {
            if (rootNode.Children.Count == 0)
            {
                treePaths.Add(currentPath.GetRange(0, currentPath.Count));
            }
            else
            {
                foreach (var child in rootNode.Children)
                {
                    currentPath.Add(child.Value);
                    GetLongestPath(child, treePaths, currentPath);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }
        
        private static void FindPathWithSumS(Node<int> node, List<List<int>> treePaths, List<int> currentPath, int sum)
        {
            int currentSum = currentPath.Sum();
            if (currentSum == sum)
            {
                treePaths.Add(currentPath.GetRange(0, currentPath.Count));
            }
            else if (node.Children.Count > 0 || currentSum < sum)
            {
                foreach (var child in node.Children)
                {
                    currentPath.Add(child.Value);
                    FindPathWithSumS(child, treePaths, currentPath, sum);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }

        private static void FindSubtreeWithSumS(Node<int> node, List<List<int>> treePaths, List<int> currentPath, int sum)
        {
            Queue<Node<int>> nodes = new Queue<Node<int>>();
            Node<int> currentNode;
            nodes.Enqueue(node);
            int currentSum = node.Value;
            while (nodes.Count > 0)
            {
                if (currentSum > sum)
                {
                    break;
                }

                currentNode = nodes.Peek();
                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                    currentSum += child.Value;
                }

                currentPath.Add(nodes.Dequeue().Value);
            }

            if (currentSum == sum)
            {
                treePaths.Add(currentPath.GetRange(0, currentPath.Count));
            }
        }
    }
}
