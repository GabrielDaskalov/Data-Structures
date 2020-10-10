
using System.Collections.Generic;

namespace CustomQueue
{
    public interface IAbstractQueue<T>: IEnumerable<T>
    {
        void Enqueue(T item);

        T Dequeue();

        T Peek();

        int Count { get; }

        bool Contains(T item);

        new IEnumerator<T> GetEnumerator();



    }
}
