﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class Node<T>
    {
        public Node(T value, Node<T> next = null)
        {
            this.Value = value;
            this.Next = next;

        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
        
        public Node<T> Previous { get; set;}


    }
}
