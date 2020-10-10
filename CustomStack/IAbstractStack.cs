using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public interface IAbstractStack<T>: IEnumerable<T>
    {
        void Push(T item);

        T Pop();

        T Peek();

        int Count { get; }

        new IEnumerator<T> GetEnumerator();



    }
}
