using System;
using System.Collections;
using System.Collections.Generic;

namespace JamLib.DataStructures.Lists
{
    /// <summary>
    /// NOTE: DO NOT USE THIS CLASS, INSTEAD USE THE NET FRAMEWORK IMPLEMENTATION
    /// Since this is just for a toy project it's missing quite a bit of error checking and boilerplate code
    /// </summary>
    public class SinglyLinkedList<T> : ICollection<T>
    {
        private int count;
        public int Count { get { return count; } }
        public bool IsReadOnly { get { return false; } }

        private SinglyLinkedListNode<T> head;
        public SinglyLinkedListNode<T> First { get { return head; } }

        public void Add(T value)
        {
            // TODO: Refactor to use a tail instead of adding infront of the head
            // NOTE: This is not needed since when the head is null, we are passing null anyway. Leaving it for the moment, till I refactor to use a tail instead of adding as a new head.
            if (head == null)
            {
                // First Element
                var node = new SinglyLinkedListNode<T>(value, null);
                head = node;
            }
            else
            {
                // Add the new node as the head, and link to the old head
                var node = new SinglyLinkedListNode<T>(value, head);
                head = node;
            }

            count++;
        }

        // This is dumb since it uses O(n), much better would be a DoublyLinkedList since then I could use the prev pointer from the current node.
        public bool Remove(T item)
        {
            var currNode = head;
            var prevNode = currNode;
            while (currNode != null)
            {
                if (Equals(currNode.Value, item))
                {
                    // Hook this up
                    prevNode.Next = currNode.Next;
                    count--;
                    return true;
                }

                prevNode = currNode;
                currNode = currNode.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(T item) { return Find(item) != null; }
        public SinglyLinkedListNode<T> Find(T value)
        {
            var node = head;
            while (node != null)
            {
                if (Equals(node.Value, value))
                {
                    return node;
                }
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

        #region List Node class
        public class SinglyLinkedListNode<T>
        {
            public SinglyLinkedListNode<T> Next { get; set; }
            public T Value { get; set; }

            public SinglyLinkedListNode(T value, SinglyLinkedListNode<T> next)
            {
                Value = value;
                Next = next;
            }
        }
        #endregion

        #region Enumerator
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public IEnumerator<T> GetEnumerator() { return new Enumerator(this); }

        public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
        {
            private SinglyLinkedList<T> list;
            private SinglyLinkedListNode<T> node;
            private T current;
            private int index;

            internal Enumerator(SinglyLinkedList<T> list)
            {
                this.list = list;
                node = list.head;
                current = default(T);
                index = 0;
            }


            public T Current { get { return current; } }
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (index == 0 || (index == list.Count + 1)) { throw new InvalidOperationException(); }
                    return current;
                }
            }

            public bool MoveNext()
            {
                // No more nodes left
                if (node == null)
                {
                    index = list.Count + 1;
                    return false;
                }

                ++index;
                current = node.Value;
                node = node.Next;
                // if (node == list.head) { node = null; }

                return true;
            }

            void System.Collections.IEnumerator.Reset()
            {
                current = default(T);
                node = list.head;
                index = 0;
            }

            public void Dispose() { }
        }
        #endregion
    }
}
