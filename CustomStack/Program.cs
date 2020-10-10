using System;

namespace CustomStack
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Peek());

            Console.WriteLine(stack.Count);

        }
    }
}
