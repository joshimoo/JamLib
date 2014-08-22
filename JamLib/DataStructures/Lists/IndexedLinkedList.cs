using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.DataStructures.Lists
{
    /// <summary>
    /// NOTE: DO NOT USE THIS CLASS, It's an abomination since it's indexer runs in O(n) which nobody expects from an IList<T>
    /// </summary>
    public class IndexedLinkedList<T> : IList<T>
    {
        private int count;
        public int Count { get { return count; } }
        public bool IsReadOnly { get { return false; } }

        private IndexedLinkedListNode<T> head;
        private IndexedLinkedListNode<T> tail;

        // Adds to the end of the list
        public void Add(T value)
        {
            var node = new IndexedLinkedListNode<T>(value);

            if (head == null) { head = node; }
            else
            {
                tail.Next = node;
                node.Prev = tail;
            }

            tail = node;
            count++;
        }

        // TODO: Cleanup Parameter Schemen, either go with value or go with item
        private void AddAfter(IndexedLinkedListNode<T> node, T value) { AddAfter(node, new IndexedLinkedListNode<T>(value)); }
        private void AddAfter(IndexedLinkedListNode<T> node, IndexedLinkedListNode<T> newNode)
        {
            if (node == null) { throw new ArgumentNullException(); }
            if (node == tail)
            {
                // TODO: Could be possible null, if tail is null -- RETHINK THIS APPROACH
                node.Next = newNode;
                newNode.Prev = node;
                tail = newNode;
            }
            else
            {
                var next = node.Next;
                next.Prev = newNode;
                newNode.Next = next;
                newNode.Prev = node;
                node.Next = newNode;
            }

            count++;
        }

        // TODO: Refactor these methods, to compact them and use one central method
        private void AddBefore(IndexedLinkedListNode<T> node, T value) { AddBefore(node, new IndexedLinkedListNode<T>(value)); }
        private void AddBefore(IndexedLinkedListNode<T> node, IndexedLinkedListNode<T> newNode)
        {
            if (node == null) { throw new ArgumentNullException(); }
            if (node == head)
            {
                // TODO: Could be possible null, if head is null -- RETHINK THIS APPROACH
                node.Prev = newNode;
                newNode.Next = node;
                head = newNode;
            }
            else
            {
                var prev = node.Prev;
                prev.Next = newNode;
                newNode.Prev = prev;
                newNode.Next = node;
                node.Prev = newNode;
            }

            count++;
        }


        public bool Remove(T item)
        {
            var node = Find(item);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // TODO: Research if Inserting at the end of the list is part of the spec
        public void Insert(int index, T item)
        {
            if ((uint)index > (uint)count) { throw new ArgumentOutOfRangeException(); }

            // Adding at the end of the list
            if (index == count) { Add(item); }
            else
            {
                // Adding in the middle of the list
                var node = GetNode(index);
                AddBefore(node, item);
            }
        }

        private IndexedLinkedListNode<T> GetNode(int index)
        {
            if ((uint)index >= (uint)count) { throw new ArgumentOutOfRangeException(); }

            int i = 0;
            var node = head;
            while (i < index) // NOTE: node should never be null, and if it is that's a problem so let it throw an exception
            {
                node = node.Next;
                i++;
            }

            return node;
        }

        // TODO: Refactor Method RemoveNode
        private void RemoveNode(IndexedLinkedListNode<T> node)
        {
            // We are removing the last element
            if (count <= 1)
            {
                Clear();
                return;
            }

            var prev = node.Prev;
            var next = node.Next;

            if (prev == null) // We are Head
            {
                next.Prev = null;
                head = next;
            }
            else if (next == null) // We are tail
            {
                prev.Next = null;
                tail = prev;
            }
            else
            {
                prev.Next = next;
                next.Prev = prev;
            }

            count--;
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)count) { throw new ArgumentOutOfRangeException(); }

            // Adding in the middle of the list
            var node = GetNode(index);
            RemoveNode(node);
        }

        public int IndexOf(T item)
        {
            int index = 0;
            var node = head;
            while (node != null)
            {
                if (Equals(node.Value, item)) { return index; }
                node = node.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(T item) { return Find(item) != null; }
        public IndexedLinkedListNode<T> Find(T item)
        {
            var node = head;
            while (node != null)
            {
                if (Equals(node.Value, item)) { return node; }
                node = node.Next;
            }

            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // There is not enough Space in the Array to hold all list items
            if (arrayIndex < 0 || (array.Length - arrayIndex) < count) { throw new ArgumentOutOfRangeException(); }

            var node = head;
            while (node != null)
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            }
        }


        public T this[int index]
        {
            get
            {
                var node = GetNode(index);
                return node.Value;
            }

            set
            {
                var node = GetNode(index);
                node.Value = value;
            }
        }

        // Enumerator
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public class IndexedLinkedListNode<T>
        {
            public T Value { get; set; }
            public IndexedLinkedListNode<T> Prev { get; set; }
            public IndexedLinkedListNode<T> Next { get; set; }

            public IndexedLinkedListNode(T value) { Value = value; }
        }
    }
}
