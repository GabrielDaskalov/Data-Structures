using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            //var newList = new DoublyLinkedList<int>();

            var newList = new SinglyLinkedList<int>();

            newList.AddLast(1);
            newList.AddLast(2);
            newList.AddLast(3);
            newList.AddLast(4);


            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }

            newList.RemoveFirst();
            newList.RemoveLast();


            Console.WriteLine(newList.GetFirst());
            Console.WriteLine(newList.GetLast());
        }
    }
}
