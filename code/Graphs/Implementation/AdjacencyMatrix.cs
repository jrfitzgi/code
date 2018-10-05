using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.Implementation
{
    public class AdjacencyMatrix : GraphBase
    {
        int[,] Matrix;
        int Size;

        public override bool IsDirected { get; set; }

        public AdjacencyMatrix(int size, bool isDirected) : base(isDirected)
        {
            this.Matrix = new int[size, size];
            this.Size = size;
        }

        public override void AddEdge(int v1, int v2)
        {
            this.AddEdgeHelper(v1, v2);

            if (!this.IsDirected)
            {
                this.AddEdgeHelper(v2, v1);
            }
        }

        private void AddEdgeHelper(int v1, int v2)
        {
            this.Matrix[v1, v2] = 1;
        }

        public override void BFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            visited.Add(start);

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                Console.Write($"{v},");

                for (int i=0; i < this.Size; i++)
                {
                    int v2 = this.Matrix[v, i];
                    if (v2 == 1 && !visited.Contains(i))
                    {
                        q.Enqueue(i);
                        visited.Add(i);
                    }
                }

            }

            Console.WriteLine();
        }

        public override bool CycleExists()
        {
            bool[] recStack = new bool[this.Size];
            bool[] visited = new bool[this.Size];

            for (int i=0; i < this.Size; i++)
            {
                if (CycleHelper(i,recStack, visited))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CycleHelper(int v, bool[] recStack, bool[] visited)
        {
            if (recStack[v] == true) { return true; }

            if (visited[v] == true) { return false; }

            visited[v] = true;

            // We will switch this back later after the recursive call
            recStack[v] = true;
            

            for (int i=0; i < this.Size; i++)
            {
                if (this.Matrix[v,i] == 1) // edge
                {
                    if (this.CycleHelper(i, recStack, visited) == true) { return true; }
                }
            }

            recStack[v] = false;

            return false;
        }

        public override void DFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();

            Stack<int> s = new Stack<int>();
            s.Push(start);
            visited.Add(start);

            while (s.Count > 0)
            {
                int v1 = s.Pop();

                Console.Write(v1 + ",");

                for (int v2=0; v2 < this.Size; v2++)
                {
                    if (this.Matrix[v1,v2] == 1 && !visited.Contains(v2))
                    {
                        s.Push(v2);
                        visited.Add(v2);
                    }
                }
            }


            Console.WriteLine();
        }

        public override bool EdgeExists(int v1, int v2)
        {
            return (this.Matrix[v1, v2] == 1);
        }

        public override void FindAdjacent(int v)
        {
            Console.Write("Adjacent to " + v + ": ");

            for (int v2 = 0; v2 < this.Size; v2++)
            {
                if (this.Matrix[v,v2] == 1)
                {
                    Console.Write(v2 + ",");
                }
            }

            Console.WriteLine();
        }

        public override int PathExists(int v1, int v2)
        {
            HashSet<int> visited = new HashSet<int>();

            Queue<int> q = new Queue<int>();
            q.Enqueue(v1);
            visited.Add(v1);

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                if (v == v2) { return 1; }

                for (int i = 0; i < this.Size; i++)
                {
                    if (this.Matrix[v,i] == 1 && !visited.Contains(i))
                    {
                        q.Enqueue(i);
                        visited.Add(i);
                    }
                }

            }

            return -1;
        }

        public override void RemoveEdge(int v1, int v2)
        {
            RemoveEdgeHelper(v1, v2);

            if (!this.IsDirected)
            {
                RemoveEdgeHelper(v2, v1);
            }
        }

        private void RemoveEdgeHelper(int v1, int v2)
        {
            this.Matrix[v1, v2] = 0;
        }

        public override void RemoveVertex(int v)
        {
        }

        public override void TopologicalSort()
        {
            throw new NotImplementedException();
        }
    }
}
