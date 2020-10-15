using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTree
{
    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();

                 
        }


        public Tree(T value, params Tree<T>[] children)
            :this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }


        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this._children;

        public bool IsRootDeleted { get; private set; }

        public void AddChild(T parentKey, Tree<T> child)
        {
            //Tree<T> searchedNode = FindBfs(parentKey);
            Tree<T> searchedNode = FindDfs(parentKey);

            CheckIfEmptyNode(searchedNode);

            searchedNode._children.Add(child);

        }

       

        public ICollection<Tree<T>> OrderBfs()
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            if (IsRootDeleted)
            {
                return result;
            }

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var subtree = queue.Dequeue();

                result.Add(subtree);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;

        }

        public ICollection<Tree<T>> OrderDfs()
        {
            var result = new List<Tree<T>>();

            if (IsRootDeleted)
            {
                return result;
            }

            //result = DfsIterally(this, result);
            result = DfsRecursively(this, result);

            return result;


        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBfs(nodeKey);

            CheckIfEmptyNode(searchedNode);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;

            }

            searchedNode._children.Clear();

            var searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {

                searchedParent._children.Remove(searchedNode);
                searchedNode.Parent = null;
            }

            searchedNode.Value = default(T);

        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);

            var firstNodeParent = firstNode.Parent;
            var secondNodeParent = secondNode.Parent;

            int indexOfFirst = firstNodeParent._children.IndexOf(firstNode);
            int indexOfSecond = secondNodeParent._children.IndexOf(secondNode);

            firstNodeParent._children[indexOfFirst] = secondNode;
            secondNodeParent._children[indexOfSecond] = firstNode;

        }

        private List<Tree<T>> DfsRecursively(Tree<T> tree, List<Tree<T>> result)
        {
            foreach (var child in tree.Children)
            {
                this.DfsRecursively(child, result);

            }

            result.Add(tree);

            return result;
        }

        private List<Tree<T>> DfsIterally(Tree<T> tree, List<Tree<T>> result)
        {
            var tempRes = new Stack<Tree<T>>();
            var stack = new Stack<Tree<T>>();

            stack.Push(tree);

            while (stack.Count != 0)
            {
                var subtree = stack.Pop();
                tempRes.Push(subtree);

                foreach (var child in subtree.Children)
                {
                    stack.Push(child);

                }

            }

            result = new List<Tree<T>>(tempRes);
            return result;
        }

        private void CheckIfEmptyNode(Tree<T> searchedNode)
        {
            if (searchedNode == null)
            {
                throw new ArgumentNullException("The node is empty!");

            }


        }

        private Tree<T> FindDfs(T parentKey)
        {
            var tree = OrderDfs();

            foreach (var item in tree)
            {
                if (item.Value.Equals(parentKey))
                {
                    return item;

                }

            }


            return null;
        }

        private Tree<T> FindBfs(T parentKey)
        {

            var tree = OrderBfs();

            foreach (var item in tree)
            {
                if (item.Value.Equals(parentKey))
                {
                    return item;

                }

            }

            return null;

        }
    }
}
