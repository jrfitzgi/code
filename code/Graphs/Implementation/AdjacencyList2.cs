using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.Implementation
{
    public class Edge
    {
        public int FromVertex;
        public int ToVertex;
        public int Weight;

        public Edge(int fromVertex, int toVertex)
            : this(fromVertex, toVertex, 0)
        {
        }

        public Edge(int fromVertex, int toVertex, int weight)
        {
            this.FromVertex = fromVertex;
            this.ToVertex = toVertex;
            this.Weight = weight;
        }

    }

    public class AdjacencyList2 : GraphBase
    {
        Dictionary<int, List<Edge>> Graph;

        public override bool IsDirected { get; set; }

        public AdjacencyList2(bool isDirected, int size)
        {
            this.IsDirected = isDirected;
            this.Graph = new Dictionary<int, List<Edge>>();

            for (int i=0; i < size; i++)
            {
                this.AddVertex(i);
            }
        }

        public void AddVertex(int v)
        {
            this.Graph.Add(v, new List<Edge>());
        }

        public override void AddEdge(int v1, int v2)
        {
            // TODO: check if edge exists

            List<Edge> adjacent = this.Graph[v1];
            adjacent.Add(new Edge(v1, v2));
        }

        public override void BFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            visited.Add(start);

            while (q.Count() > 0)
            {
                int v = q.Dequeue();
                this.Visit(v);

                foreach(Edge e in this.Graph[v])
                {
                    if (visited.Contains(e.ToVertex)) { continue; }
                    q.Enqueue(e.ToVertex);
                    visited.Add(e.ToVertex);
                }
            }


            Console.WriteLine();
        }

        private void Visit(int v)
        {
            Console.Write(v + ",");
        }

        public override bool CycleExists()
        {
            if (!IsDirected) { return false; }

            HashSet<int> visited = new HashSet<int>();

            foreach (int v in this.Graph.Keys)
            {
                if (CycleExists_Directed(v, new HashSet<int>(), visited) == true) { return true; }
            }

            return false;
        }

        private bool CycleExists_Directed(int v, HashSet<int> recursionStack, HashSet<int> visited)
        {

            if (recursionStack.Contains(v)) { return true; }
            if (visited.Contains(v)) { return false; }

            recursionStack.Add(v);
            visited.Add(v);

            foreach (Edge e in this.Graph[v])
            {
                if (CycleExists_Directed(e.ToVertex, recursionStack, visited) == true) { return true; }
            }

            recursionStack.Remove(v);

            return false;
        }

        public override void DFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();
            DFSHelper(start, visited);
            Console.WriteLine();
        }

        private void DFSHelper(int start, HashSet<int> visited)
        {
            Visit(start);
            visited.Add(start);

            foreach(Edge e in this.Graph[start])
            {
                if (visited.Contains(e.ToVertex)) { continue; }
                DFSHelper(e.ToVertex, visited);
            }
        }

        public override bool EdgeExists(int v1, int v2)
        {
            return false;
        }

        public override void FindAdjacent(int v)
        {
            return;
        }

        public override int PathExists(int v1, int v2)
        {
            return 0;
        }

        public override void RemoveEdge(int v1, int v2)
        {
            return;
        }

        public override void RemoveVertex(int v)
        {
            return;
        }

        public override void TopologicalSort()
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();
            
            foreach (int v in this.Graph.Keys)
            {
                if (visited.Contains(v)) { continue; }

                TopologicalHelper(visited, v, stack);
            }

            while (stack.Count() > 0)
            {
                Visit(stack.Pop());
            }
        }

        private void TopologicalHelper(HashSet<int> visited, int v, Stack<int> stack)
        {
            visited.Add(v);

            foreach (Edge e in this.Graph[v])
            {
                if (visited.Contains(e.ToVertex)) { continue; }

                TopologicalHelper(visited, e.ToVertex, stack);
            }

            stack.Push(v);
        }
    }
}
