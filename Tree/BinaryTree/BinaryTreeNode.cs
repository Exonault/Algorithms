using System;

namespace Tree.BinaryTree
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Value { get; private set; }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public BinaryTreeNode(T value, BinaryTreeNode<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
            this.LeftChild = null;
            this.RightChild = null;
        }
    }
}