using System;
using System.Collections.Generic;

namespace code
{
    public partial class Graph
    {
        public Graph() { }
        public Graph(IEnumerable<int> vertices, IEnumerable<Tuple<int, int>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<int, HashSet<int>> AdjacencyList { get; } = new Dictionary<int, HashSet<int>>();

        public void AddVertex(int vertex)
        {
            AdjacencyList[vertex] = new HashSet<int>();
        }

        public void AddEdge(Tuple<int, int> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }
}