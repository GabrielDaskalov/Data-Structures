using System;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T item)
        {
            this.Value = item;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

    }
}
