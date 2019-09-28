using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Graph.GraphSource
{
    public class Graph<T> where T : IComparable
    {
        private List<Node<T>> _nodes;
        public IEnumerable<Node<T>> Nodes => this._nodes;

        public Graph()
        {
            this._nodes = new List<Node<T>>();
        }

        public void Add(T value)
        {
            this._nodes.Add(new Node<T>(value));
        }

        public void AddNeighbours(T parent, T neighbour)
        {
            Node<T> neighbourNode = null;
            Node<T> parentNode = null;

            foreach (var node in this._nodes)
            {
                if (node.Value.Equals(neighbour))
                {
                    neighbourNode = node;
                }

                if (node.Value.Equals(parent))
                {
                    parentNode = node;
                }

                if (neighbourNode != null && parentNode != null)
                {
                    break;
                }
            }

            if (neighbourNode == null || parentNode == null)
            {
                throw new ArgumentException("No");
            }

            parentNode.Neighbours.Add(neighbourNode);
        }

        public void TraverseBFS(T value, Action<T> action)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            HashSet<T> visited = new HashSet<T>();

            queue.Enqueue(this.FindNode(value));

            while (queue.Count > 0)
            {
                Node<T> currentNode = queue.Dequeue();

                if (!visited.Contains(currentNode.Value))
                {
                    visited.Add(currentNode.Value);
                    action.Invoke(currentNode.Value);

                    foreach (var node in currentNode.Neighbours)
                    {
                        queue.Enqueue(node);
                    }
                }
            }
        }

        public List<T> TopologicalSort()
        {
            List<T> result = new List<T>();

            HashSet<T> visited = new HashSet<T>();

            Node<T> currentNode = this._nodes.Where(node => !visited.Contains(node.Value))
                .FirstOrDefault(node => !this.HasParents(node, visited));

            while (currentNode != null)
            {
                result.Add(currentNode.Value);

                visited.Add(currentNode.Value);

                currentNode = this._nodes.Where(node => !visited.Contains(currentNode.Value))
                    .FirstOrDefault(node => !this.HasParents(node, visited));
            }

            return result;
        }

        public void CheckIfItWorks()
        {
            Graph<int> _graph = new Graph<int>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < nodes; i++)
            {
                _graph.Add(i);
            }

            for (int i = 0; i < edges; i++)
            {
                int[] connection = Console.ReadLine()
                    .Split(new char[] {' ', '-', '>'},
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                _graph.AddNeighbours(connection[0], connection[1]);
                _graph.AddNeighbours(connection[1], connection[0]);
            }
        }
        
        private bool HasParents(Node<T> currentNode, HashSet<T> visited)
        {
            foreach (var node in _nodes)
            {
                if (!visited.Contains(node.Value) && node.Neighbours.Contains(currentNode))
                {
                    return true;
                }
            }

            return false;
        }

        private Node<T> FindNode(T value)
        {
            foreach (var node in this._nodes)
            {
                if (node.Value.CompareTo(value) == 0)
                {
                    return node;
                }
            }

            return null;
        }
    }
}