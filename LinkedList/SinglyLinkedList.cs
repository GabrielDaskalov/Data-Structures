using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public SinglyLinkedList()
        {
            this.head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            this.head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> toInsert = new Node<T>(item, this.head);
            this.head = toInsert;
            Count++;

        }

        public void AddLast(T item)
        {
            Node<T> toInsert = new Node<T>(item);
            Node<T> current = this.head;


            if (current == null)
            {
                this.head = toInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toInsert;
            }

            Count++;

        }

        public T GetFirst()
        {
            if (ValidateIfListIsEmpty())
            {
                throw new ArgumentException("Linked List is empty!");
            }

            return this.head.Value;

        }

        public T GetLast()
        {
            if (ValidateIfListIsEmpty())
            {
                throw new ArgumentException("Linked List is empty!");
            }

            var current = this.head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }


        public T RemoveFirst()
        {
            if (ValidateIfListIsEmpty())
            {
                throw new ArgumentException("Linked List is empty!");
            }

            var elementToDelete = this.head;
            this.head = this.head.Next;
            this.Count--;

            return elementToDelete.Value;
        }

        public T RemoveLast()
        {

            if (ValidateIfListIsEmpty())
            {
                throw new ArgumentException("Linked List is empty!");

            }

            var elementToDelete = this.head;

            if (head.Next == null)
            {

                Count--;
                return head.Value;

            }

            var secondLast = this.head;


            while (secondLast.Next.Next != null)
            {
                secondLast = secondLast.Next;

            }

            Count--;

            secondLast.Next = null;

            return secondLast.Value;

        }

        public void Print()
        {
            
            while (this.head != null)
            {
                Console.WriteLine(this.head.Value);
                this.head = this.head.Next;

            }


        }


        private bool ValidateIfListIsEmpty()
        {
            if (this.head != null)
            {
                return false;
            }

            return true;


        }
    }
}
