using System;
using Algorithms.Models;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]
            {
                (1, 2),
                (1, 3),
                (2, 4),
                (3, 5),
                (3, 6),
                (4, 7),
                (5, 7),
                (5, 8),
                (5, 6),
                (8, 9),
                (8, 10),
                (9, 10)
            };

            var graph = new Graph<int>(vertices, edges);
            var algorithm = new Algorithm();
            Console.WriteLine("Shorted path from 10 to 2:");
            Console.WriteLine(string.Join("->", algorithm.BFS(graph, 10, 2)));
        }
    }
}
