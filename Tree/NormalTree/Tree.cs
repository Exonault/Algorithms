using System;

namespace Tree.NormalTree
{
    public class Tree<T> where T : IComparable
    {
        public TreeNode<T> Root { get; private set; }

        public Tree(T root)
        {
            this.Root = new TreeNode<T>(root, null);
        }

        public void Add(T value)
        {
            this.Root.Childrens.Add(new TreeNode<T>(value, this.Root));
        }

        public void Add(T value, T element)
        {
            var foundNode = FindNode(element, this.Root);

            if (foundNode == null)
            {
                throw new ArgumentException("No element");
            }
            else foundNode.Childrens.Add(new TreeNode<T>(value,foundNode));
        }

        public void PrintTreeDFS(TreeNode<T> currentNode = null)
        {
            if (currentNode == null)
            {
                currentNode = this.Root;
            }

            Console.Write(currentNode.Value + " ");
            foreach (var nodeChildren in currentNode.Childrens)
            {
                PrintTreeDFS(nodeChildren);
            }
        }
        
        private TreeNode<T> FindNode(T value, TreeNode<T> currentNode)
        {
            if (currentNode.Value.CompareTo(value) == 0)
            {
                return currentNode;
            }


            foreach (var nodeChildren in currentNode.Childrens)
            {
                var result = FindNode(value, nodeChildren);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}