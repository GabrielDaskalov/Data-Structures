using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public interface IAbstractLinkedList<T>: IEnumerable<T>
    {
        void AddLast(T item);

        void AddFirst(T item);

        T RemoveFirst();

        T RemoveLast();

        T GetFirst();

        T GetLast();

        int Count { get; }

        IEnumerator<T> GetEnumerator();


    }
}
