using System;

namespace CustomReversedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var reversedList = new ReversedList<int>();

            reversedList.Add(1);
            reversedList.Add(2);
            reversedList.Add(3);
            reversedList.Add(4);


            foreach (var item in reversedList)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(reversedList.Count);
            Console.WriteLine(reversedList.IndexOf(2));

            reversedList.Insert(2, 7);

            Console.WriteLine("new");

            foreach (var item in reversedList)
            {
                Console.WriteLine(item);


            }

            reversedList.Remove(1);

            reversedList.RemoveAt(1);

        }
    }
}
