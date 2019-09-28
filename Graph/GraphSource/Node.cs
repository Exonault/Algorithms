using System;
using System.Collections.Generic;

namespace Graph.GraphSource
{
    public class Node<T> where T: IComparable
    {
        public T Value { get; private set; }

        public List<Node<T>> Neighbours { get; private set; }
        
        public Node(T value)
        {
            this.Value = value;
            this.Neighbours = new List<Node<T>>();
        }

    
    }
}