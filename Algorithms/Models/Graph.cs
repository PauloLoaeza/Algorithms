using System.Collections.Generic;

namespace Algorithms.Models
{
    public class Graph<T>
    {
        public IEnumerable<T> Vertices { get; set; }
        public IEnumerable<(T, T)> Edges { get; set; }

        private readonly Dictionary<T, HashSet<T>> _adjacentList = new Dictionary<T, HashSet<T>>();

        public Graph(IEnumerable<T> vertices, IEnumerable<(T, T)> edges)
        {
            Vertices = vertices;
            Edges = edges;

            BuildAdjacentList();
        }

        public HashSet<T> GetNeighbors(T vertex) =>
            _adjacentList.ContainsKey(vertex) ? _adjacentList[vertex] : new HashSet<T>();

        private void BuildAdjacentList()
        {
            foreach (var vertex in Vertices)
            {
                _adjacentList[vertex] = new HashSet<T>();
            }

            foreach (var (a, b) in Edges)
            {
                if (!_adjacentList.ContainsKey(a) || !_adjacentList.ContainsKey(b))
                {
                    continue;
                }
                    
                _adjacentList[a].Add(b);
                _adjacentList[b].Add(a);
            }
        }
    }
}
