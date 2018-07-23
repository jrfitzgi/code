using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.Implementation
{
    public class GraphTests
    {
        public static void Run()
        {
            GraphTests.Test2();
        }

        private static void Test1()
        {
            GraphBase graph = new AdjacencyList(false, 10);
            //GraphBase graph = new AdjacencyMatrix(10, true);

            graph.AddEdge(1, 2);
            Console.WriteLine($"Cycle exists? {graph.CycleExists()}");

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 1); // creates cycle in directed graph
            graph.AddEdge(3, 6); // will remove
            graph.AddEdge(4, 6); // will remove


            Console.WriteLine($"Edge from 4 to 6? {graph.EdgeExists(4, 6)}");
            Console.WriteLine($"Path from 1 to 8? {graph.PathExists(1, 8)}");

            graph.FindAdjacent(3);

            graph.BFS(1);
            graph.DFS(1);

            graph.RemoveEdge(3, 6);
            graph.RemoveEdge(4, 6);
            graph.RemoveEdge(1, 7);


            Console.WriteLine($"Edge from 4 to 6? {graph.EdgeExists(4, 6)}");
            graph.FindAdjacent(3);

            graph.BFS(1);
            graph.DFS(1);

            Console.WriteLine($"Path from 1 to 8? {graph.PathExists(1, 8)}");
            Console.WriteLine($"Cycle exists? {graph.CycleExists()}");


        }

        private static void Test2()
        {
            GraphBase graph = new AdjacencyList(true, 6);

            graph.AddEdge(5, 0);
            graph.AddEdge(5, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);
            graph.AddEdge(4, 1); 
            graph.AddEdge(4, 0);

            Console.WriteLine($"Cycle exists? {graph.CycleExists()}");

            graph.TopologicalSort();

        }
    }
}
