using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T> : IAbstractStack<T>
    {
        private int count;
        private Node<T> top;

        public Stack()
        {
            count = 0;
            top = null;

        }


        public int Count => count;

        public T Peek()
        {
            if (this.EnsureNotEmpty())
            {
                throw new InvalidOperationException("The stach is empty!");

            }

            return this.top.Value;


        }

        public T Pop()
        {
            if (this.EnsureNotEmpty())
            {
                throw new InvalidOperationException("The stach is empty!");

            }

            var topNodeValue = this.top.Value;
            var newTopNode = this.top.Next;

            this.top.Next = null;

            this.top = newTopNode;

            this.count--;

            return topNodeValue;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>()
            {
                Value = item,
                Next = this.top

            };

            this.top = newNode;

            this.count++;
        

        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.top;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();


        }
        private bool EnsureNotEmpty()
        {
            if (this.top == null)
            {
                return true;
            }

            return false;
        
        }
    }
}
