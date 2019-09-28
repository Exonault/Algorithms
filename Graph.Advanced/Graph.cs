using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Graph.Advanced
{
    public class Graph<T> where T : IComparable
    {
        private List<Edge<T>> _edges;
        private List<T> _nodes;

        public Graph()
        {
            this._edges = new List<Edge<T>>();
            this._nodes = new List<T>();
        }

        public void Add(T parent, T child, int weight)
        {
            this._edges.Add(new Edge<T>(parent, child, weight));
            bool hasFoundParent = false;
            bool hasFoundChild = false;
            for (int i = 0; i < _nodes.Count && (!hasFoundChild || !hasFoundParent); i++)
            {
                if (this._nodes[i].CompareTo(parent) == 0)
                {
                    hasFoundParent = true;
                }

                if (this._nodes[i].CompareTo(child) == 0)
                {
                    hasFoundChild = true;
                }
            }

            if (hasFoundParent)
            {
                this._nodes.Add(parent);
            }

            if (hasFoundChild)
            {
                this._nodes.Add(child);
            }
        }

        public void MST(Action<Edge<T>> action)
        {
            HashSet<Edge<T>> mstEdges = new HashSet<Edge<T>>();

            int[] parents = new int[this._nodes.Count];

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }

            foreach (var edge in this._edges.OrderBy(edge => edge.Weight))
            {
                int parentIndex = this._nodes.IndexOf(edge.Parent);
                int childIndex = this._nodes.IndexOf(edge.Child);

                if (parents[parentIndex]
                    !=
                    parents[childIndex])
                {
                    mstEdges.Add(edge);
                    this.Union(parents, parentIndex, childIndex);
                }
            }

            foreach (var mstEdge in mstEdges)
            {
                action.Invoke(mstEdge);
            }
        }

        public List<T> Dijkstra(T start, T end)
        {
            Dictionary<T, int> distances = new Dictionary<T, int>();
            int[] prev = new int[this._nodes.Count];
            Queue<T> queue = new Queue<T>();

            foreach (var node in this._nodes)
            {
                distances[node] = int.MaxValue;
            }

            queue.Enqueue(start);
            this.GetPriorityQueue(queue, distances);

            while (queue.Count > 0)
            {
                T currentNode = queue.Dequeue();

                if (currentNode.Equals(end))
                {
                    break;
                }

                foreach (var edge in this._edges
                    .Where(edge => edge.Parent
                                       .CompareTo(currentNode) == 0))
                {
                    if (distances[edge.Child] > distances[currentNode] + edge.Weight)
                    {
                        distances[edge.Child] =
                            distances[currentNode] + edge.Weight;

                        prev[this._nodes.IndexOf(edge.Child)] =
                            this._nodes.IndexOf(currentNode);
                    }

                    queue.Enqueue(edge.Child);
                }
            }

            List<T> path = new List<T>();

            int currIndex = this._nodes.IndexOf(end);

            int lastIndex = this._nodes.IndexOf(start);

            while (currIndex != lastIndex)
            {
                path.Add(this._nodes[currIndex]);
                currIndex = prev[lastIndex];
            }

            path.Add(this._nodes[lastIndex]);
            path.Reverse();
            return path;
        }

        private void GetPriorityQueue(Queue<T> queue, Dictionary<T, int> distances)
        {
            int queueCount = queue.Count;

            foreach (var item in distances.OrderBy(x => x.Value))
            {
                if (queue.Contains(item.Key))
                {
                    queue.Enqueue(item.Key);
                }
            }

            for (int i = 0; i < queueCount; i++)
            {
                queue.Dequeue();
            }
        }

        private void Union(int[] parents, int parent, int child)
        {
            parents[child] = FindParent(parents, parent);
        }

        private int FindParent(int[] parents, int parent)
        {
            while (parents[parent] != parent)
            {
                parent = parents[parent];
            }

            return parent;
        }
    }
}