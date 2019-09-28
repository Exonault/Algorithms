using System;
using System.Collections.Generic;

namespace Tree.NormalTree
{
    public class TreeNode<T> where T : IComparable
    {
        public T Value { get; private set; }

        public TreeNode<T> Parent { get; private set; }

        public List<TreeNode<T>> Childrens { get; private set; }

        public TreeNode(T value, TreeNode<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
            this.Childrens = new List<TreeNode<T>>();
        }
    }
}