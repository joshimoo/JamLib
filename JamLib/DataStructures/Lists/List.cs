using System;
using System.Collections;
using System.Collections.Generic;

namespace JamLib.DataStructures.Lists
{
    /// <summary>
    /// NOTE: DO NOT USE THIS CLASS, INSTEAD USE THE NET FRAMEWORK IMPLEMENTATION
    /// </summary>
    internal class List<T> : IList<T>
    {
        // HACK: using an empty array is better, since we don't need special handling for null [explanation]: http://stackoverflow.com/questions/3102353/what-happens-if-i-initialize-an-array-to-size-0
        static readonly T[] emptyArray = new T[0];
        private const int INITIAL_CAPACITY = 4;
        private T[] items;
        private int count;


        public bool IsReadOnly { get { return false; } }
        public int Count { get { return count; } }
        public int Capacity
        {
            get { return items.Length; }
            set
            {
                // Check if the new value is sane, if so allocate a new array with that size then copy over the old array
                if (value < items.Length) { throw new ArgumentOutOfRangeException(); }
                if (value > 0)
                {
                    T[] newArray = new T[value];
                    if (count > 0) { Array.Copy(items, newArray, items.Length); }
                    items = newArray;
                }
                else { items = emptyArray; }
            }
        }

        // Start with an empty list and let Add handle size increases
        public List() { items = emptyArray; }

        public void Add(T item)
        {
            // Check if we still have space to add an item, if not double the space
            if (count == items.Length) { EnsureCapacity(count + 1); }
            items[count++] = item;
        }

        // Ensures that the capacity of this list is at least the given minimum 
        // value. If the currect capacity of the list is less than min, the
        // capacity is increased to twice the current capacity or to min,
        // whichever is larger.
        private void EnsureCapacity(int minCapacity)
        {
            if (items.Length < minCapacity)
            {
                int newCapacity = items.Length == 0 ? INITIAL_CAPACITY : items.Length * 2;
                if (newCapacity < minCapacity) { newCapacity = minCapacity; }
                Capacity = newCapacity;
            }
        }

        public void Clear()
        {
            // NOTE: Clear the references so gc can cleanup, could use if (count > 0) { Array.Clear(array, 0, count); }
            for (int i = 0; i < count; i++) { items[i] = default(T); }
            count = 0;
        }

        public bool Contains(T item) { return IndexOf(item) >= 0; }
        public int IndexOf(T item)
        {
            // NOTE: Could use Array.IndexOf(array, item);
            for (int i = 0; i < count; i++)
            {
                if (Equals(items[i], item)) { return i; }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            // HACK: insertion at the end are valid, since the index is equal to count if there is no space, then space will be allocated
            if ((uint)index > (uint)count) { throw new ArgumentOutOfRangeException(); }
            if (count == items.Length) { EnsureCapacity(count + 1); }
            if (index < count) { Array.Copy(items, index, items, index + 1, count - index); }

            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            // Trying to delete an non existing item, (uint) cast saves to check for negatives since it will always be bigger
            if ((uint)index >= (uint)count) { throw new ArgumentOutOfRangeException(); }

            // Lower the count, if the index is not smaller then the index was the last item and we don't care
            count--;
            if (index < count) { Array.Copy(items, index + 1, items, index, count - index); }

            // NOTE: Cleanup the last item reference, [explanation]: default(T) http://msdn.microsoft.com/en-us/library/xwth0h0d.aspx
            items[count] = default(T);
        }

        // TODO: Should implement error checking, TODO: Implement own Array.Copy Method
        public void CopyTo(T[] array) { CopyTo(array, 0); }
        public void CopyTo(T[] array, int arrayIndex) { Array.Copy(items, 0, array, arrayIndex, count); }

        public T this[int index]
        {
            get
            {
                // HACK: (uint) cast saves to check for negatives since it will always be bigger
                if ((uint)index >= (uint)count) { throw new ArgumentOutOfRangeException(); }
                return items[index];
            }
            set
            {
                // TODO: Research if casting is faster then range checking
                if ((uint)index >= (uint)count) { throw new ArgumentOutOfRangeException(); }
                items[index] = value;
            }
        }

        // TODO: Implement IEnumerator
        public IEnumerator<T> GetEnumerator() { throw new NotImplementedException(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
