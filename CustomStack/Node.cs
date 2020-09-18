using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

    }
}
