namespace _01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// downloads.academy.telerik.com/svn/intro-algorithms/2014/11.%20Graphs%20and%20Graph%20Algorithms/Graphs-and-Graph-Algorithms-Homework.rar
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int nodeCount = input[0];
            int connectionCount = input[1];
            int hospitalCount = input[2];

            var hospitals = Console.ReadLine().Split(' ').Select(int.Parse);
            var hospitalsHash = new HashSet<int>(hospitals);
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            Dictionary<int, Node> nodesByValue = new Dictionary<int,Node>();
            for (int i = 0; i < connectionCount; i++)
            {
                var connection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                long connectionDistance = connection[2];
                var firstNodeValue = connection[0];
                var secondNodeValue = connection[1];
                if (!nodesByValue.ContainsKey(firstNodeValue))
                {
                    nodesByValue.Add(firstNodeValue, new Node(firstNodeValue));
                    graph.Add(nodesByValue[firstNodeValue], new List<Connection>());
                }

                if (!nodesByValue.ContainsKey(secondNodeValue))
                {
                    nodesByValue.Add(secondNodeValue, new Node(secondNodeValue));
                    graph.Add(nodesByValue[secondNodeValue], new List<Connection>());
                }

                var firstNode = nodesByValue[firstNodeValue];
                var secondNode = nodesByValue[secondNodeValue];

                graph[firstNode].Add(new Connection(firstNode, secondNode, connectionDistance));
                graph[secondNode].Add(new Connection(secondNode, firstNode, connectionDistance));
            }

            long minDistance = long.MaxValue;
            foreach (var hospital in hospitalsHash)
            {
                GetDjikstraDistance(nodesByValue[hospital], graph);
                long currentResult = 0;
                foreach (var node in graph.Keys)
                {
                    if (hospitalsHash.Contains(node.Name))
                    {
                        continue;
                    }

                    currentResult += node.DjikstraDistance;
                }

                if (currentResult < minDistance)
                {
                    minDistance = currentResult;
                }
            }

            Console.WriteLine(minDistance);
        }

        private static void GetDjikstraDistance(Node startNode, Dictionary<Node, List<Connection>> graph)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph.Keys)
            {
                node.DjikstraDistance = long.MaxValue;
                queue.Enqueue(node);
            }

            queue.Remove(startNode);

            startNode.DjikstraDistance = 0;
            queue.Enqueue(startNode);

            while (queue.Count != 0)
            {
                var smallest = queue.Dequeue();
                if (smallest.DjikstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var connection in graph[smallest])
                {
                    var potentialDistance = smallest.DjikstraDistance + connection.Distance;

                    if (potentialDistance < connection.To.DjikstraDistance)
                    {
                        var toNode = connection.To;

                        queue.Remove(toNode);
                        toNode.DjikstraDistance = potentialDistance;
                        queue.Enqueue(toNode);
                    }
                }
            }
        }
    }
}
