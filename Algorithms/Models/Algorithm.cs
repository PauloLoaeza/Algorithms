using System.Collections.Generic;

namespace Algorithms.Models
{
    public class Algorithm
    {
        public List<T> BFS<T>(Graph<T> graph, T start, T end)
        {
            var queue = new Queue<T>();
            queue.Enqueue(start);

            var visited = new HashSet<T> {start};
            var prev = new Dictionary<T, T>();

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var neighbors = graph.GetNeighbors(current);

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                        prev[neighbor] = current;
                    }
                }
            }

            return GetShortestPath(start, end, prev);
        }

        private List<T> GetShortestPath<T>(T start, T end, Dictionary<T, T> prev)
        {
            var path = new List<T>();

            var current = end;
            while (prev.ContainsKey(current))
            {
                path.Add(current);
                current = prev[current];
            }

            path.Add(current);
            path.Reverse();

            return path[0].Equals(start) ? path : new List<T>();
        }
    }
}
