using System;

namespace CustomTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));


            //foreach (var item in tree.OrderDfs())
            //{
            //    Console.WriteLine(item);
            //}


            //foreach (var item in tree.OrderBfs())
            //{
            //    Console.WriteLine(item);

            //}

            //tree.AddChild(7, new Tree<int>(88));

            tree.RemoveNode(7);

            foreach (var item in tree.OrderBfs())
            {
                Console.WriteLine(item.Value);
            }


        }
    }
}
