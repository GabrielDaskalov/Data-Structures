using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class Queue<T> : IAbstractQueue<T>
    {
        private int count;
        private Node<T> front;

        public Queue()
        {
            this.count = 0;
            this.front = null;
        }


        public int Count => this.count;

        public bool Contains(T item)
        {
            var current = this.front;

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

        public T Dequeue()
        {

            ValidateQueue();

            var elementToDelete = this.front;
            this.front = this.front.Next;

            this.count--;
            return elementToDelete.Value;
        }

        public void Enqueue(T item)
        {
            var newElement = new Node<T>(item);

            if (this.front == null)
            {
                this.front = newElement;


            }
            else
            {
                var current = this.front;

                while (current.Next != null)
                {
                    current = current.Next;

                }

                current.Next = newElement;

            }


            this.count++;

        }

        public T Peek()
        {
            ValidateQueue();

            return this.front.Value;

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

            Node<T> current = this.front;

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
