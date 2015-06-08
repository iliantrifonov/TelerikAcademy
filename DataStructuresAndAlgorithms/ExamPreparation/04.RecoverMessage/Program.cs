namespace _04.RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/432
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int messageParts = int.Parse(Console.ReadLine());
            var graph = new Dictionary<char, Node>();
            for (int i = 0; i < messageParts; i++)
            {
                var currentMessage = Console.ReadLine();
                for (int messageIndex = 0; messageIndex < currentMessage.Length; messageIndex++)
                {
                    var currentSymbol = currentMessage[messageIndex];
                    if (!graph.ContainsKey(currentSymbol))
                    {
                        graph.Add(currentSymbol, new Node(currentSymbol));
                    }

                    for (int k = 0; k < messageIndex; k++)
                    {
                        graph[currentSymbol].Parents.Add(graph[currentMessage[k]]);
                        graph[currentMessage[k]].Children.Add(graph[currentSymbol]);
                    }
                }
            }

            var result = TopologicalSort(graph);
            var sb = new StringBuilder(100);
            for (int i = 0; i < result.Count; i++)
            {
                sb.Append(result[i].Symbol);
            }

            Console.WriteLine(sb.ToString());
        }

        private static List<Node> TopologicalSort(IDictionary<char, Node> graph)
        {
            var listOfSortedElements = new List<Node>(100);
            var setOfNoIncomingEdges = new SortedSet<Node>();
            foreach (var node in graph.Values)
            {
                if (node.Parents.Count == 0)
                {
                    setOfNoIncomingEdges.Add(node);
                }
            }

            while (setOfNoIncomingEdges.Count != 0)
            {
                var node = setOfNoIncomingEdges.Min;
                setOfNoIncomingEdges.Remove(node);

                listOfSortedElements.Add(node);
                var childsAsList = node.Children.ToArray();

                for (int i = 0; i < childsAsList.Length; i++)
                {
                    var child = childsAsList[i];
                    node.Children.Remove(child);
                    child.Parents.Remove(node);
                    if (child.Parents.Count == 0)
                    {
                        setOfNoIncomingEdges.Add(child);
                    }
                }
            }

            return listOfSortedElements;
        }
    }
}
