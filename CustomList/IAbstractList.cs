using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public interface IAbstractList<T>
    {
        void Add(T item);

        int Count { get; set; }

        void Insert(int index, T item);

        T this[int index] { get; set; }

        void RemoveAt(int index);

        bool Contains(T item);

        int IndexOf(T item);

        bool Remove(T item);
            

    }
}
