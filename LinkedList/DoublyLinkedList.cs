using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        private int count;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public DoublyLinkedList(Node<T> item)
        {
            this.head = this.tail = item;
            this.count = 1;

        }

        public int Count => this.count;

        public void AddFirst(T item)
        {
            var newElement = new Node<T>(item);

            if (ValidateIfEmpty())
            {
                this.head = this.tail = newElement;
            }
            else
            {
                this.head.Previous = newElement;
                newElement.Next = this.head;
                this.head = newElement;
                newElement.Previous = null;
            }

            this.count++;


        }

        public void AddLast(T item)
        {
            var newElement = new Node<T>(item);

            if (ValidateIfEmpty())
            {
                this.head = this.tail = newElement;
            }
            else
            {
                this.tail.Next = newElement;
                newElement.Previous = this.tail;
                this.tail = newElement;
                newElement.Next = null;
            }

            this.count++;


        }

        public T GetFirst()
        {
            if (ValidateIfEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }

            return this.head.Value;
        }

        public T GetLast()
        {
            if (ValidateIfEmpty())
            {
                throw new InvalidOperationException("List is empty!");

            }

            return this.tail.Value;

        }

        public T RemoveFirst()
        {
            if (ValidateIfEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }
            var elementToDelete = this.head;


            if (this.Count == 1)
            {
                this.head = this.tail = null;

            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }
            this.count--;

            return elementToDelete.Value;

        }

        public T RemoveLast()
        {
            if (ValidateIfEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }

            var elementToDelete = this.tail;

            if (this.Count == 1)
            {
                this.head = this.tail = null;

            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            this.count--;

            return elementToDelete.Value;



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

        private bool ValidateIfEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }


            return false;
        }
    }
}
