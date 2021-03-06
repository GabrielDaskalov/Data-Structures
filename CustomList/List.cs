using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class List<T> : IAbstractList<T>
    {
        private int capacity = 4;
        private T[] items;

        public List()
        {
            this.Count = 0;
            this.items = new T[capacity];

        }

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            
            }
        }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            
            this.items[this.Count++] = item;


        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (item.Equals(items[i]))
                {

                    return true;
                }

            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (item.Equals(items[i]))
                {

                    return i;
                }

            }
            
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            for (int i = this.Count;i > index; i--)
            {
                this.items[i] = this.items[i - 1];

            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int elementIndex = -1;

            for (int i = 0; i < items.Length; i++)
            {
                if (item.Equals(items[i]))
                {
                    elementIndex = i;
                }

            }

            if (elementIndex == -1)
            {
                return false;

            }

            for (int i = elementIndex; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];

            }

            items[this.Count - 1] = default;
            
            this.Count--;

            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;

            this.Count--;

        }
        private void GrowIfNecessary()
        {
            if (this.Count == this.items.Length)
            {
                this.items = Grow();
                this.capacity *= 2;

            }
        
        }

        private T[] Grow()
        {
            var newArr = new T[this.Count * 2];
            Array.Copy(this.items, newArr, this.items.Length);
            return newArr;
        
        }

        private void ValidateIndex(int index)
        {
            if(index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            
            }
        
        
        }

        public IEnumerator<T> GetEnumerator()
        {
            int length = this.Count;
            int countTemp = 0;

            while (length > 0)
            {
                yield return items[countTemp++];

                length--;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return this.GetEnumerator();

        }
    }
}
