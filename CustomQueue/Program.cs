using System;

namespace CustomQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var queue = new FastQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            queue.Dequeue();
            queue.Dequeue();


            Console.WriteLine(queue.Peek());


     

        }
    }
}
