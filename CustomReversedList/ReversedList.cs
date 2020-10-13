using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomReversedList
{
    public class ReversedList<T> : IAbstractReversedList<T>
    {
        private int capacity = 4;
        private T[] items;

        public ReversedList()
        {
            this.Count = 0;
            this.items = new T[capacity];
        }

        //accessing the elements in reversed order
        public T this[int index]
        {
           

            get
            {
                ValidateIndex(this.Count - index - 1);
                return this.items[this.Count - index - 1];
            }
            set
            {
                ValidateIndex(this.Count - index - 1);
                this.items[this.Count - index - 1] = value;

            }

        }

        public int Count { get; set; }

        public void Add(T item)
        {

            GrowIfNecessary();

            if (this.Count == 0)
            {
                items[0] = item;

            }
            else
            {
                var temp = items[0];

                for (int i = 0; i < this.Count; i++)
                {
                    var secondTemp = items[i + 1];
                    items[i + 1] = temp;
                    temp = secondTemp;
                    
                }

                items[0] = item;
            }


            this.Count++;

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

            for (int i = this.Count; i > index; i--)
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
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));

            }


        }

    }
}
