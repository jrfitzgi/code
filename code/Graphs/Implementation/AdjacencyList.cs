using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.Implementation
{
    public class AdjacencyList : GraphBase
    {
        private List<int>[] data;
        private int size;

        public AdjacencyList(bool isDirected, int size) : base(isDirected)
        {
            this.data = new List<int>[size];
            this.size = size;

            for (int i=0; i < this.size; i++)
            {
                this.data[i] = new List<int>();
            }
        }

        public override void AddEdge(int v1, int v2)
        {
            this.data[v1].Add(v2);

            if (!this.IsDirected)
            {
                data[v2].Add(v1);
            }
        }

        public override void BFS(int start)
        {
            bool[] visited = new bool[this.size];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            visited[start] = true;

            while (q.Count() > 0)
            {
                int node = q.Dequeue();
                Console.Write(node + ".");

                List<int> adjacent = this.data[node];
                for (int i=0; i < adjacent.Count; i++)
                {
                    if (!visited[adjacent[i]])
                    {
                        q.Enqueue(adjacent[i]);
                        visited[adjacent[i]] = true;
                    }
                }
            }

            Console.WriteLine();
        }

        public void BFS2(int start)
        {
            bool[] visited = new bool[this.size];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            visited[start] = true;
            
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                Console.Write(v + ",");

                // visit each node
                List<int> adjacent = this.data[v];
                for (int i=0; i < adjacent.Count; i++)
                {
                    if (visited[adjacent[i]] == false)
                    {
                        q.Enqueue(adjacent[i]);
                        visited[adjacent[i]] = true;
                    }
                }
            }

            Console.WriteLine();
        }

        public override bool CycleExists()
        {
            if (this.IsDirected)
            {
                return this.CycleExists_Directed();
            }
            else
            {
                return this.CycleExists_Undirected();
            }
        }

        /// <summary>
        /// implemented for undirected only
        /// </summary>
        /// <returns></returns>
        private bool CycleExists_Directed()
        {
            bool[] visited = new bool[this.size];
            bool[] recursionStack = new bool[this.size]; // keeps track of which vertices are in the recursion stack

            for (int i=0; i < this.size; i++)
            {
                if (visited[i] == true) { continue; }

                if (this.CycleHelper_Directed(visited, recursionStack, i)) { return true; }
            }

            return false;
        }

        private bool CycleHelper_Directed(bool[] visited, bool[] recursionStack, int v)
        {
            if (recursionStack[v] == true) { return true; } // cycle exists

            if (visited[v] == true) { return false; } // already visited, don't visit again

            // put v on the recursion stack then iterate its adjacent vertices
            recursionStack[v] = true;
            visited[v] = true;

            List<int> adj = this.data[v];
            for (int i=0; i < adj.Count; i++)
            {
                if (this.CycleHelper_Directed(visited, recursionStack, adj[i]) == true) { return true; }
            }

            recursionStack[v] = false;

            return false;

        }

        private bool CycleExists_Undirected()
        {
            bool[] visited = new bool[this.size];

            for (int i=0; i < this.size; i++)
            {
                if (visited[i] == true) { continue; }

                if (this.CycleHelper_Undirected(visited, i, -1) == true) { return true; }
            }

            return false;
        }

        private bool CycleHelper_Undirected(bool[] visited, int v, int parent)
        {
            visited[v] = true;

            List<int> adj = this.data[v];
            for (int i = 0; i < adj.Count; i++)
            {
                if (visited[adj[i]] == false)
                {
                    if (this.CycleHelper_Undirected(visited, adj[i], v) == true) { return true; }
                }
                else if (adj[i] != parent)
                {
                    return true;
                }

            }

            return false;
        }

        public override void DFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();

            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            visited.Add(start);

            while (stack.Count() > 0)
            {
                int node = stack.Pop();
                Console.Write(node + ".");
                
                List<int> adjacent = this.data[node];
                for (int i=0; i < adjacent.Count(); i++)
                {
                    int child = adjacent[i];
                    if (!visited.Contains(child))
                    {
                        stack.Push(child);
                        visited.Add(child);
                    }
                }

            }

            Console.WriteLine();

        }

        public void DFS2(int start)
        {
            HashSet<int> visited = new HashSet<int>();

            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            visited.Add(start);

            while (stack.Count > 0)
            {
                int v = stack.Pop();

                Console.Write(v + ",");

                List<int> adjacent = this.data[v];
                for (int i=0; i < adjacent.Count; i++)
                {
                    if (!visited.Contains(adjacent[i]))
                    {
                        stack.Push(adjacent[i]);
                        visited.Add(adjacent[i]);
                    }
                }
            }

            Console.WriteLine();

        }

        public override bool EdgeExists(int v1, int v2)
        {
            List<int> adjacent = this.data[v1];

            for (int i=0; i < adjacent.Count; i++)
            {
                if (adjacent[i] == v2) { return true; }
            }

            return false;
        }

        public override void FindAdjacent(int v)
        {
            Console.Write($"Adjacent to {v}: ");

            List<int> adj = this.data[v];
            for (int i=0; i < adj.Count; i++)
            {
                Console.Write($"{adj[i]},");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Returns number of vertices visited. Should udpate this to return path length.
        /// </summary>
        public override int PathExists(int v1, int v2)
        {
            int visitCount = 0;
            HashSet<int> visited = new HashSet<int>();

            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            q1.Enqueue(v1);
            visited.Add(v1);
            visitCount++;

            q2.Enqueue(v2);
            visited.Add(v2);
            visitCount++;

            while (q1.Count > 0)
            {
                int v = q1.Dequeue();

                if (v == v2) { return visitCount; }

                List<int> adj = this.data[v];
                for (int i=0; i < adj.Count; i++)
                {
                    if (!visited.Contains(adj[i]))
                    {
                        q1.Enqueue(adj[i]);
                        visited.Add(adj[i]);
                        visitCount++;
                    }
                }

                // swap queues
                if (q2.Count > 0)
                {
                    Queue<int> temp = q1;
                    q1 = q2;
                    q2 = temp;
                }

            }

            return -1;
        }

        public override void RemoveEdge(int v1, int v2)
        {
            this.RemoveEdgeHelper(v1, v2);

            if (!this.IsDirected)
            {
                this.RemoveEdgeHelper(v2, v1);
            }
        }

        private void RemoveEdgeHelper(int v1, int v2)
        {
            List<int> adj = this.data[v1];

            for (int i = 0; i < adj.Count; i++)
            {
                if (adj[i] == v2)
                {
                    adj.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// remove all edges to/from a vertex
        /// </summary>
        /// <param name="v"></param>
        public override void RemoveVertex(int v)
        {
            for (int i=0; i < this.size; i++)
            {
                List<int> adj = this.data[i];
                for (int j = 0; j < adj.Count; j++)
                {
                    if (adj[j] == v) { adj.RemoveAt(j); }
                }
            }

            this.data[v] = new List<int>();
        }

        public override void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[this.size];

            for (int i=0; i < this.data.Length; i++)
            {
                TopologicalSort_Helper(i, stack, visited);
            }

            while (stack.Count() > 0)
            {
                Console.Write(stack.Pop() + ".");
            }

            Console.WriteLine();
        }

        private void TopologicalSort_Helper(int v, Stack<int> stack, bool[] visited)
        {
            if (visited[v]) { return; }
            visited[v] = true;

            List<int> adj = this.data[v];
            for (int i=0; i < adj.Count(); i++)
            {
                int child = adj[i];
                TopologicalSort_Helper(child, stack, visited);
            }

            stack.Push(v);
        }

        #region Topological Sort

        public void TopologicalSort2()
        {
            if (this.IsDirected == false)
            {
                Console.WriteLine("Topological sort only applies to Directed graph");
                return;
            }

            if (this.CycleExists())
            {
                Console.WriteLine("Topological sort only applies to Acyclic graph");
                return;
            }

            Stack<int> sorted = new Stack<int>();
            bool[] visited = new bool[this.size];

            for (int i=0; i < this.size; i++)
            {
                this.TopologicalSort_Helper2(sorted, visited, i);
            }

            while (sorted.Count > 0)
            {
                Console.Write(sorted.Pop() + ",");
            }

            Console.WriteLine();
        }

        private void TopologicalSort_Helper2(Stack<int> sorted, bool[] visited, int v)
        {
            if (visited[v] == true) { return; }

            visited[v] = true;

            List<int> adj = this.data[v];
            for (int i=0; i < adj.Count; i++)
            {
                this.TopologicalSort_Helper2(sorted, visited, adj[i]);
            }

            sorted.Push(v);
        }

        #endregion
    }
}
