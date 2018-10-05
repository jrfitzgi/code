using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.Implementation
{
    public abstract class GraphBase
    {
        public abstract bool IsDirected { get; set; }

        public GraphBase() : this(false)
        {
        }

        public GraphBase(bool isDirected)
        {
            this.IsDirected = isDirected;
        }

        public abstract void AddEdge(int v1, int v2);
        public abstract void RemoveVertex(int v);
        public abstract void RemoveEdge(int v1, int v2);
        public abstract bool EdgeExists(int v1, int v2);
        public abstract void FindAdjacent(int v);
        public abstract void BFS(int start);
        public abstract void DFS(int start);
        public abstract int PathExists(int v1, int v2);
        public abstract bool CycleExists();
        public abstract void TopologicalSort();

    }
}
