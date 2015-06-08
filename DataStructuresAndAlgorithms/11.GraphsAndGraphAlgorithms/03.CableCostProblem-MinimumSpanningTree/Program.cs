namespace _03.CableCostProblem_MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// You are given a cable TV company. The company needs to lay cable to a 
    /// new neighborhood (for every house). If it is constrained to bury the 
    /// cable only along certain paths, then there would be a graph representing
    /// which points are connected by those paths. But the cost of some of the
    /// paths is more expensive because they are longer. If every house is a node
    /// and every path from house to house is an edge, find a way to minimize the
    /// cost for cables.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var priority = new SortedSet<Edge>();
            int numberOfNodes = 6;
            int[] used = new int[numberOfNodes + 1]; //we start from 1, not from 0
            var minimumSpanningEdges = new List<Edge>();
            var edges = new List<Edge>();

            InitializeGraph(edges);

            int treesCount = Kruskal.FindMinimumSpanningTree(edges, used, minimumSpanningEdges);
           // Prim.FindMinimumSpanningTree(used, priority, minimumSpanningEdges, edges);
            PrintMinimumSpanningTree(minimumSpanningEdges);
        }

        

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> usedEdges)
        {
            foreach (var edge in usedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(1, 4, 9));
            edges.Add(new Edge(2, 4, 2));
            edges.Add(new Edge(3, 4, 20));
            edges.Add(new Edge(3, 5, 7));
            edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(5, 6, 12));
        }
    }
}
