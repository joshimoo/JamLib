using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.DataStructures.Trees
{
    public class BinarySearchTree<T> : ICollection<T>
    {
        private int count;
        public int Count { get { return count; } }
        public bool IsReadOnly { get { return false; } }

        // Root
        private BinarySearchTreeNode<T> root;
        private readonly Comparer<T> comparer;

        public BinarySearchTree(Comparer<T> comparer) { this.comparer = comparer; }
        public BinarySearchTree() { comparer = Comparer<T>.Default; }

        public void Add(T item)
        {
            // Create a new Node for this item
            BinarySearchTreeNode<T> node = new BinarySearchTreeNode<T>(item);
            BinarySearchTreeNode<T> current = root, parent = null;

            // Find the right spot to insert the element
            while (current != null)
            {
                int c = comparer.Compare(current.Value, item);

                // exit. the bst requires unique elements
                if (c == 0) { return; }
                else if (c > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (c < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }

            // Ready to add the node if the tree is empty add it as the root
            if (parent == null) { root = node; }
            else
            {
                int c = comparer.Compare(parent.Value, item);
                if (c > 0) { parent.Left = node; }
                else { parent.Right = node; }
            }
            count++;
        }

        public bool Remove(T item)
        {
            // No Items in the tree 
            if (root == null) { return false; }
            BinarySearchTreeNode<T> current = root, parent = null;

            /* HACK: This feels dirty, we can differentiate beetwen root node and not found by checking if the node is actually the root node 
            // If parent is null, we are the root node // 
            var parent = FindParent(item);
            if (parent != null)
            {
                int c = comparer.Compare(parent.Value, item);
                if (c > 0) { current = parent.Left; }
                else if (c < 0) { current = parent.Right; }
            }
            else
            {
                // Make sure we are actually the root node, if not then we could not find the item.
                if (comparer.Compare(root.Value, item) != 0) { return false; }
            }*/

            // Find the node in the tree
            while (current != null)
            {
                int c = comparer.Compare(current.Value, item);

                // found the node to delete
                if (c == 0) { break; }
                else if (c > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (c < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }

            // Could not find the node
            if (current == null) { return false; }

            RemoveNode(current, parent);
            return true;
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }


        public bool Contains(T item) { return Find(item) != null; }
        private BinarySearchTreeNode<T> Find(T item)
        {
            BinarySearchTreeNode<T> current = root;

            // Search for the element in the tree
            while (current != null)
            {
                int c = comparer.Compare(current.Value, item);

                // Found the element
                if (c == 0) { return current; }
                else if (c > 0) { current = current.Left; }
                else if (c < 0) { current = current.Right; }
            }

            return null;
        }
        private BinarySearchTreeNode<T> FindParent(T item)
        {
            BinarySearchTreeNode<T> current = root, parent = null;

            // Find the item
            while (current != null)
            {
                int c = comparer.Compare(current.Value, item);

                // exit. we found the item, return it's parent
                if (c == 0) { return parent; }
                else if (c > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (c < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }

            return null;
        }

        private void RemoveNode(BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> parent)
        {
            // delete the item and fix up the tree
            if (node == null) { throw new ArgumentNullException("node"); }
            BinarySearchTreeNode<T> target = null;
            count--;

            // Case 1: current has only smaller children, therefore the left side replaces current
            if (node.Right == null) { target = node.Left; }

            // Case 2: right side has only bigger children, therefore right side replaces current
            else if (node.Right.Left == null)
            {
                // Attach the left branch to the right branch
                target = node.Right;
                target.Left = node.Left;
            }

            // Case 3: right side has smaller children, find the smallest and replace current
            else
            {
                BinarySearchTreeNode<T> leftParent = node.Right;
                target = node.Right.Left;
                while (target.Left != null)
                {
                    leftParent = target;
                    target = target.Left;
                }

                // the parent's left subtree becomes the targets right subtree
                leftParent.Left = target.Right;

                // assign target's left and right to current's left and right children
                target.Left = node.Left;
                target.Right = node.Right;
            }

            // Attach the remaining
            if (parent == null) { root = target; }
            else
            {
                int c = comparer.Compare(parent.Value, node.Value);
                if (c > 0) { parent.Left = target; }
                else if (c < 0) { parent.Right = target; }
            }
        }

        // TODO: Implement an Enumerator
        public void CopyTo(T[] array, int arrayIndex) { throw new NotImplementedException(); }
        public IEnumerator<T> GetEnumerator() { throw new NotImplementedException(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        // TODO: Think about implementing a base node class, that we can reuse in all trees
        private class BinarySearchTreeNode<T>
        {
            private readonly BinarySearchTreeNode<T>[] nodes;
            public T Value { get; private set; }

            public BinarySearchTreeNode<T> Left
            {
                get { return nodes[0]; }
                set { nodes[0] = value; }
            }
            public BinarySearchTreeNode<T> Right
            {
                get { return nodes[1]; }
                set { nodes[1] = value; }
            }

            public BinarySearchTreeNode(T value)
            {
                Value = value;
                nodes = new BinarySearchTreeNode<T>[2];
            }
            public BinarySearchTreeNode(T value, BinarySearchTreeNode<T> left, BinarySearchTreeNode<T> right)
            {
                Value = value;
                nodes = new BinarySearchTreeNode<T>[2] { left, right };
            }
        }
    }
}
