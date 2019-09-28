using System;

namespace Graph.Advanced
{
    public class Edge<T> where T : IComparable
    {
        public T Parent { get; private set; }

        public T Child { get; private set; }

        public int Weight { get; private set; }

        public Edge(T parent, T child, int weight)
        {
            this.Parent = parent;
            this.Child = child;
            this.Weight = weight;
        }
    }
}