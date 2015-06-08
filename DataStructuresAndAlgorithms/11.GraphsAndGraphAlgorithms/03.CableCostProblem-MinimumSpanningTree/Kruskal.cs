namespace _03.CableCostProblem_MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Kruskal
    {
        public static int FindMinimumSpanningTree(List<Edge> edges, int[] used, List<Edge> minimumSpanningTree, int treesCount = 1)
        {
            edges.Sort();
            foreach (var edge in edges)
            {
                if (used[edge.StartNode] == 0) // not visited
                {
                    if (used[edge.EndNode] == 0) // both ends are not visited
                    {
                        used[edge.StartNode] = treesCount;
                        used[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        used[edge.StartNode] = used[edge.EndNode];
                    }

                    minimumSpanningTree.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (used[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        used[edge.EndNode] = used[edge.StartNode];
                        minimumSpanningTree.Add(edge);
                    }
                    else if (used[edge.EndNode] != used[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = used[edge.EndNode];

                        for (int i = 0; i < used.Length; i++)
                        {
                            if (used[i] == oldTreeNumber)
                            {
                                used[i] = used[edge.StartNode];
                            }
                        }

                        minimumSpanningTree.Add(edge);
                    }
                }
            }

            return treesCount;
        }
    }
}
