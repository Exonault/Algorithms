using System;

namespace Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree(T root)
        {
            this.Root = new BinaryTreeNode<T>(root, null);
        }

        public void Traverse(Action<T> action)
        {
            this.Traverse(this.Root, action);
        }


        public void Add(T value)
        {
            this.AddNode(value, this.Root);
        }

        public T Find(Func<T, bool> function)
        {
            var result = this.Find(this.Root, function).Value;
            if (result == null)
            {
                throw new ArgumentException("Didnt find it");
            }

            return result;
        }

        public bool Contains(T value)
        {
            return this.Find(this.Root, (x) => x != null && x.CompareTo(value) == 0) != null;
        }

        public void Remove(T value)
        {
            var node = this.Find(this.Root, (x) => x.CompareTo(value) == 0);

            if (node == null)
            {
                throw new ArgumentException("Not such element");
            }

            if (node == this.Root)
            {
                var currNode = node.RightChild;

                if (currNode == null)
                {
                    currNode = node.LeftChild;
                    currNode.Parent = null;
                    this.Root = currNode;  
                }

                else
                {
                    while (currNode.LeftChild != null)
                    {
                        currNode = currNode.LeftChild;
                        
                        currNode.Parent = null;
                        currNode.LeftChild = this.Root.LeftChild;
                        this.Root = currNode;
                        this.Root.LeftChild = this.Root;
                        this.Root.RightChild.Parent = this.Root;
                    }

                    if (currNode.Parent != this.Root)
                    {
                        currNode.Parent.LeftChild = currNode.RightChild;
                        currNode.RightChild = this.Root.RightChild;
                    }
                    
                    currNode.Parent = null;
                    currNode.LeftChild = this.Root.LeftChild;
                    this.Root = currNode;
                    this.Root.LeftChild = this.Root;
                    this.Root.RightChild.Parent = this.Root;
                }

               

                return;
            }

            if (node.Value.CompareTo(node.Parent.Value) >= 0)
            {
                if (node.RightChild != null)
                {
                    node.Parent.RightChild = node.RightChild;
                    node.RightChild.Parent = node.Parent;

                    var currentNode = node.RightChild.LeftChild;

                    while (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                    }

                    currentNode.LeftChild = node.LeftChild;
                }
                else if (node.LeftChild != null)
                {
                    node.Parent.RightChild = node.LeftChild;
                    node.LeftChild.Parent = node.Parent;
                }
                else
                {
                    if (node.Value.CompareTo(node.Parent.Value) >= 0)
                    {
                        node.Parent.RightChild = null;
                    }
                    else
                    {
                        node.Parent.LeftChild = null;
                    }
                }
            }

            else
            {
                if (node.RightChild != null)
                {
                    node.Parent.LeftChild = node.RightChild;
                    node.RightChild.Parent = node.Parent;

                    var currentNode = node.RightChild;

                    while (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                    }

                    currentNode.LeftChild = node.LeftChild;
                }
                else if (node.LeftChild != null)
                {
                    node.Parent.LeftChild = node.LeftChild;
                    node.LeftChild.Parent = node.Parent;
                }
                else
                {
                    if (node.Value.CompareTo(node.Parent.Value) >= 0)
                    {
                        node.Parent.RightChild = null;
                    }
                    else
                    {
                        node.Parent.LeftChild = null;
                    }
                }
            }
        }

        private void AddNode(T value, BinaryTreeNode<T> currentNode)
        {
            if (currentNode.Value.CompareTo(value) > 0)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = new BinaryTreeNode<T>(value, currentNode);
                }
                else
                {
                    this.AddNode(value, currentNode.LeftChild);
                }
            }
            else
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = new BinaryTreeNode<T>(value, currentNode);
                }
                else
                {
                    this.AddNode(value, currentNode.RightChild);
                }
            }
        }

        private void Traverse(BinaryTreeNode<T> currentNode, Action<T> action)
        {
            if (currentNode == null)
            {
                currentNode = this.Root;
            }

            if (currentNode.LeftChild != null)
            {
                Traverse(currentNode.LeftChild, action);
            }

            action.Invoke(currentNode.Value);

            if (currentNode.RightChild != null)
            {
                Traverse(currentNode.RightChild, action);
            }
        }


        private BinaryTreeNode<T> Find(BinaryTreeNode<T> currentNode, Func<T, bool> func)
        {
            BinaryTreeNode<T> result = null;


            if (currentNode.LeftChild != null)
            {
                result = Find(currentNode.LeftChild, func);
            }

            if (result != null && func.Invoke(currentNode.Value))
            {
                result = currentNode;
            }

            if (result != null && currentNode.RightChild != null)
            {
                result = Find(currentNode.RightChild, func);
            }

            return result;
        }
    }
}