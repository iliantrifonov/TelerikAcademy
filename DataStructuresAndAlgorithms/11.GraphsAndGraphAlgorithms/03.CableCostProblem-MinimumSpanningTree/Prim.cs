namespace _03.CableCostProblem_MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Prim
    {
        public static void FindMinimumSpanningTree(int[] used, SortedSet<Edge> priority, List<Edge> minimumSpanningEdges, List<Edge> edges)
        {
            // adding edges that connect the node 1 with all the others
            foreach (Edge edge in edges)
            {
                if (edge.StartNode == edges[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (used[edge.EndNode] == 0) // not visited
                {
                    used[edge.EndNode] = 1; // we "visit" this node
                    minimumSpanningEdges.Add(edge);
                    AddEdges(edge, edges, minimumSpanningEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> minimumSpanningTree, SortedSet<Edge> priority, int[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!minimumSpanningTree.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && used[edges[i].EndNode] == 0)
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }
    }
}
