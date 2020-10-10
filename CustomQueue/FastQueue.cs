using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public FastQueue()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public FastQueue(Node<T> item)
        {
            this.head = this.tail = item;
            this.count = 1;
        }

        public int Count => this.count;

        public T Dequeue()
        {
            ValidateQueue();

            var elementToDelete = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;

            }
            else
            {
                this.head = head.Next;
            }
            
            this.count--;

            return elementToDelete;

        }

        public void Enqueue(T item)
        {
            var newElement = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newElement;

            }
            else
            {

                this.tail.Next = newElement;
                this.tail = newElement;
            }

            this.count++;
           


        }

        public T Peek()
        {
            ValidateQueue();

            return this.head.Value;

        }

        public bool Contains(T item)
        {
            var current = this.head;

            while (current.Next != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }


            return false;
        }

        private bool ValidateQueue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            return true;


        }

        public IEnumerator<T> GetEnumerator()
        {

            Node<T> current = this.head;

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
    }
}
