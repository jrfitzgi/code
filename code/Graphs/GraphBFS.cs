using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    public partial class Graph
    {
        public HashSet<int> BFS(Graph g, int start)
        {
            if (g == null) { return null; }
            if (!g.AdjacencyList.ContainsKey(start)) { return null; }

            HashSet<int> visited = new HashSet<int>(); // visited nodes

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);

            while (q.Count() > 0)
            {
                int vertex = q.Dequeue();

                if (visited.Contains(vertex)) { continue; } // already visisted so skip it

                visited.Add(vertex);
                foreach (int adjacent in g.AdjacencyList[vertex])
                {
                    if (!visited.Contains(adjacent))
                    {
                        q.Enqueue(adjacent);
                    }
                }

            }
            

            return visited;
        }
    }
}
