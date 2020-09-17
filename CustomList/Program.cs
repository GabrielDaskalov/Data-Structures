
namespace CustomList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveAt(3);
            list.Remove(8);
            list.Remove(1);

            System.Console.WriteLine(list.IndexOf(3));


        }
    }
}
